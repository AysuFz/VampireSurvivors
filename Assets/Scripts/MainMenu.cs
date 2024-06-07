using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject panel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(panel.activeInHierarchy == false) { OpenMenu(); }

            else { CloseMenu(); }
        }
    }

    public void CloseMenu()
    {
        Time.timeScale = 1f;
        panel.SetActive(false);
    }

    public void OpenMenu()
    {
        Time.timeScale = 0f;
        panel.SetActive(true);
    }
}
