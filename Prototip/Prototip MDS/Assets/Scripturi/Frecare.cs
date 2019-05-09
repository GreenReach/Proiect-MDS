using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frecare : MonoBehaviour
{
	public float factor = 2f;
	public GameObject player;
	PlayerScript playerScript;

	private float slowedJumpSpeed;
	private float slowedWalkSpeed;
	private float _gravityPull;
	private float originalGravityPull;
	private float originalWalkSpeed;
	private float originalJumpSpeed;


    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<PlayerScript>();

        slowedJumpSpeed = playerScript.jumpSpeed * 1/factor;
        slowedWalkSpeed = playerScript.walkSpeed * 1/factor;
        _gravityPull = playerScript.gravityPull * 1/factor;
        originalWalkSpeed = playerScript.walkSpeed;
        originalGravityPull = playerScript.gravityPull;
        originalJumpSpeed = playerScript.jumpSpeed;
    }

    void Update(){
    //	Debug.Log(playerScript.rb.velocity);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D col)
    {
    	if (col.GetComponent<Collider2D>().gameObject.name == "Player")
        {
        	Vector2 v = playerScript.rb.velocity;        	
        	playerScript.gravityPull = _gravityPull;
        	playerScript.walkSpeed = slowedWalkSpeed;
        	playerScript.jumpSpeed = slowedJumpSpeed;
        	v *= 1/factor;
        	playerScript.rb.velocity = v;
        	Debug.Log("Frec");
        }
    }

    private void OnTriggerStay2D(Collider2D col){
    	Vector2 v = playerScript.rb.velocity;
		playerScript.gravityPull = _gravityPull;
		playerScript.walkSpeed = slowedWalkSpeed;
		playerScript.jumpSpeed = slowedJumpSpeed;
    	v *= 1/factor;
    	playerScript.rb.velocity = v;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
    	if (col.GetComponent<Collider2D>().gameObject.name == "Player")
        {
        	Vector2 v = playerScript.rb.velocity;
        	v *= factor;
        	playerScript.walkSpeed = originalWalkSpeed;
        	playerScript.jumpSpeed = originalJumpSpeed;
        	playerScript.gravityPull = originalGravityPull;
        	playerScript.rb.velocity = v;
        	Debug.Log("Nu mai frec");
        }
    }
}
