using TMPro;
using UnityEngine;

public class PopupMessage : MonoBehaviour
{
    public GameObject popupSuccess;
    public GameObject popupFail;
    public GameObject popupError;
    
    //현재 활성화된 오브젝트 추적용 변수
    private GameObject currentPopup;



    public void ActivePopup(GameObject popupObject)
    {
        if (popupObject == null) return;

        bool isActive = !popupObject.activeSelf;

        HideAllPopups();

        if (isActive)
        {
            popupObject.SetActive(true);
            currentPopup = popupObject;
            Invoke(nameof(DisablePopup), 1.5f);
        }
    }


    public enum PopupType { Success, Fail, Error }
    public void PopupUI(PopupType popupType)
    {
        switch (popupType)
        {
            case PopupType.Success:
                ActivePopup(popupSuccess);
                break;
            case PopupType.Fail:
                ActivePopup(popupFail);
                break;
            case PopupType.Error:
                ActivePopup(popupError);
                break;
            default:
                break;
        }
    }

    public void HideAllPopups()
    {
        if (popupSuccess != null)
        {
            popupSuccess.SetActive(false);
        }
        if (popupFail != null)
        {
            popupFail.SetActive(false);
        }
        if (popupError != null)
        {
            popupError.SetActive(false);
        }
    }

    public void DisablePopup()
    {
        if (currentPopup != null)
        {
            currentPopup.SetActive(false);
            currentPopup = null;
        }
    }
}
