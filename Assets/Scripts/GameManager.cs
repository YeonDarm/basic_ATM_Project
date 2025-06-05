using UnityEngine;
using System.IO;
using Newtonsoft.Json;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public UserData userData { get; private set; }
    public UserInfo userInfo;
    private string saveFilePath; // 저장할 파일 경로
    private string lastSavedJson = ""; // 마지막으로 저장한 파일 Json형태로 보관.
    private float saveInterval = 10f; // 자동 저장 주기.
    private float timer = 0f;


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
        LoadUserData();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= saveInterval)
        {
            SaveUserData();
            timer = 0;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            LoadUserData();
        }
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
        string currentJson = JsonConvert.SerializeObject(userData, Formatting.Indented);
        //Formatting.Indented 옵션은 사람이 읽기 쉽게 만듦.

        if (currentJson == lastSavedJson) return;
        
        //데이터 변경 시 파일에 저장.
        File.WriteAllText(saveFilePath, currentJson);
        lastSavedJson = currentJson; // 저장 상태 업데이트

        Debug.Log("데이터 저장 완료: " + saveFilePath);
    }

    /// <summary>
    /// JSON 파일에서 사용자 데이터를 불러옴.
    /// </summary>
    public void LoadUserData()
    {
        if (File.Exists(saveFilePath)) // 파일 읽기
        {
            string jdata = File.ReadAllText(saveFilePath);
            userData = JsonConvert.DeserializeObject<UserData>(jdata);
            lastSavedJson = jdata;
            Debug.Log("데이터 불러오기 완료: " + saveFilePath);
        }
        else
        {
            Debug.LogWarning("저장된 데이터가 없음.");
        }
    }
}
