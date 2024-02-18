using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public string enemyName;

    public Transform player;
    private NavMeshAgent agent;
    private bool canHit = true;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = player.position;
    }

    private void Update()
    {
        agent.SetDestination(player.position);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Death();
    }

    private void Death()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player playerSc))
        {
           
            StartCoroutine(HitPlayer(playerSc));
        }
    }

    private void OnCollisionExit(Collision collision)
    {
    }
    private IEnumerator HitPlayer(Player sc)
    {
        if(canHit)
        {
            sc.TakeDamage(10);
            canHit = false;
            yield return new WaitForSeconds(1f);
            canHit = true;
        }
    }
}
