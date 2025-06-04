using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters;

public class PopupBank : MonoBehaviour
{
    [SerializeField] private GameObject deposite;
    [SerializeField] private GameObject withdraw;
    [SerializeField] private Vector3 destination;
    [SerializeField] private float speed = 500f;



    public void ActiveUI(GameObject uiObject)
    {
        if (uiObject == null) return;

        bool isActive = !uiObject.activeSelf;

        deposite?.SetActive(false);
        withdraw?.SetActive(false);

        if (isActive)
        {
            uiObject.SetActive(true);
            StartCoroutine(PopupUPAnim(uiObject.transform));
        }
        else
        {
            StartCoroutine(PopupDownAndDisable(uiObject));
        }

        uiObject.SetActive(isActive);
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


    public IEnumerator PopupUPAnim(Transform uiPos)
    {
        Vector3 target = new Vector3(0, Mathf.Max(destination.y, 0f), 0);

        while (Vector3.Distance(uiPos.position, target) > 0.01f)
        {
            uiPos.position = Vector3.MoveTowards(uiPos.position, target, speed * Time.deltaTime);
            yield return null;
        }

        uiPos.position = target;
    }

    public IEnumerator PopupDownAnim(Transform uiPos)
    {
        Vector3 target = new Vector3(0, Mathf.Max(destination.y, -924f), 0);
        while (Vector3.Distance(uiPos.position, target) > 0.01f)
        {
            uiPos.position = Vector3.MoveTowards(uiPos.position, target, speed * Time.deltaTime);
            yield return null;
        }

        uiPos.position = target;
    }

    private IEnumerator PopupDownAndDisable(GameObject uiObject)
    {
        yield return PopupDownAnim(uiObject.transform);

        uiObject.SetActive(false);
    }
}
