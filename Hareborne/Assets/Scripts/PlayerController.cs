using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerGrapple m_leftGrapple, m_rightGrapple;
    public float m_rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_leftGrapple.StartGrapple();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            m_leftGrapple.StopGrapple();
        }
        if (Input.GetMouseButtonDown(1))
        {
            m_rightGrapple.StartGrapple();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            m_rightGrapple.StopGrapple();
        }

    }
    private void LateUpdate()
    {
        m_leftGrapple.DrawRope();
        m_rightGrapple.DrawRope();
    }

}
