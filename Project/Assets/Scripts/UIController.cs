using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public MainMenu mainMenu;
    
    public Player player;
    
    public Transform spawnPointPickupInformation;
    public GameObject prefabTextPickupInformation;
    
    public Image imageHP;
    public Image imageHunger;
    public TMP_Text informationItem;
    public TMP_Text informationEnemy;
    public TMP_Text informationCooking;

    public float fadeDuration = 2f;
    public float delayBeforeFade;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (mainMenu.isCloseMainMenu)
            {
                mainMenu.OpenMainMenu();
            }
            else
            {
               mainMenu.CloseMainMenu();
            }
        }
        
        ViewHealtBar();
        ViewHungerBar();
    }
    public void ShowText(string textToShow)
    {
        GameObject textPickupInformation = Instantiate(prefabTextPickupInformation, spawnPointPickupInformation);
        textPickupInformation.GetComponent<TMP_Text>().text = textToShow;
        StartCoroutine(FadeOutText(textPickupInformation.GetComponent<TMP_Text>()));
    }

    private IEnumerator FadeOutText(TMP_Text textMesh)
    {
        float timer = 0f;
        Color textColor = textMesh.color;
        textColor.a = 1f;
        textMesh.color = textColor;
        
        yield return new WaitForSeconds(delayBeforeFade);
        
        while (timer < fadeDuration)
        {
            textColor.a = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            textMesh.color = textColor;
            yield return null;
            timer += Time.deltaTime;
        }
        textColor.a = 0f;
        Destroy(textMesh.gameObject);
    }

    public void ShowInformationItem(ItemInfo info)
    {
        informationItem.text = $"{info.name}[E]";
    }
    public void ShowInformationItem(string info)
    {
        informationItem.text = $"{info}";
    }
    public void ShowInformationEnenmy(string enemyName, float health)
    {
        informationEnemy.text = $"{enemyName} {health}HP";
    }

    public void RemoveInformationItem()
    {
        informationItem.text = "";
    }

    public void RemoveInformationEnemy()
    {
        informationEnemy.text = "";
    }
    public void ViewHealtBar()
    {
        imageHP.fillAmount = player.health  / player.maxHealth;
    }

    public void ViewHungerBar()
    {
        imageHunger.fillAmount = player.hunger / player.maxHunger;
    }

    public void ViewCookingStatus(string status)
    {
        informationCooking.text = status;
    }
    public void RemoveCookingStatus()
    {
        informationCooking.text = "";
    }
}
