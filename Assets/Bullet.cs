using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet: MonoBehaviour
{


    private void OnCollisionEnter(Collision collision)
    {



        //after collision is detected destroy the gameobject
        Destroy(gameObject);
    }
}