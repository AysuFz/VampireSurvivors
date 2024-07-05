using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletion : MonoBehaviour
{
    [SerializeField] float timeToCompleteLevel;
    [SerializeField] GameObject levelCompletePanel;

    StageTime stageTime;


    private void Awake()
    {
        stageTime = GetComponent<StageTime>();
    }


    public void Update()
    {
        if (stageTime.time > timeToCompleteLevel)
        {
            Time.timeScale = 0f;
            levelCompletePanel.SetActive(true);
        }
    }
}
