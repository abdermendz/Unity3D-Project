using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] float maxHitPoints = 100f;
    [SerializeField] HealtBar healthBar;
    float hitPoints;

    private void Start()
    {
        hitPoints = maxHitPoints;
        healthBar.setMaxHealth(maxHitPoints);
    }

    public void takeDamage(float damage)
    {
        hitPoints -= damage;
        healthBar.setHealth(hitPoints);
        if(hitPoints <= 0)
        {
            GetComponent<DeathHandler>().HanldeDeath();
        }
    }
}
