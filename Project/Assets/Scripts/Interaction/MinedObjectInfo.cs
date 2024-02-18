using UnityEngine;

[CreateAssetMenu(fileName = "MinedObject", menuName = "MinedObject")]
public class MinedObjectInfo : ScriptableObject
{
    public ItemInfo productMining;
    public string nameMinedObject;
    public string descriptionMinedObject;
    public WeaponType typeMining;

    public AudioClip[] hitSound;
}
