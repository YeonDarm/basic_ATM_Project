using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;


public class LoginManager : MonoBehaviour
{
    // public UserData userData { get; set; }
    public static LoginManager Instance; // 로그인 매니져 싱글톤.
    private GameManager gameManager;

    //ID랑 PW 입력 필드 할당용
    [SerializeField] private TMP_InputField idInput;
    [SerializeField] private TMP_InputField passwordInput;

    // 메시지 출력 UI
    [SerializeField] private TextMeshProUGUI feedbackText;

    // private string saveFilePath; // 게임매니져 개선 이전 사용하던 변수.


    private void Awake()
    {
        // saveFilePath = Path.Combine(Application.persistentDataPath, "ATMUserData.json");
        gameManager = GameManager.Instance;
        if (gameManager == null)
        {
            Debug.LogError("GameManager 인스턴스가 필요.");
        }

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SignUp(string id, string password, string name, int cash = 10000, ulong balance = 50000)
    {
        try
        {
            UserData newUser = new UserData(id, password, name, cash, balance);
            gameManager.userDatabase.AddUser(newUser);
            gameManager.SetCurrentUser(id);
            gameManager.SaveUserData();
        }
        catch (Exception ex)
        {
            Debug.LogError("회원가입 오류: " + ex.Message);
        }
    }

    public bool Login(string id, string password)
    {
        UserData user = gameManager.userDatabase.GetUser(id);
        if (user != null && user.password == password)
        {
            gameManager.SetCurrentUser(id);
            Debug.Log($"로그인 성공: {id}");
            return true;
        }
        else
        {
            Debug.LogWarning("로그인 실패: 잘못된 아이디 또는 비밀번호");
            return false;
        }
    }

    public void OnLoginButtonClicked()
    {
        string id = idInput.text;
        string pw = passwordInput.text;

        bool result = Login(id, pw);

        if (result)
        {
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            Debug.Log("로그인 실패: ID 또는 PW를 확인 해주세요.");
        }
    }

    //현재 사용자 정보 수정 후 저장.
    public void UpdateUserInfo(UserData updatedUser)
    {
        if (updatedUser == null)
        {
            Debug.LogError("UpdateUserInfo 오류: updatedUser가 null입니다.");
            return;
        }

        if (gameManager.userDatabase.ContainsUser(updatedUser.id))
        {
            gameManager.userDatabase.Users[updatedUser.id] = updatedUser;
            gameManager.currentUser = updatedUser;
            gameManager.SaveUserData();
            Debug.Log("사용자 정보 업데이트 성공");
        }
        else
        {
            Debug.LogWarning("업데이트 오류: 사용자 데이터가 존재하지 않습니다.");
        }
    }

    // 데이터를 리스트로 관리했을 때
    // 딕셔너리 관리 후 부분 수정보다 전부 주석 처리.
    // 다중 데이터를 역직렬화한 후 InputField 값을 리스트 + 인덱스로 추가한 다음, 직렬화.
    // 그 다음 로그인 성공 메시지화 씬 이동 기능까지 들어가 있음.
    // public void LoginUser()
    // {
    //     //json파일 존재하는지 확인.
    //     if (!File.Exists(saveFilePath))
    //     {
    //         feedbackText.text = "저장된 사용자 데이터가 없습니다.";
    //         return;
    //     }

    //     try
    //     {
    //         //json에서 데이터를 읽어와 저장.
    //         string jsonContent = File.ReadAllText(saveFilePath);

    //         // 저장한 json 데이터를 리스트로 역직렬화.
    //         UserDatabase loadedDatabase = JsonConvert.DeserializeObject<UserDatabase>(jsonContent);

    //         if (loadedDatabase == null || loadedDatabase.Users == null || loadedDatabase.Users.Count == 0) // 데이터가 없다면.
    //         {
    //             feedbackText.text = "사용자 데이터가 없습니다.";
    //             return;
    //         }

    //         // inputField에 입력한 값을 저장.
    //         string inputID = idInput.text;
    //         string inputPW = passwordInput.text;

    //         // 람다식으로 리스트를 순회하면서 ID/PW 모두 일치하는 사용자를 찾음.
    //         // UserData foundUser = loadedDatabase.Users.Find (
    //         //     u => u.id == inputID && u.password == inputPW
    //         // );

    //         // if (foundUser.id == inputID && foundUser.password == inputPW) // 일치하는 사용자가 있다면(로그인 성공)
    //         // {
    //         //     // UpdateUI();
    //         //     feedbackText.text = "로그인 성공!";
    //         //     Debug.Log("로그인 성공: " + foundUser.UserName);
    //         //     userData = foundUser;
    //         //     SceneManager.LoadScene("MainScene");
    //         // }
    //         if (foundUser != null)
    //         {
    //             feedbackText.text = "로그인 성공!";
    //             // 로그인 시, GameManager에 전체 데이터와 현재 사용자를 등록.
    //             GameManager.Instance.userDatabase = loadedDatabase;
    //             // GameManager.Instance.currentUser = foundUser;
    //             // GameManager.Instance.currentUserIndex = loadedDatabase.Users.IndexOf(foundUser);
    //             SceneManager.LoadScene("MainScene");
    //         }
    //         else // 없다면(로그인 실패)
    //         {
    //             feedbackText.text = "아이디 또는 비밀번호가 일치하지 않습니다.";
    //             // Debug.LogWarning("로그인 실패: 일치하는 사용자 없음");
    //         }
    //     }
    //     //파일이 없거나 JSON형식이 깨진 경우.
    //     catch (System.Exception e)
    //     {
    //         feedbackText.text = "로그인 오류 발생: " + e.Message;
    //         // Debug.LogError("로그인 오류: " + e.Message);
    //     }
}
