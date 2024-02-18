using UnityEngine;

public class Interaction : MonoBehaviour
{
    public float distance;
    private Ray ray;
    private Vector3 rayPosition;
    private RaycastHit hit;
    private PlayerMove playerMove;

    public UIController uIController;

    private void Start()
    {
        playerMove = GetComponentInChildren<PlayerMove>();
    }

    private void Update()
    {
        rayPosition = new Vector3(Screen.width / 2, Screen.height / 2);
        ray = Camera.main.ScreenPointToRay(rayPosition);
        uIController.RemoveInformationItem();
        uIController.RemoveCookingStatus();

        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.collider.TryGetComponent(out IIinteracting iinteracting))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    uIController.RemoveInformationItem();
                    iinteracting.Interactive(playerMove);
                    return;
                }

                uIController.ShowInformationItem(iinteracting.GetItemInfo());
            }

            if (Physics.Raycast(ray, out hit, distance))
            {
                if (hit.collider.TryGetComponent(out MinedObject minedObject))
                {
                    uIController.ShowInformationItem(minedObject.minedObjectInfo.nameMinedObject);
                }

                if (hit.collider.TryGetComponent(out CookingBonfire cookingBonfire))
                {
                    uIController.RemoveInformationItem();
                    uIController.ViewCookingStatus(cookingBonfire.status);
                    if (Input.GetKeyDown(KeyCode.E) && cookingBonfire.foodReady)
                    {
                        cookingBonfire.Interactive(playerMove);

                    }
                }
            }
        }
    }
}
