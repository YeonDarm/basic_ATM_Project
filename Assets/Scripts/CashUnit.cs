using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class CashUnit : MonoBehaviour
{
    public TextMeshProUGUI cashTMPro;

    void Start()
    {
        UpdateCash();
    }
    
    public void UpdateCash()
    {
        int cashNum = GameManager.Instance.userData.Cash;
        string cashNumber = Regex.Replace(cashNum.ToString(), @"(?<=\d)(?=(\d{3})+(?!\d))", ",");
        cashTMPro.text = cashNumber;
    }
}
