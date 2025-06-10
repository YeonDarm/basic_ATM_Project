using System.Text.RegularExpressions;
using System.Collections;
using UnityEngine;
using TMPro;


public class CashUnit : MonoBehaviour
{
    public TextMeshProUGUI cashTMPro;
    public TextMeshProUGUI balanceTMPro;
    public int cash; // 현금
    public ulong balance; // 은행 잔액

    void Start()
    {
        cashTMPro.text = string.Format("{0:N0}", cash);
        balanceTMPro.text = string.Format("{0:N0}", balance);
    }
}
