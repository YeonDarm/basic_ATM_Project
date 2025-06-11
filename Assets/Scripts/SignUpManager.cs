using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using System;

public class SignUpManager : MonoBehaviour
{
    public TMP_InputField inputID;
    public TMP_InputField inputName;
    public TMP_InputField inputPassword;
    public TMP_InputField inputPasswordConfirm;

    public GameObject popupSignUp;
    public GameObject errorPanel;
    public TextMeshProUGUI errorText;
    public TextMeshProUGUI signUpText;


    /// <summary>
    /// 유효성 검사 > 계정 생성 > UI 비활성 > Json파일로 저장.
    /// </summary>
    public void SignUpUI()
    {
        if (string.IsNullOrWhiteSpace(inputID.text))
        {
            errorText.text = "ID를 확인해주세요.";
            errorPanel.SetActive(true);
            return;
        }
        if (string.IsNullOrWhiteSpace(inputName.text))
        {
            errorText.text = "Name을 확인해주세요.";
            errorPanel.SetActive(true);
            return;
        }
        if (string.IsNullOrWhiteSpace(inputPassword.text))
        {
            errorText.text = "Password를 확인해주세요.";
            errorPanel.SetActive(true);
            return;
        }
        if (string.IsNullOrWhiteSpace(inputPasswordConfirm.text))
        {
            errorText.text = "Password Confirm을 확인해주세요.";
            errorPanel.SetActive(true);
            return;
        }
        if (inputPassword.text != inputPasswordConfirm.text)
        {
            errorText.text = "Password가 일치하지 않습니다.";
            errorPanel.SetActive(true);
            return;
        }

        //계정 생성.
        UserData newUser = new UserData(inputID.text, inputPassword.text, inputName.text, 10000, 50000);

        //GameManager를 통해 UserData 할당.
        // if (GameManager.Instance != null) //
        // {
        //     GameManager.Instance.userDatabase.AddUser(newUser);
        //     // GameManager.Instance.currentUser = newUser;
        //     // GameManager.Instance.currentUserIndex = GameManager.Instance.userDatabase.Users.Count - 1;
        // }
        // else
        // {
        //     Debug.LogWarning("GameManager 인스턴스를 찾을 수 없음.");
        // }
        
        
        try
        {
            LoginManager.Instance.SignUp(inputID.text, inputPassword.text, inputName.text);
            signUpText.text = "회원 가입 완료.";
            Invoke(nameof(DisableSignUpPopup), 0.5f);
        }
        catch (Exception ex)
        {
            errorText.text = ex.Message;
            errorPanel.SetActive(true);
        }
    }

    public void DisableSignUpPopup()
    {
        popupSignUp.SetActive(false);
    }
}
