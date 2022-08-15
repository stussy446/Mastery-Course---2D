using System.Linq;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    Checkpoint[] checkpoints;

    void Start()
    {
        checkpoints = GetComponentsInChildren<Checkpoint>();
    }


    public Checkpoint GetLastCheckpointThatWasPassed()
    {
        return checkpoints.Last(t => t.Passed);
    }
}
