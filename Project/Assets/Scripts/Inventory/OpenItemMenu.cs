using UnityEngine;

public class OpenItemMenu : MonoBehaviour
{
    [HideInInspector] public GameObject menuObject;
    public PlayerAttack playerAttack;

    public Transform pointMenuItem;
    public ItemMenu itemMenu;
    public ItemInfo itemInfo;
    
    private GameObject oldDefaultMenu;
    public void OpenMenuItem()
    {
        Destroy(oldDefaultMenu);
        GameObject menu = Instantiate(itemMenu.gameObject,transform);

        menu.transform.position = pointMenuItem.position;
        menu.transform.localScale = Vector3.one;

        menu.GetComponent<ItemMenu>().SetItemInfo(itemInfo, playerAttack);
        
        menuObject = menu.GetComponent<ItemMenu>().gameObject;

        if (itemInfo.actionType != ActionType.None)
        {
            menu.GetComponent<ItemMenu>().ActiveAnyAction();
        }
  
        oldDefaultMenu = menu;

    }
}
