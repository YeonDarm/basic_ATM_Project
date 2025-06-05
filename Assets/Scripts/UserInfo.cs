using TMPro;
using UnityEngine;


public class UserInfo : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI cashText;
    public TextMeshProUGUI balanceText;


    void Start()
    {
        UserRenew();
    }

    public void UserRenew()
    {
        UserData userData = GameManager.Instance.userData;

        nameText.text = userData.userName;
        cashText.text = string.Format("{0:N0}", userData.cash);
        balanceText.text = string.Format("{0:N0}", userData.balance);
    }
}
