using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CheckpointSystem))]
public class CheckpointSystemEditor : Editor
{
    ///<summary>
    /// Creates buttons in the editor to create the beginning and end of the course,
    ///</summary>

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        CheckpointSystem thisObject = (CheckpointSystem)target;

        if (GUILayout.Button("Create New Checkpoint"))
        {
            if (thisObject.transform.childCount == 0)
                thisObject.CreateStartEnd();
            else
                thisObject.CreateNewCheckpoint();
        }
    }
}
