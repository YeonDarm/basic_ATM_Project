using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class CashUnit : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    int number;

    void Start()
    {
        string regularNumber = Regex.Replace(number.ToString(), @"(?<=\d)(?=(\d{3})+(?!\d))", ",");
        textMeshPro.text = regularNumber;
    }
}
