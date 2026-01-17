using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AuthUI : MonoBehaviour
{
    [Header("Inputs")]
    public InputField usernameInput;
    public InputField passwordInput;

    [Header("Panels")]
    public GameObject loginPanel;
    public GameObject signupPanel;

    public void Login()
    {
        if (AuthManager.Instance.Login(
            usernameInput.text,
            passwordInput.text))
        {
            SceneManager.LoadScene("MenuScene");
        }
        else
        {
            Debug.Log("Login failed");
        }
    }

    public void SignUp()
    {
        if (AuthManager.Instance.SignUp(
            usernameInput.text,
            passwordInput.text))
        {
            Debug.Log("Signup success");
            SwitchToLogin();
        }
        else
        {
            Debug.Log("User already exists");
        }
    }

    public void SwitchToLogin()
    {
        signupPanel.SetActive(false);
        loginPanel.SetActive(true);
    }

    public void SwitchToSignup()
    {
        loginPanel.SetActive(false);
        signupPanel.SetActive(true);
    }
}
