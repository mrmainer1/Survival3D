using UnityEngine;

public class BuildObject : MonoBehaviour
{
    public float distance;
    private Ray ray;
    private Vector3 rayPosition;
    private RaycastHit hit;
    public bool canBuild = false;

    public GameObject objectBuild;
    public CheckConstructionZone constructionZone;
    public ItemInfo cookingProduct;

    private PlayerMove playerMove;
    public ItemInfo itemInfo;

    private void Start()
    {
        playerMove = GetComponentInChildren<PlayerMove>();
    }

    private void Update()
    {
        BuildRay();
    }

    public void SetConstructionZone(ItemInfo info)
    {
        canBuild = true;
        objectBuild = info.prefabs;
        itemInfo = info;
        GlobalController.ItemInArm = ItemInArm.BuildObject;
        constructionZone.gameObject.transform.localScale = info.prefabs.transform.localScale;
    }
    public void BuildRay()
    {

        if (!canBuild)
        {
            return;
        }
        
        rayPosition = new Vector3(Screen.width / 2, Screen.height / 2);
        ray = Camera.main.ScreenPointToRay(rayPosition);

        if (Physics.Raycast(ray, out hit, distance))
        {
            constructionZone.gameObject.transform.position = hit.point;

            if (constructionZone.CheckZone())
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    canBuild = false;
                    GlobalController.ItemInArm = ItemInArm.None;
                    GameObject build = Instantiate(objectBuild, constructionZone.gameObject.transform.position, constructionZone.gameObject.transform.rotation);
                    constructionZone.gameObject.transform.position = new Vector3(100f, 100f, 100f);

                    if(build.TryGetComponent(out CookingBonfire cookingBonfire))
                    {
                        cookingBonfire.playerMove = playerMove;
                        cookingBonfire.itemInfo = cookingProduct;
                    }
                }
            }
        }
    }
}
