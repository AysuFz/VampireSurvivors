using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject loginPanel, signupPanel, profilePanel, forgetPasswordPanel, notificationPanel;
    public InputField loginEmail, loginPassword;
    public InputField signupUsername, signupEmail, signupPassword, signupConfirm;
    public InputField forgetPassEmail;
    public TextMeshProUGUI notificationTitle, notificatioonMessage;
    public TextMeshProUGUI profileUsername, profileUserEmail;
    public Toggle remember;
    
    public void OpenLoginPanel()
    {
        loginPanel.SetActive(true);
        signupPanel.SetActive(false);
        profilePanel.SetActive(false);
        forgetPasswordPanel.SetActive(false);
    }
    
    public void OpenSignupPanel()
    {
        loginPanel.SetActive(false);
        signupPanel.SetActive(true);
        profilePanel.SetActive(false);
        forgetPasswordPanel.SetActive(false);
    }
    
    public void OpenProfilePanel()
    {
        loginPanel.SetActive(false);
        signupPanel.SetActive(false);
        profilePanel.SetActive(true);
        forgetPasswordPanel.SetActive(false);
    }
    
    public void OpenforgetPasswordPanel()
    {
        loginPanel.SetActive(false);
        signupPanel.SetActive(false);
        profilePanel.SetActive(false);
        forgetPasswordPanel.SetActive(true);
    }

    public void LoginUser()
    {
        if (string.IsNullOrEmpty(loginEmail.text) && string.IsNullOrEmpty(loginPassword.text))
        {
            ShowNotificationMessage("Error", "fields empty, please input details!");
            return;
        }
        //DoLogin
    }
    
    public void SignUpUser()
    {
        if (string.IsNullOrEmpty(signupEmail.text) && string.IsNullOrEmpty(signupPassword.text) && string.IsNullOrEmpty(signupUsername.text) && string.IsNullOrEmpty(signupConfirm.text))
        {
            ShowNotificationMessage("Error", "fields empty, please input details!");
            return;
        }
        //DoLogin
    }

    public void ForgetPass()
    {
        if (string.IsNullOrEmpty(forgetPassEmail.text))
        {
            ShowNotificationMessage("Error", "Email is empty or wrong");
            return;
        }
        //DoLogin
    }

    private void ShowNotificationMessage(string title, string message)
    {
        notificationTitle.text = title;
        notificatioonMessage.text = message;
        notificationPanel.SetActive(true);
    }

    public void CloseNotificationMessage()
    {
        notificationTitle.text = "";
        notificatioonMessage.text = "";
        notificationPanel.SetActive(false);
    }

    public void Logout()
    {
        profileUsername.text = "";
        profileUserEmail.text = "";
        OpenLoginPanel();
    }
}
