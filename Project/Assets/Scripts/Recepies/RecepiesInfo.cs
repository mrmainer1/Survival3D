using UnityEngine;

[CreateAssetMenu(fileName = "Recepies", menuName = "Recepies")]
public class RecepiesInfo : ScriptableObject
{
    public ItemInfo product;

    public ItemInfo oneIngredient;
    public int manyNeedOneIngredient;

    public ItemInfo twoIngredient;
    public int manyNeedTwoIngredient;

    public ItemInfo threeIngredient;
    public int manyNeedThreeIngredient;
}
