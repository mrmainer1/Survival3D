using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class MinedObject : MonoBehaviour
{
    public MinedObjectInfo minedObjectInfo;

    public int minResource;
    public int maxResource;
    public int totalResource;

    private PlayerMove playerMove;
    private AudioSource audioSource;

    private void Awake()
    {
        totalResource = Random.Range(minResource, maxResource);
        audioSource = GetComponent<AudioSource>();
    }

    public void Mining(PlayerMove player, WeaponType weaponType)
    {
        if (weaponType == minedObjectInfo.typeMining)
        {
            totalResource--;
            player.inventory.AddItem(minedObjectInfo.productMining);
            player.uIController.ShowText($"{minedObjectInfo.productMining.name} добыт");

            audioSource.clip = minedObjectInfo.hitSound[Random.Range(0, minedObjectInfo.hitSound.Length)];
            audioSource.Play();

            if (totalResource == 0)
            {
                StartCoroutine(DestroyObject());
            }
        }
    }
    
    private IEnumerator DestroyObject()
    {
        Destroy(GetComponent<MeshRenderer>());
        if(TryGetComponent(out BoxCollider boxCollider)) Destroy(boxCollider);
        if(TryGetComponent(out SphereCollider sphereCollider)) Destroy(sphereCollider);
        
        for (int i = 0; i < transform.childCount; i++)
        { 
            Destroy(transform.GetChild(i).gameObject);
        }
        
        yield return  new WaitForSeconds(audioSource.clip.length);
        
        Destroy(gameObject);
    }

    public ItemInfo GetItemInfo()
    {
        return minedObjectInfo.productMining;
    }
    
}
