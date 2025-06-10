using TMPro;
using UnityEngine;

public class Deposite : MonoBehaviour
{
    public TMP_InputField depositInput;

    public void DepositAmount(int amount)
    {
        if (GameManager.Instance.currentUser == null || amount <= 0) return;

        if (GameManager.Instance.currentUser.Cash >= amount)
            {
                GameManager.Instance.currentUser.Cash -= amount;
                GameManager.Instance.currentUser.Balance += (ulong)amount;
                // GameManager.Instance.UpdateBalance((ulong)amount);
                PopupMessage.Instance.PopupUI(PopupMessage.PopupType.Success);
                GameManager.Instance.UpdateCurrentUserData();
                // GameManager.Instance.PlayerPrefsSave();
            }
            else
            {
                PopupMessage.Instance.PopupUI(PopupMessage.PopupType.Fail);
            }
    }

    public void DepositInputAmount()
    {
        if (int.TryParse(depositInput.text, out int amount))
        {
            DepositAmount(amount);
            GameManager.Instance.SaveUserData();
            // GameManager.Instance.PlayerPrefsSave();
        }
        else
        {
            PopupMessage.Instance.PopupUI(PopupMessage.PopupType.Error);
            depositInput.text = "";
        }

        depositInput.text = "";
    }
}
