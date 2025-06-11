using UnityEngine;
using TMPro;

public class TransferManager : MonoBehaviour
{
    [Header("UI 입력 필드")]
    [SerializeField] private TMP_InputField recipientInput; //받는 사람 ID
    [SerializeField] private TextMeshProUGUI feedbackName; //받는 사람 이름
    [SerializeField] private TMP_InputField amountInput; // 송금 금액?

    [SerializeField] private TextMeshProUGUI feedbackText;

    public void OnTransferButton()
    {
        string recipientID = recipientInput.text.Trim();
        if (string.IsNullOrEmpty(recipientID))
        {
            feedbackText.text = "수취인 ID를 입력하세요.";
            return;
        }

        
    }

    
}
