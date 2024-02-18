using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ViewRecepies : MonoBehaviour
{
    public RecepiesInfo recepies;
    public PlayerMove playerMove;
    public CreateCellInInventory CreateCellInInventory;

    public Image productImage;

    public Image oneIngridientImage;
    public Image twoIngridientImage;
    public Image threeIngridientImage;

    public TMP_Text manyNeedOneingridietText;
    public TMP_Text manyNeedTwoingridietText;
    public TMP_Text manyNeedThreeingridietText;

    public void SetRecepies(RecepiesInfo recepiesInfo, PlayerMove player, CreateCellInInventory createCellInInventory)
    {
        recepies = recepiesInfo;
        playerMove = player;
        CreateCellInInventory = createCellInInventory;
        productImage.sprite = recepies.product.icon;

        oneIngridientImage.sprite = recepies.oneIngredient.icon;
        twoIngridientImage.sprite = recepies.twoIngredient.icon;
        threeIngridientImage.sprite = recepies.threeIngredient.icon;

        manyNeedOneingridietText.text = recepies.manyNeedOneIngredient.ToString();
        manyNeedTwoingridietText.text = recepies.manyNeedTwoIngredient.ToString();
        manyNeedThreeingridietText.text = recepies.manyNeedThreeIngredient.ToString();
    }
}
