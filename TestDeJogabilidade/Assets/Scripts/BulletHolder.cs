using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class BulletType {

    public float Cadencia;
    public float VelocidadeDeProjecao;
    public int Efect = 0;
    public int Coldown = 0;
    public int Dano;
    public GameObject prefab;

}
public class BulletHolder : MonoBehaviour
{
    public static BulletHolder Instance;
    public BulletType[] Bullet;
    public void Awake()
    {
        Instance = this;
    }
}
