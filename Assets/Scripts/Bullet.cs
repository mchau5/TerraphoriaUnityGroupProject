using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletDes : MonoBehaviour
{


    private void OnCollisionEnter(Collision collision)
    {



        //after collision is detected destroy the gameobject
        Destroy(gameObject);
    }
}