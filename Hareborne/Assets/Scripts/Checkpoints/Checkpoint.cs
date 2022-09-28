using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//author Kai
public class Checkpoint : MonoBehaviour
{
    float m_RecordedTime;
    [HideInInspector]
    public bool m_triggered = false;
    private CheckpointSystem m_parentSystem;
    public Timer m_timer;

    /// <summary>
    /// Get the parent system for references to the player in the scene
    /// </summary>
    private void Start()
    {
        m_parentSystem = GetComponentInParent<CheckpointSystem>();
    }
    /// <summary>
    /// If the player collides with the checkpoints trigger, set the players respawn location to the checkpoints transform,
    /// Take a record of the time
    /// set the next checkpoint to active
    /// set current checkpoiint to false
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            m_parentSystem.m_player.SetRespawn(transform.position);
            m_RecordedTime = m_timer.GetCurrentTime();

            int siblingIndex = transform.GetSiblingIndex();
            m_parentSystem.m_checkpoints[siblingIndex + 1].gameObject.SetActive(true);
            gameObject.SetActive(false);

            //check if all checkpoints in parent Checkpoint system are hit
            foreach(Checkpoint c in m_parentSystem.m_checkpoints)
            {
                if(!c.m_triggered)
                {
                    break;
                }
                //do win stuffs
            }
        }
    }
}
