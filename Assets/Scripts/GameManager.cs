using UnityEngine;
using System.IO;
using Newtonsoft.Json;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public UserData userData { get; private set; }
    public UserInfo userInfo;
    private string saveFilePath; // 저장할 파일 경로


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            saveFilePath = Path.Combine(Application.persistentDataPath, "ATMUserData.json");
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
    /// <summary>
    /// 사용자 데이터를 JSON파일로 저장.
    /// </summary>
    public void SaveUserData()
    {
        string jdata = JsonConvert.SerializeObject(userData, Formatting.Indented);
        //Formatting.Indented 옵션은 사람이 읽기 쉽게 만듦.
        File.WriteAllText(saveFilePath, jdata);
        Debug.Log("데이터 저장 완료: " + saveFilePath);
    }

    /// <summary>
    /// JSON 파일에서 사용자 데이터를 불러옴.
    /// </summary>
    public void LoadUserData()
    {
        // 파일 읽기
        string jdata = File.ReadAllText(saveFilePath);
        userData = JsonConvert.DeserializeObject<UserData>(jdata);
        Debug.Log("데이터 불러오기 완료: " + saveFilePath);
    }
}
