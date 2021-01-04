using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Bullete;
    public Transform PointWeapon;
    internal GameObject Arma;
    // Start is called before the first frame update
    void Start()
    {

        Arma = GameObject.FindGameObjectWithTag("Arma");
        PointWeapon = GameObject.FindGameObjectWithTag("Ponteiro").GetComponent<Transform>();
        
    }
    public void Fire() {
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (Vector2)((worldMousePos - transform.position));
        direction.Normalize();
      
        Bullete = (GameObject)Instantiate(BulletHolder.Instance.Bullet[0].prefab, PointWeapon.position, Quaternion.identity);
        Bullete.GetComponent<Rigidbody2D>().velocity = direction * BulletHolder.Instance.Bullet[0].VelocidadeDeProjecao;
        
        Destroy(Bullete, 1f);
    }
   
    public void MouseFollow() {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y,difference.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

    }
    // Update is called once per frame
    void Update()
    {
        MouseFollow();
        if (Input.GetMouseButtonDown(0)) {
            Fire();
        }   
    }
}
