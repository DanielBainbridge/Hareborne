using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    float m_RecordedTime;
    [HideInInspector]
    public bool m_triggered = false;
    private CheckpointSystem m_parentSystem;

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
            m_RecordedTime = Time.time;
            int siblingIndex = transform.GetSiblingIndex();
            m_parentSystem.m_checkpoints[siblingIndex + 1].gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
