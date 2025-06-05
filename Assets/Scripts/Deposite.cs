using TMPro;
using UnityEngine;

public class Deposite : MonoBehaviour
{
    public TMP_InputField depositInput;

    public void DepositAmount(int amount)
    {
        if (amount <= 0) return;

        if (GameManager.Instance.userData.cash >= amount)
        {
            GameManager.Instance.userData.cash -= amount;
            GameManager.Instance.UpdateBalance((ulong)amount);
            Debug.Log(amount + " 입금 완료");
        }
        else
        {
            Debug.Log("잔액이 부족합니다.");
        }
    }

    public void DepositInputAmount()
    {
        if (int.TryParse(depositInput.text, out int amount))
        {
            DepositAmount(amount);
        }
        else
        {
            Debug.LogWarning("유효한 숫자를 입력해주세요.");
            depositInput.text = "";
        }

        depositInput.text = "";
    }
}
