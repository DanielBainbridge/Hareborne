//Authored By Daniel Bainbridge
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDolly : MonoBehaviour
{
    public Transform m_cameraTarget;
    private Camera m_camera;
    public float m_horizontalSensitivity = 2, m_verticalSensitivity = 2, m_cameraPOV = 50, m_cameraDistance = 5;
    private float m_xInput = 0, m_yInput;


    // Start is called before the first frame update
    void Start()
    {
        m_camera = transform.GetComponentInChildren<Camera>();
        transform.localPosition = (m_cameraTarget.position + new Vector3(0f, 0f, -m_cameraDistance));
        transform.parent.position = m_cameraTarget.position;
        m_camera.fieldOfView = m_cameraPOV;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void LateUpdate()
    {
        transform.parent.position = m_cameraTarget.position;
        m_xInput += Input.GetAxis("Mouse X") * m_horizontalSensitivity;
        m_yInput += Input.GetAxis("Mouse Y") * m_verticalSensitivity;

        m_yInput = Mathf.Clamp(m_yInput, -89, 89);
        transform.parent.rotation = Quaternion.Euler(-m_yInput, m_xInput, 0);
    }


}
