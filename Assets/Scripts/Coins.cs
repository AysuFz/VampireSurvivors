using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] DataContainer data;
    [SerializeField] TMPro.TextMeshProUGUI coinsCountText;

    private void Start()
    {
        coinsCountText.text = data.coins.ToString();
    }

    public void Add(int count)
    {
        data.coins += count;
        coinsCountText.text = data.coins.ToString();
    }
}
