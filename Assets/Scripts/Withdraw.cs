using TMPro;
using UnityEngine;

public class Withdraw : MonoBehaviour
{
    public TMP_InputField withdrawInput;

    public void WithdrawAmount(int amount)
    {
        if (amount <= 0) return;

        if (GameManager.Instance.userData.Balance >= (ulong)amount)
        {
            GameManager.Instance.userData.Balance -= (ulong)amount;
            GameManager.Instance.userData.Cash += amount;
            // GameManager.Instance.UpdateCash(amount);
            PopupMessage.Instance.PopupUI(PopupMessage.PopupType.Success);
            GameManager.Instance.SaveUserData();
            // GameManager.Instance.PlayerPrefsSave();
        }
        else
        {
            PopupMessage.Instance.PopupUI(PopupMessage.PopupType.Fail);
        }
    }

    public void WithdrawInputAmount()
    {
        if (int.TryParse(withdrawInput.text, out int amount))
        {
            WithdrawAmount(amount);
            GameManager.Instance.SaveUserData();
            // GameManager.Instance.PlayerPrefsSave();
        }
        else
        {
            PopupMessage.Instance.PopupUI(PopupMessage.PopupType.Error);
            withdrawInput.text = "";
        }

        withdrawInput.text = "";
    }
}
