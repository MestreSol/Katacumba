using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{

    //Velocidade em -Y
    public float Cadencia;

    //Velocidade em X
    public float VelocidadeDeProjecao;

    //Objeto do Prefab
    private GameObject obj;

    public static int Cur = 0;

    public void Awake()
    {
    
        //Ajusta a velocidade de projecao da bala e a cadencia e pega o objeto do prefab dentro do BulletHolder
        VelocidadeDeProjecao = BulletHolder.Instance.Bullet[Cur].VelocidadeDeProjecao * 1000;
        Cadencia = BulletHolder.Instance.Bullet[Cur].Cadencia * 1000;
        obj = BulletHolder.Instance.Bullet[Cur].prefab;

    }
    public void FixedUpdate()
    {

        //Modificia a velocidade do corpo rigido
        obj.GetComponent<Rigidbody2D>().velocity = new Vector3(VelocidadeDeProjecao, Cadencia, 0) ;
        
    }

    //Ao ativar a entrada de colisao do tipo trigger
    public void OnTriggerEnter2D(Collider2D collision)
    {

        //Caso colida com os limites do mapa
        if (collision.gameObject.tag == "Limiter")
        {
            
            //Destroi o projetil
            Destroy(gameObject);
            return;
        }

        //Caso colida com o inimigo
        if (collision.gameObject.tag == "Enemy")
        {
            //Destroi a bala
            Destroy(gameObject);
            return;

        }
        if (collision.gameObject.tag == "Chao") {
            Destroy(gameObject);
            return;
        }
    }
   
}
