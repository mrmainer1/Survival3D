using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemMenu : MonoBehaviour
{
    public GameObject cell;
    public ItemInfo itemInfo;
    public PlayerAttack playerAttack;
   
    public TMP_Text nameItem;
    public TMP_Text description;
    public TMP_Text buttonAnyAction;
    public GameObject anyAction;

    public void SetItemInfo(ItemInfo info, PlayerAttack attack )
    {
        nameItem.text = info.name;
        description.text = info.description;
        itemInfo = info;
        playerAttack = attack;
    }

    public void ActiveAnyAction()
    {
        anyAction.SetActive(true);

        switch (itemInfo.actionType)
        {
            case ActionType.Eat:
                buttonAnyAction.text = "Съесть";
                break;
            case ActionType.Weapon:
                buttonAnyAction.text = "Экипировать";
                break;
            case ActionType.Build:
                buttonAnyAction.text = "Построить";
                break;

        }
    }
}