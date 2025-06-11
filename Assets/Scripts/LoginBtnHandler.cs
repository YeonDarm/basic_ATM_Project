using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginBtnHandler : MonoBehaviour
{
    [SerializeField] private InputField loginID;
    [SerializeField] private InputField loginPW;

    public void OnLoginAccessBtn()
    {
        string id = loginID.text;
        string password = loginPW.text;

        if (!LoginManager.Instance.Login(id, password))
        {
            Debug.Log("로그인 실패");
        }
        else
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
