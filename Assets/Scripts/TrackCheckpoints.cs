using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoints : MonoBehaviour
{
    public event EventHandler OnPlayerCorrectCheckpoint;
    public event EventHandler OnPlayerWrongCheckpoint;
    private List<CheckpointSingle> checkpointSingleList;
    private int nextCheckpointSingleIndex;

    private void Awake()
    {
        Transform checkpointsTransform = transform.Find("Checkpoints");

        foreach (Transform checkpointSingleTransform in checkpointsTransform)
        {
            CheckpointSingle checkpointsingle = checkpointSingleTransform.GetComponent<CheckpointSingle>();
            checkpointsingle.SetTrackCheckpoints(this);
        }
        nextCheckpointSingleIndex = 0;
    }
    public void PlayerThroughCheckpoint(CheckpointSingle checkpointSingle)
    {
        
        if (checkpointSingleList.IndexOf(checkpointSingle)==nextCheckpointSingleIndex)
        {
            Debug.Log("Zesrales sie w ifie");
            nextCheckpointSingleIndex = (nextCheckpointSingleIndex + 1) % checkpointSingleList.Count;
            //OnPlayerCorrectCheckpoint?.Invoke(this, EventArgs.Empty);
        }
        else 
        {
            Debug.Log("Zesrales sie ale w elsie");

            //OnPlayerWrongCheckpoint?.Invoke(this, EventArgs.Empty);
        }

    }
}
