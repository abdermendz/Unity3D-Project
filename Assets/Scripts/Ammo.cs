using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmmount;
    }

    public int getCurrentAmmo(AmmoType type)
    {
        return GetAmmoSlot(type).ammoAmmount;
    }

    public void reduceCurrentAmmo(AmmoType type)
    {
        GetAmmoSlot(type).ammoAmmount--;
    }

    public void increaseCurrentAmmo(AmmoType type,int ammount)
    {
        GetAmmoSlot(type).ammoAmmount += ammount;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach(AmmoSlot slot in ammoSlots)
        {
            if(slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }
}
