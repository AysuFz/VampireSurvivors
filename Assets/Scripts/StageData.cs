using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StageEventType
{
    SpawnEnemy,
    SpawnObject,
    WinStage
}

[Serializable]
public class StageEvent
{
    public StageEventType eventType;
    
    public float time;
    public EnemyData enemyToSpawn;

    public GameObject objectToSpawn;

    public int count;
}

[CreateAssetMenu]
public class StageData : ScriptableObject
{
    public List<StageEvent> stageEvents;

}
