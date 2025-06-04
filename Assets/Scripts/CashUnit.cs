using System.Text.RegularExpressions;
using System.Collections;
using UnityEngine;
using TMPro;


public class CashUnit : MonoBehaviour
{
    public TextMeshProUGUI cashTMPro;
    public TextMeshProUGUI balanceTMPro;

    void Start()
    {
        //null레퍼런스 방어용.
        StartCoroutine(WaitForUpdata());
    }

    public void UpdateBalance()
    {
        ulong balanceNum = GameManager.Instance.userData.Balance;
        string balanceNumber = Regex.Replace(balanceNum.ToString(), @"(?<=\d)(?=(\d{3})+(?!\d))", ",");
        balanceTMPro.text = balanceNumber;
    }

    public void UpdateCash()
    {
        int cashNum = GameManager.Instance.userData.Cash;
        string cashNumber = Regex.Replace(cashNum.ToString(), @"(?<=\d)(?=(\d{3})+(?!\d))", ",");
        cashTMPro.text = cashNumber;
    }

    IEnumerator WaitForUpdata()
    {
        yield return new WaitForSeconds(0.5f);

        if (GameManager.Instance.userData != null)
        {
            UpdateBalance();
            UpdateCash();
        }
    }
}
