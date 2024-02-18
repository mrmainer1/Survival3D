using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public CreateCellInInventory createCellInInventory;
    public CreateRecepiesInMenuCraft createRecepiesInMenuCraft;

    public Color activeColor;
    public Color nonActiveColor;
    
    public GameObject mainMenuObject;
    public Image buttonInventory;
    public Image buttonCraftMenu;
    
    public bool isCloseMainMenu = true;
    public int lastOpenMenu;

    public void OpenMainMenu()
    {
        mainMenuObject.SetActive(true); 
        isCloseMainMenu = false;
        GlobalController.GameNotOnPause = false;
        Cursor.visible = true;
        
        switch (lastOpenMenu)
        {
            case 0:
                createCellInInventory.OpenInventory();
                createRecepiesInMenuCraft.CloseCraftMenu();
                
                buttonInventory.color = activeColor;
                buttonCraftMenu.color = nonActiveColor;
                return;
            case 1:
                createRecepiesInMenuCraft.OpenCraftMenu();
                createCellInInventory.CloseInventory();
                
                buttonInventory.color = nonActiveColor;
                buttonCraftMenu.color = activeColor;
                return;
        }
    }

    public void CloseMainMenu()
    {
        Cursor.visible = false;
        mainMenuObject.SetActive(false);   
        isCloseMainMenu = true;
        GlobalController.GameNotOnPause = true;
        createCellInInventory.CloseInventory();
    }

    public void OpenInventory()
    {
        lastOpenMenu = 0;
        OpenMainMenu();
    }

    public void OpenCraftMenu()
    {
        lastOpenMenu = 1;
        OpenMainMenu();
    }
}