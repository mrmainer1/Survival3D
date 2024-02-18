using UnityEngine;

public class CellOpenMenu : MonoBehaviour
{
    public OpenItemMenu openItemMenuCellMenu;
    public ItemInfo itemInfo;
    public GameObject cellObject;
    public void Open()
    {
        openItemMenuCellMenu.itemMenu.cell = cellObject;
        openItemMenuCellMenu.itemInfo = itemInfo;
        openItemMenuCellMenu.OpenMenuItem();
    }
}
