using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateScript : MonoBehaviour {

	
    public GameObject interactWith;
    public string TypeOfInteraction;
    public Sprite actualDoor;
    public Sprite otherDoor; 

    public float yUnitati = 1f;
    public float xUnitati = 1f;

    public bool moved = false;

    //Setez sprite-ul initial 
    void Start()
    {
        actualDoor = interactWith.GetComponent<SpriteRenderer>().sprite;
    }


    // In functie de parametrul "TypeOfInteraction" diferite actiuni au loc asupra obictului implicit
    public void OnTriggerStay2D(Collider2D col){
                switch (TypeOfInteraction)
                {
            // Jucatorul poate sa treaca prin usa
                    case "usa":
                        SpriteRenderer spr = interactWith.GetComponent<SpriteRenderer>();
                        if(spr.sprite == actualDoor) 
                            spr.sprite = otherDoor;
                        else spr.sprite = actualDoor;

                        break;
            // Usa se muta la dreapta
                    case "trapdoorDreapta":
                        Vector3 posD = interactWith.transform.position;
                        posD.x = moved ? posD.x - xUnitati : posD.x + xUnitati;
                        moved = !moved;
                        interactWith.transform.position = posD;
                        break;
            // Usa se muta la stanga
                     case "trapdoorStanga":
                        Vector3 posS = interactWith.transform.position;
                        posS.x = moved ? posS.x + xUnitati : posS.x - xUnitati;
                        moved = !moved;
                        interactWith.transform.position = posS;
                        break;
            // Usa este distrusa
                    case "distruge":
                        Destroy(interactWith);
                        break;
                    case "":
                        Debug.Log("SELECTEAZA ACTIUNE BUTON " + this.name);
                        break;
                }
    }
}
