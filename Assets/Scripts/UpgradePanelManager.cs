using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelManager : MonoBehaviour
{
    [SerializeField] GameObject panel;

    public void OpenPanel()
    {
        Time.timeScale = 0f;
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        Time.timeScale = 0f;
        panel.SetActive(false);
    }
}
