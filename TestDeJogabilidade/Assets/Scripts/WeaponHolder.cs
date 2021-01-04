using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class WeaponType {
    public int dano;
    public GameObject Sprite;
    public int Bala;
}
public class WeaponHolder : MonoBehaviour
{
    public static WeaponHolder Instance;
    public WeaponType[] Weapons;
    public void Awake()
    {
        Instance = this;
    }
}
