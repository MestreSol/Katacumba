using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    public float spwnTime;
    private float NextSpwn = 0;
    // Start is called before the first frame update
    public void Spwn (){
        if (Time.time > NextSpwn) {
            NextSpwn = spwnTime + Time.time;
            Instantiate(Enemy,transform.position,Quaternion.identity);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        Spwn();
    }
}
