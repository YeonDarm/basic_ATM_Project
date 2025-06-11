using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System.Collections;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public UserData userData { get; set; }
    // public UserInfo userInfo;

    public UserDatabase userDatabase = new UserDatabase(); // 전체 사용자 목록
    public UserData currentUser { get; set; } // 로그인한 사용자
    public string currentUserID { get; private set; } // 로그인을 위한 ID
    // public int currentUserIndex { get; set; } = -1; // 리스트: 다중 데이터 관리용 인덱스 변수수
    private string saveFilePath; // 저장할 파일 경로
    private string lastSavedJson = ""; // 마지막으로 저장한 파일 Json형태로 보관.


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
    }

    void Start()
    {
        LoadUserData(); //단일 사용자 데이터 처리. >> 다중 사용자 데이터 처리로 변경.

        // if (userInfo == null)
        // {
        //     userInfo = FindAnyObjectByType<UserInfo>();
        // }
        //저장된 Json데이터를 불러온다.
        // userInfo.UserRenew(); // 사용자 데이터를 갱신한다.
        // UserData 프로퍼티에서 값이 변경되면 이벤트 구독으로 항상 바뀌도록 개선.
        // PlayerPrefsLoad(); // 저장/불러오기 2.
    }

    // UserData 개선하면서 정리.
    // GameManager 역할을 좀더 단순화하기 위한 개선.
    /*public void UpdateName(string newName)
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
        userData.Balance += amount; // 값 조정.
        userInfo.UserRenew();       // UI 변화.
    } */
    // 위처럼 값을 변화하는 역할과 UI를 변화하는 역할이 서로 뒤섞여 있음.
    // 버그 발생하기 쉬운 구조.


    //저장 및 로드 기능
    /// <summary>
    /// 전체 사용자 데이터를 JSON파일로 저장.
    /// 다중 데이터를 직렬화 >> 저장 파일 대체한 후 갱신.
    /// 딕셔너리 직렬화.
    /// </summary>
    public void SaveUserData()
    {
        //Formatting.Indented 옵션은 사람이 읽기 쉽게 만듦.
        string currentJson = JsonConvert.SerializeObject(userDatabase, Formatting.Indented); //직렬화화

        if (currentJson == lastSavedJson) return; // 저장 데이터가 같다면 함수 종료.

        try //예외 처리
        {
            //데이터 변경 시 파일에 저장.
            File.WriteAllText(saveFilePath, currentJson); // 저장 파일을 대체해버린다.

            lastSavedJson = currentJson; // JSON 저장 상태 업데이트

            Debug.Log("JSON 데이터 저장 완료: " + saveFilePath);
        }
        catch (Exception ex)
        {
            Debug.LogError("데이터 저장 중 오류 발생: " + ex.Message);
        }
        //파일 입출력 및 비동기 작업은 예상치 못한 오류가 발생한다.
        //따라서 try-catch문으로 예외처리를 한다.
    }

    // public void UpdateCurrentUserData() //리스트: 다중 데이터에 인덱스를 부여한 다음 추가
    // {
    //     if (currentUser != null && currentUserIndex >= 0 && currentUserIndex < userDatabase.Users.Count)
    //     {
    //         userDatabase.Users[currentUserIndex] = currentUser;
    //         SaveUserData();
    //     }
    //     else
    //     {
    //         Debug.LogWarning("현재 사용자 업데이트 오류: 인덱스 또는 currentUser가 유효하지 않음.");
    //     }
    // }

    /// <summary>
    /// JSON 파일에서 사용자 데이터를 불러옴.
    /// </summary>
    public void LoadUserData()
    {
        if (File.Exists(saveFilePath)) // 파일 읽기
        {
            try //예외 처리
            {
                // string jdata = File.ReadAllText(saveFilePath);
                // userDatabase = JsonConvert.DeserializeObject<UserDatabase>(jdata); //단일데이터로 역직렬화해서
                string json = File.ReadAllText(saveFilePath);
                UserDatabase db = JsonConvert.DeserializeObject<UserDatabase>(json);
                
                //db가 null인 경우를 대비.
                userDatabase = db ?? new UserDatabase(); // ??: 병합 연산자(Null-Coalescing Operator) 
                                                         // db가 null이면 오른쪽 값을 반환, 그렇지 않으면 db를 반환.

                //데이터가 덮어씌워지는 버그 발생함. >> 리스트로 데이터 관리했을 때.
                lastSavedJson = json;
                Debug.Log("JSON 데이터 불러오기 완료: " + saveFilePath);
            }
            catch (Exception ex)
            {
                Debug.LogError("사용자 데이터 로드 오류: " + ex.Message);
            }
        }
        else
        {
            Debug.LogWarning("저장된 데이터가 없음.");
            userDatabase = new UserDatabase(); // 새 데이터베이스 생성.
        }
    }

    // PlayerPrefs를 활용한 Save/Load 기능.
    // public void PlayerPrefsSave()
    // {
    //     PlayerPrefs.SetString("Name", userData.UserName);
    //     PlayerPrefs.SetInt("Cash", userData.Cash);
    //     PlayerPrefs.SetString("Balance", userData.Balance.ToString()); // ulong 손실되는 값을 방지하기 위해 문자열로 저장.
    //     PlayerPrefs.Save();

    //     Debug.Log($"PlayerPrefs 저장 확인: Name: {userData.UserName}, Cash: {userData.Cash}, Balance: {userData.Balance}");
    // }

    // public void PlayerPrefsLoad()
    // {
    //     if (PlayerPrefs.HasKey("Name") && PlayerPrefs.HasKey("Cash") && PlayerPrefs.HasKey("Balance"))
    //     {
    //         string name = PlayerPrefs.GetString("Name");
    //         int cash = PlayerPrefs.GetInt("Cash");
    //         ulong balance = ulong.Parse(PlayerPrefs.GetString("Balance")); //Parse로 문자열을 ulong으로 변환.

    //         userData = new UserData(name, cash, balance);
    //         Debug.Log($"PlayerPrefs 불러오기 확인: Name: {name}, Cash: {cash}, Balance: {balance}");
    //     }
    //     else
    //     {
    //         Debug.Log($"UserData 없음.");
    //     }
    // }

    public void SetCurrentUser(string id)
    {
        currentUser = userDatabase.GetUser(id);
    }
}
