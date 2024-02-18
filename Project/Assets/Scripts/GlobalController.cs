using UnityEngine;

public enum ItemInArm
{
    None,
    Weapon,
    BuildObject
}
public class GlobalController : MonoBehaviour
{
    public static bool GameNotOnPause = true;
    public static ItemInArm ItemInArm;
    private void Start()
    {
        Cursor.visible = false;
        ItemInArm = ItemInArm.None;
    }
}
