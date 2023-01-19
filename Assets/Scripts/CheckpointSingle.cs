using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSingle : MonoBehaviour
{
    private TrackCheckpoints trackCheckpoints;
    private MeshRenderer meshRenderer;
    //creates way to access the mesh renderer
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    //hides all checkpoint meshes on start
    private void Start()
    {
        Hide();
    }
    //detects player going through checkpoint
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<CarController>(out CarController carController))
        {
            trackCheckpoints.PlayerThroughCheckpoint(this);
        }
    }   
    //makes the checkpoint a checkpoint
    public void SetTrackCheckpoints(TrackCheckpoints trackCheckpoints)
    {
        this.trackCheckpoints = trackCheckpoints;
    }
    //makes it so checkpoints can be hidden
    public void Show()
    {
        meshRenderer.enabled = true;
    }
    //makes it so checkpoints can be shown
    public void Hide()
    {
        meshRenderer.enabled = false;
    }
}
