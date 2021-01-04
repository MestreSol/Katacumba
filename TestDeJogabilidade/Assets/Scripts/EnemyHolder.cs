using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class EnemyType{
    public int id;
    public string Nome;
    public int Vida;
    public bool Voador;
    public bool EnableFire;
    public int MoveSpeedX;
    public int MoveSpeedY;
    public int Valor;
}
public class EnemyHolder : MonoBehaviour
{

    public static EnemyHolder Instance;
    public EnemyType[] Enemy;
    public void Awake()
    {
        Instance = this;
    }
}
