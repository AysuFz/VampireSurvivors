using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TerrainTail : MonoBehaviour
{
    [SerializeField] Vector2Int tilePos;
    [SerializeField] List<SpawnObject> spawnObjects;
    void Start()
    {
        GetComponentInParent<WorldScrolling>().Add(gameObject, tilePos);

        transform.position = new Vector3(-100, 100, 0);
    }

 
    public void Spawn()
    {
        for(int i = 0; i < spawnObjects.Count; i++)
        {
            spawnObjects[i].Spawn();
        }
    }
}
