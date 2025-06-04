using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;
using System.Collections;

public class BalanceUnit : MonoBehaviour
{
    public TextMeshProUGUI balanceTMPro;

    // void Start()
    // {
    //     StartCoroutine(UpdateBalance());
    // }

    // IEnumerator UpdataBalance()
    // {
    //     yield return new WaitForSeconds(0.5f);
    //     int balanceNum = GameManager.Instance.userData.Balance;
    //     string balanceNumber = Regex.Replace(balanceNum.ToString(), @"(?<=\d)(?=(\d{3})+(?!\d))", ",");
    //     balanceTMPro.text = balanceNumber;
    // }
}
