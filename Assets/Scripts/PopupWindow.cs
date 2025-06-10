using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupWindow : MonoBehaviour
{
    [SerializeField] private GameObject signUp;


    public void SignUpWindowUI(GameObject uiObject)
    {
        if (uiObject == null) return;

        bool isActive = !uiObject.activeSelf;
        if (isActive)
        {
            uiObject.SetActive(true);
        }
    }

    public void CancelWindowUI(GameObject uiObject)
    {
        if (uiObject == null) return;

        bool isActive = !uiObject.activeSelf;
        if (!isActive)
        {
            uiObject.SetActive(false);
        }
    }


    public enum UIType { Deposite, Withdraw, SignUp }
    public void OpenUI(UIType uiType)
    {
        switch (uiType)
        {
            case UIType.SignUp:
                SignUpWindowUI(signUp);
                break;
            default:
                Debug.LogWarning("UI를 찾을 수 없습니다.");
                break;
        }
    }
}
