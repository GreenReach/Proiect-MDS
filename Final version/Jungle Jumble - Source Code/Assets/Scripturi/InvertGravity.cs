using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertGravity : MonoBehaviour
{

	public GameObject player;
	PlayerScript playerScript;
	AreaEffector2D effector;

    // Se seteaza componentele
    void Start()
    {
        playerScript = player.GetComponent<PlayerScript>();
        effector = GetComponent<AreaEffector2D>();
    }

    //Daca jucatroul intra intr-o astfel de zona atractia sa gravitationala se va micsora pe orientarea sa
    private void OnTriggerStay2D(Collider2D col)
    {
    	if (col.GetComponent<Collider2D>().gameObject.tag == "Player")
        {
        	playerScript.gravityPull *= -1;
        	playerScript.gravityDirection = new Vector2(0, playerScript.gravityPull);
        	playerScript.simulatedGravity.force = playerScript.gravityDirection;
        	Debug.Log("GRAV");
        }
    }
}
