using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int Damage = 3;
    public double Delay = 2.0;
    public PlayerScript playerScript;
    private bool arde = true;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (arde && collision.gameObject.name == "Player")
        {
            Debug.Log("Player-ul a intrat in lava");
            playerScript.getDamage(Damage);
            arde = false;
        }
        else
        {
            Debug.Log("Doar ce te-ai ars, ai rabdare");
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (!arde)
        {
            Delay -= Time.deltaTime;
            if (Delay <= 0)
            {
                arde = true;
                Delay = 2.0;
            }
        }
    }
}
