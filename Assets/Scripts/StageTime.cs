using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTime : MonoBehaviour
{
    public float time;

    private void Update()
    {
        time += Time.deltaTime;
    }
}
