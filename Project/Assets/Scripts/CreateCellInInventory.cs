using UnityEngine;
using UnityEngine.UI;

public class CreateCellInInventory : MonoBehaviour
{
    public PlayerMove playerMove;
    public GameObject inventoryObject;
    public OpenItemMenu openItemMenu;
    public GameObject cell;
    public void CreateCell()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        foreach (Item item in playerMove.inventory.items)
        {
            GameObject cellCreating = Instantiate(cell, transform);

            CellOpenMenu cellOpenMenu = cellCreating.GetComponent<CellOpenMenu>();
            cellOpenMenu.openItemMenuCellMenu = openItemMenu;
            cellOpenMenu.itemInfo = item.itemInfo; 
            cellOpenMenu.cellObject = cellCreating;
            cellCreating.GetComponent<Image>().sprite = item.itemInfo.icon;
            cellCreating.GetComponentInChildren<AmountItem>().ChangeAmount(item.amount);
            cellOpenMenu.openItemMenuCellMenu.itemMenu.GetComponentInChildren<DropItem>().playerMove = playerMove;
        }
    }

    public void OpenInventory()
    {
        inventoryObject.SetActive(true);
        CreateCell();
    }

    public void CloseInventory()
    {
        inventoryObject.SetActive(false);
        Destroy(openItemMenu.menuObject);
    }
}
