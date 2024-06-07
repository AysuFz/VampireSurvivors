using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    [SerializeField] GameObject WeaponParent;

    public void GameOver()
    {
        //  Debug.Log("Game over");
        Time.timeScale = 0f;
        GetComponent<PlayerMove>().enabled = false;
        gameOverPanel.SetActive(true);
        WeaponParent.SetActive(false);
        
    }
}
