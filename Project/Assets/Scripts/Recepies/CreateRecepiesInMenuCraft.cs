using UnityEngine;

public class CreateRecepiesInMenuCraft : MonoBehaviour
{
    public GameObject craftMenu;
    public bool isMenuCraftClose = true;
    public Transform parentTransform;
    public RectTransform contextTransform;
    public PlayerMove playerMove;
    public GameObject recepiesMenuObject;
    public CreateCellInInventory createCellInInventory;

    private RecepiesInfo[] recepiesInfo;

    private void Start()
    {
        CreateRecepies();
    }
    private void CreateRecepies()
    {
        recepiesInfo = Resources.LoadAll<RecepiesInfo>("ScriptableObject/Recepies");

        foreach(RecepiesInfo recepies in recepiesInfo)
        {
            GameObject newRecepiesMenu = Instantiate(recepiesMenuObject, parentTransform);
            newRecepiesMenu.GetComponent<ViewRecepies>().SetRecepies(recepies, playerMove,createCellInInventory);
            contextTransform.sizeDelta = new Vector2(0,contextTransform.sizeDelta.y + 110f);
        }
    }

    public void OpenCraftMenu()
    {
        craftMenu.SetActive(true);
        isMenuCraftClose = false;
    }

    public void CloseCraftMenu()
    {
        craftMenu.SetActive(false);
        isMenuCraftClose = true;
    }
}
