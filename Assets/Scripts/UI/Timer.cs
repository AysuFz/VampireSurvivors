using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float elpasedTime;

    private void Update()
    {
        elpasedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elpasedTime / 60);
        int seconds = Mathf.FloorToInt(elpasedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
