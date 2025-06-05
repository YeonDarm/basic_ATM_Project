using UnityEngine;
using Newtonsoft.Json;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public UserData userData { get; private set; }
    public UserInfo userInfo;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        userData = new UserData("상연", 100000, 50000);
    }

    void Start()
    {
        if (userInfo == null)
        {
            userInfo = FindAnyObjectByType<UserInfo>();
        }

        // UpdateName("문상연");
        // UpdateCash(500);
        // UpdateBalance(500);
    }

    public void UpdateName(string newName)
    {
        userData.UserName = newName;
        userInfo.UserRenew();
    }

    public void UpdateCash(int amount)
    {
        userData.Cash += amount;
        userInfo.UserRenew();
    }

    public void UpdateBalance(ulong amount)
    {
        userData.Balance += amount;
        userInfo.UserRenew();
    }

    //저장 및 로드 기능
    public void SaveUserData()
    {

    }

    public void LoadUserData()
    {

    }
}
