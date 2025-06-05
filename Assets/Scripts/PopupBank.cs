using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters;

public class PopupBank : MonoBehaviour
{
    [SerializeField] private GameObject deposite;
    [SerializeField] private GameObject withdraw;
    [SerializeField] private Vector2 popupOnPos = new Vector2(0, 0);
    [SerializeField] private Vector2 popupOffPos = new Vector2(0, -924f);
    [SerializeField] private float speed; // 인스펙터에서 조정

    void Start()
    {
        
    }

    public void ActiveUI(GameObject uiObject)
    {
        if (uiObject == null) return;

        bool isActive = !uiObject.activeSelf;
        RectTransform rt = uiObject.GetComponent<RectTransform>();

        if (isActive)
        {
            uiObject.SetActive(true);
            if (rt != null)
            {
                StartCoroutine(PopupUPAnim(rt));
            }
        }
        else
        {
            StartCoroutine(PopupDownAndDisable(uiObject));
        }
    }


    public enum UIType { Deposite, Withdraw }

    public void OpenUI(UIType uiType)
    {
        switch (uiType)
        {
            case UIType.Deposite:
                ActiveUI(deposite);
                break;
            case UIType.Withdraw:
                ActiveUI(withdraw);
                break;
            default:
                Debug.LogWarning("UI를 찾을 수 없습니다.");
                break;
        }
    }


    public IEnumerator PopupUPAnim(RectTransform uiRect)
    {
        while (Vector3.Distance(uiRect.anchoredPosition, popupOnPos) > 0.01f)
        {
            uiRect.anchoredPosition = Vector3.MoveTowards(uiRect.anchoredPosition, popupOnPos, speed * Time.deltaTime);
            yield return null;
        }

        uiRect.anchoredPosition = popupOnPos;
    }

    public IEnumerator PopupDownAnim(RectTransform uiRect)
    {
        while (Vector3.Distance(uiRect.anchoredPosition, popupOffPos) > 0.01f)
        {
            uiRect.anchoredPosition = Vector3.MoveTowards(uiRect.anchoredPosition, popupOffPos, speed * Time.deltaTime);
            yield return null;
        }

        uiRect.anchoredPosition = popupOffPos;
    }

    private IEnumerator PopupDownAndDisable(GameObject uiObject)
    {
        RectTransform rt = uiObject.GetComponent<RectTransform>();
        if (rt != null)
        {
            yield return PopupDownAnim(rt);
        }
        uiObject.SetActive(false);
    }
}
