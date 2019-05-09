using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertGravity : MonoBehaviour
{

	public GameObject player;
	PlayerScript playerScript;
	AreaEffector2D effector;
    void Start()
    {
        playerScript = player.GetComponent<PlayerScript>();
        effector = GetComponent<AreaEffector2D>();
    }

    void Update()
    {
        
    }

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
