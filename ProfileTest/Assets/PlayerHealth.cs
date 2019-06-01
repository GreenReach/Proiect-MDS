using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public Transform healthBar;
    public Slider healthFill;

    public float currentHealth;

    public float maxHealth;
    public float healthBarYOffset = 2;  //pozitia + 2 pe y 
	
    // Bara de viata se schimba in functie de viata actuala a jucatorului
    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); //sa nu scada sub 0 

        healthFill.value = currentHealth / maxHealth;

    }
	
    // Schimb forma sprite-ului
    private void PositionHealthBar()
    {

        Vector3 currentPos = transform.position;

        healthBar.position = new Vector3(currentPos.x, currentPos.y + healthBarYOffset, currentPos.z);

        healthBar.LookAt(Camera.main.transform);        
    }
    
	void Update () {

        PositionHealthBar();
    }
}
