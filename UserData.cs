[System.Serializable]
public class UserData
{
    public string username;
    public string password; // hashed-lite (simple for now)

    public UserData(string u, string p)
    {
        username = u;
        password = p;
    }
}
