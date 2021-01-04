using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TiposInimigos{ 
    Normal
}
public class TopTowerManagerEnemy : MonoBehaviour
{
    public int TimeSpawner;
    public Enemy[] EnemysAlive;
    public void GenerateEnemy() { 
        
    }
    // Start is called before the first frame update
    void Start()
    {
        EnemysAlive = new Enemy[Config.MaxEnemyInScreen];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
