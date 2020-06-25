using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }

    //create public method that reduces hitpoints by amount of dmg
    public void takeDamage(float damange)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damange;
        if(hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead == true) return;
        isDead = true;
        GetComponent<Animator>().SetTrigger("die");
    }
}
