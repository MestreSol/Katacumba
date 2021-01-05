using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    internal Transform thisTransform;
    internal Collider2D Objetivo;
    internal Collider2D Floor;
    public Animator anim;
    public Collider2D EnemyC;
    public Rigidbody2D rn2d;
    public GameObject die;
    public GameObject pivo;
    public AudioSource Spwn;
    public AudioSource Dmg;
    public AudioSource DieE;
    public AudioSource Enter;
    public int Vida = 0;
    private int CurEnemy = 0;
    


    private void Awake()
    {
        Spwn.Play();
        //Pega o objetivo
        Objetivo = GameObject.FindGameObjectWithTag("Objetivo").GetComponent<Collider2D>();
        //Pega o chao
        Floor = GameObject.FindGameObjectWithTag("Chao").GetComponent<Collider2D>();
        //anim = gameObject.GetComponent<Animation>();
        anim.SetTrigger("Wallking");
        Vida = EnemyHolder.Instance.Enemy[CurEnemy].Vida;
    }

    //Construtor do inimigo para exigir o tipo dele
    public Enemy(int i) {

        //Caso o valor de i seja menor que 0 ou maior que o valor maximo do array, retorna-o 0
        if (i <= 0 || i >= EnemyHolder.Instance.Enemy.Length - 1)
        {
            i = 0;
        }
        else {
            CurEnemy = i;
        }
    }

    //
    private void FixedUpdate()
    {
        //Se o inimigo nao estiver colidindo com o objetivo, mova-o, se estiver, entre na torre
        if (!Objetivo.IsTouching(EnemyC))
        {
            Move(CurEnemy);
        }
        else {
            Enter.Play();
            EnterInTower();
        }
        if (Vida <= 0) {
            
            Die();
            
        }
        
    }
    public void Die() {
        DieE.Play();
        GameObject Mo = (GameObject)Instantiate(die, pivo.transform.position, Quaternion.identity) ;
        GameManager.Money += 200;
        GameManager.Pontos += 1;
        Vector2 a = new Vector2(0,1);
        Mo.GetComponent<Rigidbody2D>().velocity =  a*2;
        anim.SetTrigger("Die");
        Destroy(Mo,1f);
        Destroy(gameObject);

    }
    public void EnterInTower() {
        Enter.Play();
        GameManager.EnemyInTower.Add(this);
        Destroy(gameObject,1f);
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colidiu");
        if (collision.gameObject.tag == "Tiro")
        {
            Dmg.Play();
            Debug.Log("ComBala");
            Vida -= BulletHolder.Instance.Bullet[Bullet.Cur].Dano;
        }
    }
    public void Move(int index) {
        
        //Verifica se o inimigo e do tipo voador
        if (EnemyHolder.Instance.Enemy[index].Voador)
        {

        }
        else {
            //Caso nao seja forca o inimigo a colidir com o chao
            if (Floor)
            {

                EnemyHolder.Instance.Enemy[index].MoveSpeedY = 0;
            }
            else
            {
                EnemyHolder.Instance.Enemy[index].MoveSpeedY = 3;
            }
        }
        //Movimenta o rigidBody do prefab
        anim.SetTrigger("Wallking");
        rn2d.velocity = new Vector3(EnemyHolder.Instance.Enemy[index].MoveSpeedX, EnemyHolder.Instance.Enemy[index].MoveSpeedY, 0);
    }
  
}
