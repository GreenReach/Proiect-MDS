using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frecare : MonoBehaviour
{
	public float factor = 2f;
	public GameObject player;
	PlayerScript playerScript;

	private float slowedJumpSpeed; // Noua putere de salt
	private float slowedWalkSpeed; // Noua viteza de mers
	private float _gravityPull; // Noua atractie gravitationala
	private float originalGravityPull; // Atractia gravitationala originala
	private float originalWalkSpeed; // Viteza de mers originala
	private float originalJumpSpeed; // Puterea de salt originala


    // Datele initiale ale jucatorului sunt salvate
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


    // Daca jucatroul intra intr-o astfel de zona atributele sale vor fi inmultite cu o constanta 
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

    // Se pastreaza atributele jucatorului schimbate cat timp este in zona
    private void OnTriggerStay2D(Collider2D col){
    	Vector2 v = playerScript.rb.velocity;
		playerScript.gravityPull = _gravityPull;
		playerScript.walkSpeed = slowedWalkSpeed;
		playerScript.jumpSpeed = slowedJumpSpeed;
    	v *= 1/factor;
    	playerScript.rb.velocity = v;
    }

    // Daca jucatorul iese atrbutele sale originale sunt restabilite
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
