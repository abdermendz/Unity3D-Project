using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{

    [SerializeField] int ammount = 5;
    [SerializeField] AmmoType ammoType;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            FindObjectOfType<Ammo>().increaseCurrentAmmo(ammoType, ammount);
            Destroy(gameObject);
        }
    }
}
