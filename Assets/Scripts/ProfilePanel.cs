using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ProfilePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI usernameText;
    [SerializeField] private TextMeshProUGUI emailText;
    [SerializeField] GameObject profilePanel;
    [SerializeField] GameObject menuPanel;
    [SerializeField] DataContainer data;

    public void OpenProfilePanel()
    {
        usernameText.text = data.username;
        emailText.text = data.email;
        profilePanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void CloseProfilePanel()
    {
        profilePanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void LogOut()
    {
        SceneManager.LoadScene("LoginSystem");
    }
}
