using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;


public class LoginManager : MonoBehaviour
{
    public UserData userData { get; set; }

    //ID랑 PW 입력 필드 할당용
    [SerializeField] private TMP_InputField idInput;
    [SerializeField] private TMP_InputField passwordInput;

    // 메시지 출력 UI
    [SerializeField] private TextMeshProUGUI feedbackText;

    private string saveFilePath;


    private void Awake()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "ATMUserData.json");
    }

    public void LoginUser()
    {
        //json파일 존재하는지 확인.
        if (!File.Exists(saveFilePath))
        {
            feedbackText.text = "저장된 사용자 데이터가 없습니다.";
            return;
        }

        try
        {
            //json에서 데이터를 읽어와 저장.
            string jsonContent = File.ReadAllText(saveFilePath);

            // 저장한 json 데이터를 리스트로 역직렬화.
            UserDatabase loadedDatabase = JsonConvert.DeserializeObject<UserDatabase>(jsonContent);

            if (loadedDatabase == null || loadedDatabase.Users == null || loadedDatabase.Users.Count == 0) // 데이터가 없다면.
            {
                feedbackText.text = "사용자 데이터가 없습니다.";
                return;
            }

            // inputField에 입력한 값을 저장.
            string inputID = idInput.text;
            string inputPW = passwordInput.text;

            // 람다식으로 리스트를 순회하면서 ID/PW 모두 일치하는 사용자를 찾음.
            UserData foundUser = loadedDatabase.Users.Find (
                u => u.id == inputID && u.password == inputPW
            );

            // if (foundUser.id == inputID && foundUser.password == inputPW) // 일치하는 사용자가 있다면(로그인 성공)
            // {
            //     // UpdateUI();
            //     feedbackText.text = "로그인 성공!";
            //     Debug.Log("로그인 성공: " + foundUser.UserName);
            //     userData = foundUser;
            //     SceneManager.LoadScene("MainScene");
            // }
            if (foundUser != null)
            {
                feedbackText.text = "로그인 성공!";
                // 로그인 시, GameManager에 전체 데이터와 현재 사용자를 등록.
                GameManager.Instance.userDatabase = loadedDatabase;
                GameManager.Instance.currentUser = foundUser;
                GameManager.Instance.currentUserIndex = loadedDatabase.Users.IndexOf(foundUser);
                SceneManager.LoadScene("MainScene");
            }
            else // 없다면(로그인 실패)
            {
                feedbackText.text = "아이디 또는 비밀번호가 일치하지 않습니다.";
                // Debug.LogWarning("로그인 실패: 일치하는 사용자 없음");
            }
        }
        //파일이 없거나 JSON형식이 깨진 경우.
        catch (System.Exception e)
        {
            feedbackText.text = "로그인 오류 발생: " + e.Message;
            // Debug.LogError("로그인 오류: " + e.Message);
        }
    }
}
