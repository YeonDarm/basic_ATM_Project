using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;

public class BalanceUnit : MonoBehaviour
{
    public TextMeshProUGUI balanceTMPro;

    void Start()
    {
        UpdateBalance();
    }

    public void UpdateBalance()
    {
        int balanceNum = GameManager.Instance.userData.Balance;
        string balanceNumber = Regex.Replace(balanceNum.ToString(), @"(?<=\d)(?=(\d{3})+(?!\d))", ",");
        balanceTMPro.text = balanceNumber;
    }
}
