using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCam : MonoBehaviour {

	public GameObject enterPortal;
	public GameObject exitPortal;

	// Use this for initialization
	void Start () {
		transform.position = Camera.main.transform.position;
		transform.rotation = Camera.main.transform.rotation;
	}
	
  private Vector4 CameraSpacePlane(Matrix4x4 m, Vector3 pos, Vector3 normal, float sideSign)
    {
		float m_ClipPlaneOffset = 0.07f;
        Vector3 offsetPos = pos + normal * m_ClipPlaneOffset;
        Vector3 cpos = m.MultiplyPoint(offsetPos);
        Vector3 cnormal = m.MultiplyVector(normal).normalized * sideSign;
        return new Vector4(cnormal.x, cnormal.y, cnormal.z, -Vector3.Dot(cpos, cnormal));
    }

	// Update is called once per frame
	void Update () {
		Quaternion rot180 = Quaternion.Euler(0, 180.0f, 0);
		Vector3 localPos = enterPortal.transform.InverseTransformPoint(Camera.main.transform.position);
		Vector3 rotatedPos = rot180 * localPos;
		transform.position = exitPortal.transform.TransformPoint(rotatedPos);
		transform.rotation = exitPortal.transform.rotation * rot180 * Quaternion.Inverse(enterPortal.transform.rotation) * Camera.main.transform.rotation;

		Camera cam = gameObject.GetComponent<Camera>();
		Vector4 clipPlane = CameraSpacePlane(cam.worldToCameraMatrix, exitPortal.transform.position, exitPortal.transform.TransformDirection(Vector3.left), 1.0f);
		cam.projectionMatrix = Camera.main.CalculateObliqueMatrix(clipPlane);
	}
}
