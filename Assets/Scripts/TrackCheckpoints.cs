using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrackCheckpoints : MonoBehaviour
{   
    //events for player going the through the right and wrong checkpoint
    public event EventHandler OnPlayerCorrectCheckpoint;
    public event EventHandler OnPlayerWrongCheckpoint;

    //makes a list for storing all the checkpoints
    private List<CheckpointSingle> checkpointSingleList;
    private int nextCheckpointSingleIndex;

    public static TrackCheckpoints instance;

    public int Laps = 0;


    //TrackLogicWindow trackLogicWindow;
    
    //adds all the checkpoints into a list
    private void Awake()
    {   
        instance = this; 
        
        Transform checkpointsTransform = transform.Find("Checkpoints");

        checkpointSingleList = new List<CheckpointSingle>();
        foreach (Transform checkpointSingleTransform in checkpointsTransform)
        {
            CheckpointSingle checkpointSingle = checkpointSingleTransform.GetComponent<CheckpointSingle>();
            
            checkpointSingle.SetTrackCheckpoints(this);
            
            checkpointSingleList.Add(checkpointSingle);
        }
    }
    private void Start()
    {
        //shows the first checkpoint
        CheckpointSingle nextCheckpointSingle = checkpointSingleList[nextCheckpointSingleIndex];
        nextCheckpointSingle.Show(); 
    }

    public void PlayerThroughCheckpoint(CheckpointSingle checkpointSingle)
    {   
        //shows the checkpoints(next, right and wrong)
        if (checkpointSingleList.IndexOf(checkpointSingle) == nextCheckpointSingleIndex) 
        {  
            //Next Checkpoint
            CheckpointSingle nextCheckpointSingle = checkpointSingleList[(nextCheckpointSingleIndex + 1) % checkpointSingleList.Count];
            nextCheckpointSingle.Show(); 
                
            //Correct Checkpoint
            CheckpointSingle correctCheckpointSingle = checkpointSingleList[nextCheckpointSingleIndex];
            correctCheckpointSingle.Hide();
            nextCheckpointSingleIndex = (nextCheckpointSingleIndex + 1) % checkpointSingleList.Count;
            OnPlayerCorrectCheckpoint?.Invoke(this, EventArgs.Empty);

            if (nextCheckpointSingleIndex == 1)
            {
                Laps++;
            } 
        } 
        else 
        {
            //Wrong Checkpoint
            OnPlayerWrongCheckpoint?.Invoke(this, EventArgs.Empty);

            CheckpointSingle correctCheckpointSingle = checkpointSingleList[nextCheckpointSingleIndex];
            correctCheckpointSingle.Show();
        } 
    }
}
