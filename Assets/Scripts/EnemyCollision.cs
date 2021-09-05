using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public Material materialToTurnInto;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other) //this makes the object persist on collision
    {

        Debug.Log("Collision Detected with Enemy.");
        GetComponent<Renderer>().material = materialToTurnInto;


    }



}
