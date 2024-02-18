using UnityEngine;
using System.Collections;
using TMPro;

public class CookingBonfire : MonoBehaviour, IIinteracting
{
    public float timeForNewFood = 1f;
    public bool foodReady;
    public string status;
    public PlayerMove playerMove;
    public ItemInfo itemInfo;

    public TMP_Text readyText;
    private void Start()
    {
        StartCoroutine(Cooking());
    }
    private void Update()
    {
        readyText.transform.LookAt(playerMove.transform);
        if (foodReady)
        {
            status = "Готово[E]";
        }
        else
        {
            status = "Не готово";
        }
        readyText.gameObject.SetActive(foodReady);
    }
    public IEnumerator Cooking()
    {
            yield return new WaitForSeconds(timeForNewFood);
            foodReady = true;
    }

    public void Interactive(PlayerMove player)
    {
        playerMove.inventory.AddItem(itemInfo);
        foodReady = false;
        StopCoroutine(Cooking());
        StartCoroutine(Cooking());
    }

    public ItemInfo GetItemInfo()
    {
        return itemInfo;
    }
}
