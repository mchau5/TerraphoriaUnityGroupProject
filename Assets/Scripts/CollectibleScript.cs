using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    public ScoreScript scoreManager;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            // printing if collision is detected on the console
            //scoreManager.addPoint();
            //after collision is detected destroy the gameobject
            
        }
    }

}
