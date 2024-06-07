using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOptions : MonoBehaviour
{
    [SerializeField] GameObject panel;

    public void CloseOption()
    {
        panel.SetActive(false);
    }

    public void OpenOption()
    {
        Time.timeScale = 0f;
        panel.SetActive(true);
    }
}
