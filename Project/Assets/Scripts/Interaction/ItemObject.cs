using System.Collections;
using UnityEngine;

public class ItemObject : MonoBehaviour, IIinteracting
{
    [HideInInspector] public AudioSource source;
    [HideInInspector] public CreateCellInInventory createCellInInventory;
    [HideInInspector] public PlayerMove playerMove;

    public ItemInfo itemInfo;
    public AudioClip pickup;
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    public void Interactive(PlayerMove player)
    {
        playerMove = player;
        playerMove.inventory.AddItem(itemInfo);
        player.uIController.ShowText($"{itemInfo.name} в инвентаре");
        StartCoroutine(DestroyObject());
    }
    public ItemInfo GetItemInfo()
    {
        return itemInfo;
    }

    private IEnumerator DestroyObject()
    {
        source.clip = pickup;
        source.Play();
        Destroy(GetComponent<MeshRenderer>());
        if(TryGetComponent(out BoxCollider boxCollider)) Destroy(boxCollider);
        if(TryGetComponent(out SphereCollider sphereCollider)) Destroy(sphereCollider);
        yield return  new WaitForSeconds(pickup.length);
        
        Destroy(gameObject);
    }
}
