using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public Transform bullet;
    public float Viteza = 5f; // TODO: private
    Vector2 direction;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    public void Orientate(int orientation)
    {

        if (orientation == 1)
        {
            direction = new Vector2(Viteza, 0);
            bullet.Rotate(0, 0, 0);
        }
        if (orientation == -1)
        {
            direction = new Vector2(-Viteza, 0);
            bullet.Rotate(0, 0, 180);
        }
        if (orientation == 2)
        {
            direction = new Vector2(0, Viteza);
            bullet.Rotate(0, 0, 90);
        }

        if (orientation == -2)
        {
            direction = new Vector2(0, -Viteza);
            bullet.Rotate(0, 0, 270);
        }
    }

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

    private void FixedUpdate()
    {
        rb.velocity = direction;
    }
}
