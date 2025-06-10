using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SignUp : MonoBehaviour
{
    public TMP_InputField inputID;
    public TMP_InputField inputName;
    public TMP_InputField inputPassword;
    public TMP_InputField inputPasswordConfirm;

    public GameObject popupSignUp;
    public GameObject errorPanel;
    public TextMeshProUGUI errorText;

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

        UserData newUser = new UserData(inputID.text, inputPassword.text, inputName.text, 10000, 50000);

        // if (LoginManager.userData != null)
        // {

        // }
    }
}
