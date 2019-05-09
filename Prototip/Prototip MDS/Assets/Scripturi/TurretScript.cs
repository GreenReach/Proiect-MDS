using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{

    public double timers = 1.0,timer = 0; // interval de tragere - TODO: Private
    public GameObject projectile; // model glont ca prefab
    public GameObject spawn; // loc de spawn pentru glont
    public int orientation = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void CreatePrefab()
    {
        
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            GameObject b = (Instantiate(
                projectile,
                spawn.transform.position,
                Quaternion.identity)as GameObject);
            b.GetComponent<ProjectileScript>().Orientate(orientation);
            timer = timers;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CreatePrefab();
    }
}
