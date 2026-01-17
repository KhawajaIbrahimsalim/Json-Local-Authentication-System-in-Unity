using UnityEngine;
using System.IO;

public class AuthManager : MonoBehaviour
{
    public static AuthManager Instance;
    private string path;

    public bool IsLoggedIn { get; private set; }
    public string CurrentUser { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            path = Application.persistentDataPath + "/user.json";
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool SignUp(string username, string password)
    {
        if (File.Exists(path))
            return false;

        var data = new UserData(username, Hash(password));
        File.WriteAllText(path, JsonUtility.ToJson(data));
        return true;
    }

    public bool Login(string username, string password)
    {
        if (!File.Exists(path))
            return false;

        var json = File.ReadAllText(path);
        var data = JsonUtility.FromJson<UserData>(json);

        if (data.username == username && data.password == Hash(password))
        {
            IsLoggedIn = true;
            CurrentUser = username;
            return true;
        }

        return false;
    }

    string Hash(string input)
    {
        return input.GetHashCode().ToString();
    }
}
