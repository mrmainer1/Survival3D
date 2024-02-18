using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class AnyAction : MonoBehaviour
{
    public ItemMenu itemMenu;
    private Button button;

    private void Start()
    {
        itemMenu = GetComponentInParent<ItemMenu>();
        button = GetComponentInChildren<Button>();
  
        switch (itemMenu.itemInfo.actionType)
        {
            case ActionType.None:
                break;
            case ActionType.Eat:
                button.onClick.AddListener(EatItem);
                break;
            case ActionType.Weapon:
                button.onClick.AddListener(EquipWeapon);
                break;
            case ActionType.Build:
                button.onClick.AddListener(EqiupBuildItem);
                break;
        }
    }
    public void EatItem()
    {
        Player player = itemMenu.playerAttack.GetComponent<Player>();
        Inventory inventory = itemMenu.playerAttack.GetComponentInChildren<PlayerMove>().inventory;
        Item item = inventory.items.FirstOrDefault(i => i.itemInfo.id == itemMenu.itemInfo.id);

        if(item != null)
        {
            if (item.amount <= 1)
            {
                Destroy(itemMenu.cell);
                inventory.items.Remove(item);
                itemMenu.GetComponentInChildren<ExitMenu>().Exit();
            }
            else
            {
                item.amount--;
            }
            player.AddHealth(item.itemInfo.valueAddHealth);
            player.RemoveHunger(item.itemInfo.valueAddHunger);
            itemMenu.GetComponentInChildren<ExitMenu>().Exit();
            itemMenu.cell.GetComponentInChildren<AmountItem>().ChangeAmount(item.amount);
        }
    }


    public void EqiupBuildItem()
    {
        Inventory inventory = itemMenu.playerAttack.GetComponentInChildren<PlayerMove>().inventory;
        Item item = inventory.items.FirstOrDefault(i => i.itemInfo.id == itemMenu.itemInfo.id);

        if (item != null && GlobalController.ItemInArm == ItemInArm.None)
        {
            if (item.amount <= 1)
            {
                Destroy(itemMenu.cell);
                inventory.items.Remove(item);
                itemMenu.GetComponentInChildren<ExitMenu>().Exit();
            }
            else
            {
                item.amount--;
            }
            itemMenu.playerAttack.GetComponent<BuildObject>().SetConstructionZone(itemMenu.itemInfo);
            itemMenu.GetComponentInChildren<ExitMenu>().Exit();
            itemMenu.cell.GetComponentInChildren<AmountItem>().ChangeAmount(item.amount);

        }
    }
    public void EquipWeapon()
    {
        Inventory inventory = itemMenu.playerAttack.GetComponentInChildren<PlayerMove>().inventory;
        Item item = inventory.items.FirstOrDefault(i => i.itemInfo.id == itemMenu.itemInfo.id);

        if (item != null && GlobalController.ItemInArm == ItemInArm.None)
        {
            if (item.amount <= 1)
            {
                Destroy(itemMenu.cell);
                inventory.items.Remove(item);
                itemMenu.GetComponentInChildren<ExitMenu>().Exit();
            }
            else
            {
                item.amount--;
            }
            itemMenu.playerAttack.SetWeapon(itemMenu.itemInfo);
            itemMenu.GetComponentInChildren<ExitMenu>().Exit();
            itemMenu.cell.GetComponentInChildren<AmountItem>().ChangeAmount(item.amount);

        }
    }
}