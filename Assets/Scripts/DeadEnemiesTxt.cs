using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeadEnemiesTxt : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI deadText;

    private void Update()
    {
        if (deadText != null)
        {
            deadText.text = Enemy.deadEnemiesCount.ToString();
        }
    }
}

