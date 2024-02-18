using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class WeaponAnimatiorController : MonoBehaviour
{
    [HideInInspector] public Animator animator;
    
    public string[] attackAnimationTriggersNames;
    private bool isAttacking;
    private PlayerAttack _playerAttack;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    public void MomentAttackAnim()
    {
        _playerAttack.Attack();
        _playerAttack.Mining();
    }

    public void PlayAnimAttack()
    {
        if (!isAttacking)
        { 
            isAttacking = true; 
            int randomIndex = Random.Range(0, attackAnimationTriggersNames.Length); 
            animator.SetTrigger(attackAnimationTriggersNames[randomIndex]);
        }
    }

    public void SetPlayerAttack(PlayerAttack player)
    {
        _playerAttack = player;
    }

    public void EndAnimationAttack()
    {
        isAttacking = false;
    }
}
