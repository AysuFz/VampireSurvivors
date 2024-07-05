using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupPanelController : MonoBehaviour
{
    [SerializeField] GameObject powerupPanel;
    [SerializeField] GameObject emptyPanel;
    [SerializeField] GameObject hpPanel;
    [SerializeField] GameObject damagePanel;
    [SerializeField] GameObject menu;

    public void ClosePowerupPanel()
    {
        emptyPanel.SetActive(false);
        damagePanel.SetActive(false);
        hpPanel.SetActive(false);
        powerupPanel.SetActive(false);
        menu.SetActive(true);
    }

    public void OpenPowerupPanel()
    {
        emptyPanel.SetActive(true);
        damagePanel.SetActive(false);
        hpPanel.SetActive(false);
        powerupPanel.SetActive(true);
        menu.SetActive(false);
    }

    public void OpenDamagePanel()
    {
        emptyPanel.SetActive(false);
        damagePanel.SetActive(true);
        hpPanel.SetActive(false);
    }

    public void OpenHPPanel()
    {
        emptyPanel.SetActive(false);
        damagePanel.SetActive(false);
        hpPanel.SetActive(true);
    }
}
