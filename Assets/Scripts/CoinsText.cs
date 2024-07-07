using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsText : MonoBehaviour
{
    [SerializeField] DataContainer dataContainer;
    TMPro.TextMeshProUGUI text;


    private void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        text.text = dataContainer.coins.ToString();
    }

    void Update()
    {
        text.text = dataContainer.coins.ToString();
    }
}
