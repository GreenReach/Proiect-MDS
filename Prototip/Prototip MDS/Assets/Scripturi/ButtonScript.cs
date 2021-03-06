﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject interactWith;
    public string TypeOfInteraction;
    public Sprite actualDoor;
    public Sprite otherDoor; 

    public float yUnitati = 1f;
    public float xUnitati = 1f;

    public bool moved = false;
    void Start()
    {
        actualDoor = interactWith.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void OnTriggerStay2D(Collider2D col){
        
        if(col.gameObject.name == "Player"){
            if(Input.GetKeyDown(KeyCode.F)){
                switch (TypeOfInteraction)
                {
                    case "usa":
                        SpriteRenderer spr = interactWith.GetComponent<SpriteRenderer>();
                        if(spr.sprite == actualDoor) 
                            spr.sprite = otherDoor;
                        else spr.sprite = actualDoor;

                        break;
                    case "trapdoorDreapta":
                        Vector3 posD = interactWith.transform.position;
                        posD.x = moved ? posD.x - xUnitati : posD.x + xUnitati;
                        moved = !moved;
                        interactWith.transform.position = posD;
                        break;
                     case "trapdoorStanga":
                        Vector3 posS = interactWith.transform.position;
                        posS.x = moved ? posS.x + xUnitati : posS.x - xUnitati;
                        moved = !moved;
                        interactWith.transform.position = posS;
                        break;
                    case "distruge":
                        Destroy(interactWith);
                        break;
                    case "":
                        Debug.Log("SELECTEAZA ACTIUNE BUTON " + this.name);
                        break;
                }
            }
        }
    }

}
