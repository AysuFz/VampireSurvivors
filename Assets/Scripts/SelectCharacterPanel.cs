using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacterPanel : MonoBehaviour
{
    [SerializeField] GameObject selectCharacterPanel;
    [SerializeField] GameObject emptyPanel;
    [SerializeField] GameObject bobPanel;
    [SerializeField] GameObject johnPanel;
    [SerializeField] GameObject menu;

    public void CloseSelectPanel()
    {
        emptyPanel.SetActive(false);
        bobPanel.SetActive(false);
        johnPanel.SetActive(false);
        selectCharacterPanel.SetActive(false);
        menu.SetActive(true);
    }

    public void OpenSelectPanel()
    {
        emptyPanel.SetActive(true);
        bobPanel.SetActive(false);
        johnPanel.SetActive(false);
        selectCharacterPanel.SetActive(true);
        menu.SetActive(false);
    }

    public void OpenBobPanel()
    {
        emptyPanel.SetActive(false);
        bobPanel.SetActive(true);
        johnPanel.SetActive(false);
    }

    public void OpenJohnPanel()
    {
        emptyPanel.SetActive(false);
        bobPanel.SetActive(false);
        johnPanel.SetActive(true);
    }

}
