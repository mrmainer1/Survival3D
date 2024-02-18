using System;
using UnityEngine;
using UnityEngine.Events;

public class TakeoffItem : MonoBehaviour
{
    public UnityEvent itemTakeOff;
    
    public PlayerAttack playerAttack;
    public PlayerMove playerMove;
    public BuildObject buildObject;
    private void Start()
    {
        playerAttack = GetComponent<PlayerAttack>();
    }

    private void Update()
    {
        Debug.Log(GlobalController.ItemInArm);
        if (Input.GetKeyDown(KeyCode.P) && GlobalController.ItemInArm != ItemInArm.None)
        {
            switch (GlobalController.ItemInArm)
            {
                case ItemInArm.Weapon:
                    TakeOffWeapon();
                    break;
                case ItemInArm.BuildObject:
                    TakeOffBuildObject();
                    break;
            }
        }
    }
    public void TakeOffWeapon()
    {
        GlobalController.ItemInArm = ItemInArm.None;
        Destroy(playerAttack.createWeapon);
        playerAttack.createWeapon = null;
        playerMove.inventory.AddItem(playerAttack.weaponInArm);
        playerAttack.weaponInArm = null;
        
        itemTakeOff?.Invoke();
    }

    public void TakeOffBuildObject()
    {
        GlobalController.ItemInArm = ItemInArm.None;
        buildObject.canBuild = false;
        playerMove.inventory.AddItem(buildObject.itemInfo);
            
        itemTakeOff?.Invoke();
    }
}
