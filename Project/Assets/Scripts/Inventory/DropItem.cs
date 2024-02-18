using UnityEngine;
using System.Linq;

public class DropItem : MonoBehaviour
{
    private ItemMenu itemMenu;
    public PlayerMove playerMove;

    private void Start()
    {
        itemMenu = GetComponentInParent<ItemMenu>();
    }

    public void Drop()
    {
        Item item = playerMove.inventory.items.FirstOrDefault(i => i.itemInfo.id == itemMenu.itemInfo.id);
        Transform player = PlayerMove.playerTransform;

        if (item != null)
        {
            if (item.amount <= 1)
            {
                Destroy(itemMenu.cell);
                playerMove.inventory.items.Remove(item);
                itemMenu.GetComponentInChildren<ExitMenu>().Exit();
                item.amount--;
            }
            else
            {
                item.amount--;
            }
            GameObject createDropItem = Instantiate(itemMenu.itemInfo.prefabs, new Vector3(player.position.x, player.position.y,player.position.z), new Quaternion(30,12,48,0));
            itemMenu.cell.GetComponentInChildren<AmountItem>().ChangeAmount(item.amount);
            
        }
    }
}
