using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
    [SerializeField] List<GameObject> dropItemPrefabs;
    [SerializeField] [Range(0f, 1f)] float chance = 1f;

    bool isQuitting = false;

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    private void OnDestroy()
    {
        if (isQuitting)
        {
            return;
        }
        if (Random.value < chance)
        {
            GameObject toDrop = dropItemPrefabs[Random.Range(0, dropItemPrefabs.Count)];
            SpawnManager.instance.SpawnObject(transform.position, toDrop);
        }
    }
}
