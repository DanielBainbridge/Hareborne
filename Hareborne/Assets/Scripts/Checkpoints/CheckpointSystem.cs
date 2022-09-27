using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    public GameObject m_checkpointPrefab;
    [HideInInspector]
    public List<Checkpoint> m_checkpoints;
    [HideInInspector]
    public PlayerController m_player;
    
    /// <summary>
    /// Set a reference to the player from within the scene
    /// </summary>
    void Start()
    {
        m_player = GetComponentInParent<PlayerController>();
        foreach(Checkpoint c in m_checkpoints)
        {
            c.m_triggered = false;
        }
        transform.GetChild(0).GetComponent<Checkpoint>().m_triggered = true;
        m_player.transform.position = transform.GetChild(0).transform.position;
        m_player.transform.rotation = transform.GetChild(0).transform.rotation;
    }
    
    public void CreateStartEnd()
    {
        GameObject start = Instantiate(m_checkpointPrefab, transform);
        start.name = "Map Start";
        m_checkpoints.Add(start.GetComponent<Checkpoint>());

        GameObject end = Instantiate(m_checkpointPrefab, transform);
        end.name = "Map End";
        m_checkpoints.Add(end.GetComponent<Checkpoint>());
    }
    public void CreateNewCheckpoint()
    {
        GameObject nextCheckpoint = Instantiate(m_checkpointPrefab, transform);
        nextCheckpoint.name = "Checkpoint " + (transform.childCount - 2);
        nextCheckpoint.transform.SetSiblingIndex(transform.childCount - 2);
    }
}
