using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{

    public int Damage = 3;
    public double Delay = 2.0;
    public PlayerScript playerScript;
    private bool arde = true;


    //Daca jucatorul atinge lava viata lui scade, daca tocmai a atins lava viata sa ramane la fel
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


    // Timer-ul de ardere a jucatorului, daca el nu este 0 jucatorul nu poate primii damage
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
