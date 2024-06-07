using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TerrainTail : MonoBehaviour
{
    [SerializeField] Vector2Int tilePos;
    void Start()
    {
        GetComponentInParent<WorldScrolling>().Add(gameObject, tilePos);

        transform.position = new Vector3(-100, 100, 0);
    }

 
}
