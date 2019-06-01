using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienScript : MonoBehaviour
{
    // TODO: private
    public float Viteza = 1f;
    public double TimpDirectie = 1.0;
    public float DamageCD = 2f;
    // /private

    private Rigidbody2D rb;
    private bool dreapta;
    private bool okSchimb;
    private bool ataca;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dreapta = true;

        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        rb.velocity = dreapta ? new Vector2(Viteza, 0) : new Vector2(-Viteza, 0);

        TimpDirectie -= Time.deltaTime;


        // time dep
        if (!okSchimb)
        {
            if (TimpDirectie <= 0)
            {
                okSchimb = true;
                TimpDirectie = 1.0;
            }
        }

        if (!ataca)
        {
            DamageCD -= Time.deltaTime;
            if(DamageCD <= 0)
            {
                ataca = true;
                DamageCD = 2f;
            }
        }

        if (okSchimb)
        {
            dreapta = !dreapta;
            okSchimb = !okSchimb;
        }
        else okSchimb = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ataca && collision.gameObject.tag == "Player")
        {
            Debug.Log("Extraterestrul a atins player");
            GameObject.Find("Player").GetComponent<PlayerScript>().getDamage(1);

        }

        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("Extraterestrul a atins wall");
            dreapta = !dreapta;
        }
    }



}
