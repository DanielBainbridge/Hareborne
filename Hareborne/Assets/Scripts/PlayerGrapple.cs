using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrapple : MonoBehaviour
{
    private Vector3 m_grapplePoint;
    [HideInInspector]
    public Vector3 m_currentGrapplePosition;
    private SpringJoint m_springJoint;
    public LayerMask m_grappleableObjects;
    public Transform m_hookOrigin, m_camera, m_player;
    public float m_maxRopeDistance, m_minRopeDistance, m_hookSpeed, m_hookRigidness, m_hookPullSlow, m_massScale;
    [Range(1.0f, 0.0f)][Tooltip("The lower this number the stronger the initial pull")]
    public float m_initialPull;

    public void StartGrapple()
    {
        //create RaycastHit
        RaycastHit hit;
        // if raycast hits something that you can grapple onto
        if (Physics.Raycast(m_camera.position, m_camera.forward, out hit, m_maxRopeDistance, m_grappleableObjects))
        {
            m_grapplePoint = hit.point;
            m_springJoint = m_player.gameObject.AddComponent<SpringJoint>();
            m_springJoint.autoConfigureConnectedAnchor = false;
            m_springJoint.connectedAnchor = m_grapplePoint;

            // Spring creation
            float distanceFromPoint = Vector3.Distance(m_player.position, m_grapplePoint);
            m_springJoint.maxDistance = distanceFromPoint * m_initialPull;
            m_springJoint.minDistance = distanceFromPoint * 0.25f;

            m_springJoint.spring = m_hookRigidness;
            m_springJoint.damper = m_hookPullSlow;
            m_springJoint.massScale = m_massScale;
        }
    }    
    public void StopGrapple()
    {
        Destroy(m_springJoint);
    }
    
    public bool IsGrappling()
    {
        return m_springJoint != null;
    }
    public Vector3 GetGrapplePoint()
    {
        return m_grapplePoint;
    }
}
