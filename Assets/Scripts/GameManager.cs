using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public UserData userData { get; private set; }

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
        }
    }

    void Start()
    {
        userData = new UserData("상연", 100000, 50000);

        Debug.Log("유저 데이터: " + userData.UserName);
        Debug.Log("현금: " + userData.Cash);
        Debug.Log("잔액: " + userData.Balance);
    }
}
