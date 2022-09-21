using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrapple : MonoBehaviour
{
    private LineRenderer m_lineRenderer;
    private Vector3 m_grapplePoint;
    private SpringJoint m_springJoint;
    public LayerMask m_grappleableObjects;
    public Transform m_hookOrigin, m_camera, m_player;
    public float m_maxRopeDistance, m_minRopeDistance, m_hookPullStrength, m_hookDamper, m_massScale;

    private void Awake()
    {
        // Defines Line Renderer
        m_lineRenderer = GetComponent<LineRenderer>();
    }
    public void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(m_camera.position, m_camera.forward, out hit, m_maxRopeDistance, m_grappleableObjects))
        {
            m_grapplePoint = hit.point;
            m_springJoint = m_player.gameObject.AddComponent<SpringJoint>();
            m_springJoint.autoConfigureConnectedAnchor = false;
            m_springJoint.connectedAnchor = m_grapplePoint;

            // Spring creation
            float distanceFromPoint = Vector3.Distance(m_player.position, m_grapplePoint);
            m_springJoint.maxDistance = distanceFromPoint;
            m_springJoint.minDistance = m_minRopeDistance;
            m_springJoint.spring =  m_hookPullStrength;
            m_springJoint.damper =  m_hookDamper;
            m_springJoint.massScale = m_massScale;

            m_lineRenderer.positionCount = 2;
        }
    }    
    public void StopGrapple()
    {
        m_lineRenderer.positionCount = 0;
        Destroy(m_springJoint);
    }
    public void DrawRope()
    {
        if (!m_springJoint)
            return;
        m_lineRenderer.SetPosition(0, m_hookOrigin.position);
        m_lineRenderer.SetPosition(1, m_grapplePoint);
    }
    public bool IsGrappling()
    {
        return m_springJoint != null;
    }
}
