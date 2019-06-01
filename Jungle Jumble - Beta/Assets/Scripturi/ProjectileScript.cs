using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    private Rigidbody2D rb;
    public Transform bullet;
    public float Viteza = 5f; 
    Vector2 direction;

    // Se seteaza corpul glontului
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    //Se seteaza orientarea glontului in funtie de parametrul "orientation"
    public void Orientate(int orientation)
    {
        // dreapta
        if (orientation == 1)
        {
            direction = new Vector2(Viteza, 0);
            bullet.Rotate(0, 0, 0);
        }
        // stanga
        if (orientation == -1)
        {
            direction = new Vector2(-Viteza, 0);
            bullet.Rotate(0, 0, 180);
        }
        // sus
        if (orientation == 2)
        {
            direction = new Vector2(0, Viteza);
            bullet.Rotate(0, 0, 90);
        }
        // jos
        if (orientation == -2)
        {
            direction = new Vector2(0, -Viteza);
            bullet.Rotate(0, 0, 270);
        }
    }

    // Daca glontele a lovit jucatorul viata jucatorului scade, daca alovit un zid glontele dispare
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Player" || collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Wall")
        {
            if (collision.gameObject.name == "Player")
                GameObject.Find("Player").GetComponent<PlayerScript>().getDamage(1);
            Debug.Log("Proiectilul a lovit " + collision.collider.gameObject.tag);
            Destroy(this.gameObject);
            
        }
    }

    // Se pastreaza viteza glontelui
    private void FixedUpdate()
    {
        rb.velocity = direction;
    }
}
