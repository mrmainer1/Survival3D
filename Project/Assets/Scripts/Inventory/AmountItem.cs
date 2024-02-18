using UnityEngine;
using TMPro;

public class AmountItem : MonoBehaviour
{
    public TMP_Text textAmount;
    private void Start() => textAmount = GetComponent<TMP_Text>();
    public void ChangeAmount(int amount)
    {
        textAmount.text = $"{amount}";
    }
}
