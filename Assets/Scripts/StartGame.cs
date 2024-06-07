using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void StartGameplay()
    {
        SceneManager.LoadScene("GameplayStage");
        Enemy.deadEnemiesCount = 0;
        Time.timeScale = 1f;
    }
}
