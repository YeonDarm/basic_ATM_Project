using TMPro;
using UnityEngine;

public class Withdraw : MonoBehaviour
{
    public TMP_InputField withdrawInput;

    public void WithdrawAmount(ulong amount)
    {
        if (amount <= 0) return;

        if (GameManager.Instance.userData.balance >= amount)
        {
            GameManager.Instance.userData.balance -= amount;
            GameManager.Instance.UpdateCash((int)amount);
            Debug.Log(amount + " 출금 완료");
        }
        else
        {
            Debug.Log("잔액이 부족합니다.");
        }
    }

    public void WithdrawInputAmount()
    {
        if (ulong.TryParse(withdrawInput.text, out ulong amount))
        {
            WithdrawAmount(amount);
        }
        else
        {
            Debug.LogWarning("유효한 숫자를 입력해주세요.");
            withdrawInput.text = "";
        }

        withdrawInput.text = "";
    }
}
