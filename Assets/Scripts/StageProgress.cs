using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageProgress : MonoBehaviour
{
    StageTime stageTime;

    private void Awake()
    {
        stageTime = GetComponent<StageTime>();
    }

    [SerializeField] float progressTimeRate = 30f;
    [SerializeField] float progressPerSplit = 0.2f;
    public float Progress
    {
        get
        {
            return 1f +  stageTime.time / progressTimeRate * progressPerSplit;
        }
    }
}
