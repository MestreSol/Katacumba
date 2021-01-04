using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    public static int MaxEnemyInScreen;
    public static int CurEnemyInScreen;
    private void Start()
    {
        if (MaxEnemyInScreen <= 10) {
            MaxEnemyInScreen = 10;
        }
    }
}
