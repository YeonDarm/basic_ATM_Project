using TMPro;
using UnityEngine;


public class UserInfo : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI cashText;
    public TextMeshProUGUI balanceText;

    private UserData userData;

    // 캐싱 기법? >> 잘 모르겠음.
    // 값이 변경할 때만 갱신하게 할 변수들.
    // private string prevUserName = "";
    // private int prevCash = -1;
    // private ulong prevBalance = 0;

    private void Start()
    {
        userData = GameManager.Instance.currentUser;
        if (userData != null)
        {
            // UserData에 프로퍼티에서 등록한 이벤트로 자동으로 UserRenew 구독.
            userData.OnUserDataChanged += UserRenew;
            UserRenew();
        }
        else
        {
            Debug.LogWarning("UserData가 할당되지 않음.");
        }
    }

    //입출금UI 에서 변경하고 있음.
    //UserData에 프로퍼티로 값이 변경되면 동시에 변경되도록 조정함.
    // void Update()
    // {
    //     UserRenew(); //값이 변경될 때만 호출. >> 수정 필요
    // }

    //유저 인포에서 UI업데이트는 이상하다.
    //데이터는 데이터만. 저장은 저장. 출력은 출력만 역할을 나눠서 관리.
    public void UserRenew()
    {
        if (userData == null)
        {
            Debug.LogWarning("UserRenew 호출했지만 userData가 null.");
            return;
        }

        nameText.text = userData.UserName;
        cashText.text = string.Format("{0:N0}", userData.Cash);
        balanceText.text = string.Format("{0:N0}", userData.Balance);
    }

    private void OnDestroy()
    {
        if (userData != null)
        {
            userData.OnUserDataChanged -= UserRenew;
        }
    }
}
