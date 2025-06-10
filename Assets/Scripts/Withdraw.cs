using TMPro;
using UnityEngine;

public class Withdraw : MonoBehaviour
{
    public TMP_InputField withdrawInput;

    public void WithdrawAmount(int amount)
    {
        if (GameManager.Instance.currentUser == null || amount <= 0) return;

        if (GameManager.Instance.currentUser.Balance >= (ulong)amount)
        {
            GameManager.Instance.currentUser.Balance -= (ulong)amount;
            GameManager.Instance.currentUser.Cash += amount;
            // GameManager.Instance.UpdateCash(amount);
            PopupMessage.Instance.PopupUI(PopupMessage.PopupType.Success);
            GameManager.Instance.UpdateCurrentUserData();
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
            GameManager.Instance.UpdateCurrentUserData();
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
