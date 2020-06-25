using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{

    [SerializeField] int currentWeapon = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        SetWeaponActive();
    }

    void Update()
    {
        int prevWeapon = currentWeapon;

        ProcessKeyButton();
        ProcessScrollWheel();

        if(prevWeapon != currentWeapon)
        {
            SetWeaponActive();
        }
    }

    private void ProcessScrollWheel()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentWeapon <= 0)
            {
                currentWeapon = transform.childCount - 2;
            }
            else
            {
                currentWeapon--;
            }
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentWeapon >= transform.childCount - 2)
            {
                currentWeapon = 0;
            }
            else
            {
                currentWeapon++;
            }
        }
    }

    private void ProcessKeyButton()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentWeapon = 3;
        }


    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;
        Transform temp;
        for(int i  =0; i< this.gameObject.transform.childCount -1; i++)
        {
            temp = this.gameObject.transform.GetChild(i);
            if(weaponIndex == currentWeapon)
            {
                temp.gameObject.SetActive(true);
            }
            else
            {
                temp.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }
   
}
