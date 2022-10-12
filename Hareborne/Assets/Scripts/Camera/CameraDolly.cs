//Authored By Daniel Bainbridge
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDolly : MonoBehaviour
{
    public Transform m_cameraTarget;
    private Camera m_camera;
    public float m_horizontalSensitivity = 2, m_verticalSensitivity = 2, m_cameraPOV = 50;
    private float m_xInput = 0, m_yInput;
    public Vector3 m_cameraOffset = new Vector3(1.4f, 1, -12);


    // Start is called before the first frame update
    void Start()
    {
        m_camera = transform.GetComponentInChildren<Camera>();
        transform.position = m_cameraTarget.position;
        m_camera.transform.localPosition += m_cameraOffset;
        m_camera.fieldOfView = m_cameraPOV;
    }
    private void LateUpdate()
    {
        transform.position = m_cameraTarget.position;
        m_xInput += Input.GetAxis("Mouse X") * m_horizontalSensitivity;
        m_yInput += Input.GetAxis("Mouse Y") * m_verticalSensitivity;

        m_yInput = Mathf.Clamp(m_yInput, -75, 75);
        transform.rotation = Quaternion.Euler(-m_yInput, m_xInput, 0);
    }


}
