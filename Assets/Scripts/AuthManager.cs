using System.Collections;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using TMPro;
using System.Threading.Tasks;
using UnityEditor.VersionControl;
using TMPro.EditorUtilities;
using UnityEditor.Compilation;
using UnityEngine.SceneManagement;

public class AuthManager : MonoBehaviour
{
    [Header("Display")]
    [SerializeField] private TMP_Text usernameDisplayText;
    //[SerializeField] private TMP_Text errorText;


    [Header("Panels")]
    [SerializeField] GameObject warningPanelSignup;
    [SerializeField] GameObject warningPanelLogin;
    [SerializeField] GameObject loginSuccessfull;
    [SerializeField] GameObject loginPanel;
    [SerializeField] GameObject signupPanel;
    [SerializeField] GameObject forgetPasswordPanel;


    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser User;


    [Header("Login")]
    public TMP_InputField emailLoginField;
    public TMP_InputField passwordLoginField;
    public TMP_Text warningLoginText;
    public TMP_Text confirmLoginText;


    [Header("Register")]
    public TMP_InputField usernameRegisterField;
    public TMP_InputField emailRegisterField;
    public TMP_InputField passwordRegisterField;
    public TMP_InputField passwordRegisterVerifyField;
    public TMP_Text warningRegisterText;


    private void Start()
    {
        StartCoroutine(CheckAndFixDependenciesAsync());
    }


    private IEnumerator CheckAndFixDependenciesAsync()
    {
        var dependencyTask = FirebaseApp.CheckAndFixDependenciesAsync();
        yield return new WaitUntil(() => dependencyTask.IsCompleted);

        dependencyStatus = dependencyTask.Result;
        if (dependencyStatus == DependencyStatus.Available)
        {
            //If they are avalible Initialize Firebase
            InitializeFirebase();
        }
        else
        {
            Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
        }
    }


    private void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase Auth");
        //Set the authentication instance object
        auth = FirebaseAuth.DefaultInstance;
    }


    //private IEnumerator CheckForAutoLogin()
    //{
    //    if (User != null) 
    //    {
    //        var reloadUserTask = User.ReloadAsync();
    //        yield return new WaitUntil(() => reloadUserTask.IsCompleted);
    //        AutoLogin();
    //    }
    //    else
    //    {
     //       Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
    //    }
    //}


    //private void AutoLogin()
    //{
    //   if (User != null) 
    //    {
    //        ReferencesOptions.userName = User.DisplayName;
    //        SceneManager.LoadScene("GameScene");
    //    }
    //   else
    //    {
    //        Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
    //    }
    //}



    public void LoginButton()
    {
        StartCoroutine(Login(emailLoginField.text, passwordLoginField.text));
    }
 

    public void RegisterButton()
    {
        StartCoroutine(Register(emailRegisterField.text, passwordRegisterField.text, usernameRegisterField.text));
    }


    private IEnumerator Login(string _email, string _password)
    {
        //Call the Firebase auth signin function passing the email and password
        Task<AuthResult> LoginTask = auth.SignInWithEmailAndPasswordAsync(_email, _password);
        //Wait until the task completes
        yield return new WaitUntil(predicate: () => LoginTask.IsCompleted);

        if (LoginTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {LoginTask.Exception}");
            FirebaseException firebaseEx = LoginTask.Exception.GetBaseException() as FirebaseException;
            AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

            string message = "Login Failed!";
            switch (errorCode)
            {
                case AuthError.MissingEmail:
                    message = "Missing Email";
                    break;
                case AuthError.MissingPassword:
                    message = "Missing Password";
                    break;
                case AuthError.WrongPassword:
                    message = "Wrong Password";
                    break;
                case AuthError.InvalidEmail:
                    message = "Invalid Email";
                    break;
                case AuthError.UserNotFound:
                    message = "Account does not exist";
                    break;
            }
            warningLoginText.text = message;
            warningPanelLogin.SetActive(true);
            loginPanel.SetActive(false);
        }
        else
        {
            //User logged in
            User = LoginTask.Result.User;
            Debug.LogFormat("User signed in successfully: {0} ({1})", User.DisplayName, User.Email);
            warningLoginText.text = "";
            confirmLoginText.text = "Logged In";
            if (usernameDisplayText != null)
            {
                usernameDisplayText.text = $"Welcome, {User.DisplayName}!";
            }
            loginPanel.SetActive(false);
            loginSuccessfull.SetActive(true);

        }
    }

    private IEnumerator Register(string _email, string _password, string _username)
    {
        if (_username == "")
        {
            warningRegisterText.text = "Missing Username";
        }
        else if (passwordRegisterField.text != passwordRegisterVerifyField.text)
        {
            warningRegisterText.text = "Password Does Not Match!";
        }
        else
        {
            Task<AuthResult> RegisterTask = auth.CreateUserWithEmailAndPasswordAsync(_email, _password);
            //Wait until the task completes
            yield return new WaitUntil(predicate: () => RegisterTask.IsCompleted);

            if (RegisterTask.Exception != null)
            {
                //If there are errors handle them
                Debug.LogWarning(message: $"Failed to register task with {RegisterTask.Exception}");
                FirebaseException firebaseEx = RegisterTask.Exception.GetBaseException() as FirebaseException;
                AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

                string message = "Register Failed!";
                switch (errorCode)
                {
                    case AuthError.MissingEmail:
                        message = "Missing Email";
                        break;
                    case AuthError.MissingPassword:
                        message = "Missing Password";
                        break;
                    case AuthError.WeakPassword:
                        message = "Weak Password";
                        break;
                    case AuthError.EmailAlreadyInUse:
                        message = "Email Already In Use";
                        break;
                }
                warningRegisterText.text = message;
                warningPanelSignup.SetActive(true);
                signupPanel.SetActive(false);
            }
            else
            {
                //User has now been created
                //Now get the result
                User = RegisterTask.Result.User;

                if (User != null)
                {
                    UserProfile profile = new UserProfile { DisplayName = _username };
                    var ProfileTask = User.UpdateUserProfileAsync(profile);
                    yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);

                    if (ProfileTask.Exception != null)
                    {
                        Debug.LogWarning(message: $"Failed to register task with {ProfileTask.Exception}");
                        FirebaseException firebaseEx = ProfileTask.Exception.GetBaseException() as FirebaseException;
                        AuthError errorCode = (AuthError)firebaseEx.ErrorCode;
                        warningRegisterText.text = "Username Set Failed!";
                    }
                    else
                    {
                        //return to login panel
                        CloseSignupPanel();
                        warningRegisterText.text = "";
                    }
                }
            }
        }
    }


    public void CloseSignupPanel()
    {
        signupPanel.SetActive(false);
        loginPanel.SetActive(true);
    }

    public void CloseSignupErrorPanel()
    {
        warningPanelSignup.SetActive(false);
        signupPanel.SetActive(true);
    }

    public void CloseLoginErrorPanel()
    {
        warningPanelLogin.SetActive(false);
        loginPanel.SetActive(true);
    }

    public void CloseloginSuccessfull()
    {
        loginSuccessfull.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenRegisterPanel()
    {
        loginPanel.SetActive(false);
        signupPanel.SetActive(true);
    }

    public void CloseRegisterPanel()
    {
        loginPanel.SetActive(true);
        signupPanel.SetActive(false);
    }


    public void OpenForgetPassword()
    {
        loginPanel.SetActive(false);
        forgetPasswordPanel.SetActive(true);
    }

    public void CloseForgetPassword()
    {
        loginPanel.SetActive(true);
        forgetPasswordPanel.SetActive(false);
    }

}