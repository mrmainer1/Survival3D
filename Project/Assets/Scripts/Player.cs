using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float health = 100;
    public float maxHealth = 100;


    public float hunger;
    public float maxHunger = 100;

    private void Start()
    {
        StartCoroutine(IcreaseHunger());
    }

    private void Update()
    {
        if (hunger > 100)
        {
            Death();
        }

        if (health < 0)
        {
            Death();
        }
    }
    public void AddHealth(int value)
    {
        if (health + value < maxHealth)
        {
            health += value;
            return;
        }
        health = maxHealth;
    }

    public void TakeDamage(int value)
    {
        if (health - value <= 0)
        {
            Death();
            return;
        }
        health -= value;
    }
    public void RemoveHunger(int value)
    {
        if(hunger - value <= 0)
        {
            hunger = 0;
            return;
        }

        hunger -= value;
    }

    public IEnumerator IcreaseHunger()
    {
        for (int i = 0; i <= maxHunger; i++)
        {
            yield return new WaitForSeconds(5f);
            hunger++;
        }
    }

    private void Death()
    {
        Debug.Log("Вы умерли");
    }
}
