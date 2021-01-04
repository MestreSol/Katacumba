using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public int Cur;
    
    // Start is called before the first frame update
    void Start()
    {
        Cur = GameManager.CurrentWeapon;

        Bullet.Cur = WeaponHolder.Instance.Weapons[Cur].Bala;

    }

    
}
