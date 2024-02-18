using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [HideInInspector] public ItemInfo weaponInArm;
    public GameObject createWeapon;
    public Transform spawnPointWeapon;
    public WeaponAnimatiorController animatorWeapon;
    public PlayerMove playerMove;

    public UIController uIController;
    
    public float distance;
    private Ray ray;
    private Vector3 rayPosition;
    private RaycastHit hit;
    private Enemy enemy;
    private MinedObject minedObject;
    private ItemInfo minedProduct;

    private void Update()
    {
        if (GlobalController.GameNotOnPause)
        {
            CreateRay();
            ShowInformation();
            CheckInput();
        }
    }

    public void CheckInput()
    {
        if (Input.GetKey(KeyCode.Mouse0) && GlobalController.ItemInArm == ItemInArm.Weapon) 
        {
            animatorWeapon.PlayAnimAttack();
        }
    }
    public void SetWeapon(ItemInfo info)
    {
        GlobalController.ItemInArm = ItemInArm.Weapon;
        weaponInArm = info;
        GameObject weapon = Instantiate(weaponInArm.prefabsItemInArm, spawnPointWeapon);
        createWeapon = weapon;
        animatorWeapon = weapon.GetComponent<WeaponAnimatiorController>();
        animatorWeapon.SetPlayerAttack(GetComponent<PlayerAttack>());
    }
    
    public void Mining()
    {
        if (Physics.Raycast(ray, out hit, distance) && hit.collider.TryGetComponent(out minedObject)) 
        { 
            minedObject.Mining(playerMove,weaponInArm.weaponType);
        } 
    }
    public void Attack()
    {
        if (Physics.Raycast(ray, out hit, distance) && hit.collider.TryGetComponent(out enemy)) 
        { 
            enemy.TakeDamage(weaponInArm.damage);
        } 
    }

    private void ShowInformation()
    {
        uIController.RemoveInformationEnemy();

        if (Physics.Raycast(ray, out hit, distance) && hit.collider.TryGetComponent(out enemy)) 
        { 
            uIController.ShowInformationEnenmy(enemy.enemyName, enemy.health);
        }
    }
    private void CreateRay()
    {
        rayPosition = new Vector3(Screen.width / 2, Screen.height / 2);
        ray = Camera.main.ScreenPointToRay(rayPosition);
    }
}
