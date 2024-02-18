using UnityEngine;
using System.Linq;
using System.Runtime.CompilerServices;

public class CraftItem : MonoBehaviour
{
    private ViewRecepies viewRecepies;
    public PlayerMove playerMove;

    private Item oneIngridient;
    private Item twoIngridient;
    private Item threeIngridient;
    private void Start()
    {
        viewRecepies = GetComponent<ViewRecepies>();
        playerMove = viewRecepies.playerMove;
    }

    public void Craft()
    {
        if (playerMove.inventory.items.Any(i => i.itemInfo.name == viewRecepies.recepies.oneIngredient.name && i.amount >= viewRecepies.recepies.manyNeedOneIngredient) &&
            playerMove.inventory.items.Any(i => i.itemInfo.name == viewRecepies.recepies.oneIngredient.name && i.amount >= viewRecepies.recepies.manyNeedTwoIngredient) &&
            playerMove.inventory.items.Any(i => i.itemInfo.name == viewRecepies.recepies.oneIngredient.name && i.amount >= viewRecepies.recepies.manyNeedThreeIngredient))
        {

            oneIngridient = playerMove.inventory.items.FirstOrDefault( i => i.itemInfo.id == viewRecepies.recepies.oneIngredient.id);
            twoIngridient = playerMove.inventory.items.FirstOrDefault( i => i.itemInfo.id == viewRecepies.recepies.twoIngredient.id);
            threeIngridient = playerMove.inventory.items.FirstOrDefault( i => i.itemInfo.id == viewRecepies.recepies.threeIngredient.id);


            if (oneIngridient != null && twoIngridient != null && threeIngridient != null)
            {
                    for (int i = 0; i < viewRecepies.recepies.manyNeedOneIngredient; i++)
                    {
                        playerMove.inventory.RemoveItem(oneIngridient.itemInfo);
                    }

                    for (int i = 0; i < viewRecepies.recepies.manyNeedTwoIngredient; i++)
                    {
                        playerMove.inventory.RemoveItem(twoIngridient.itemInfo);
                    }

                    for (int i = 0; i < viewRecepies.recepies.manyNeedThreeIngredient; i++)
                    {
                        playerMove.inventory.RemoveItem(threeIngridient.itemInfo);
                    }

                playerMove.inventory.AddItem(viewRecepies.recepies.product);
                viewRecepies.CreateCellInInventory.CreateCell();
                playerMove.uIController.ShowText($"{viewRecepies.recepies.product.name} в инвентаре");

                oneIngridient = null;
                twoIngridient = null;
                threeIngridient = null;          
            }
        }
        else
        {
            playerMove.uIController.ShowText("Не хватает ингридиентов");
        }

    }
}
    
        
    

   
