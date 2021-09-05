using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit : MonoBehaviour
{

    Ray myRay;      // initializing the ray
    RaycastHit hit; // initializing the raycasthit
    public GameObject objectToinstantiate;
    public GameObject cannon;
    public GameObject bullet;

    private AudioSource audio;

    public ResourceBar MP;

    public float currentMP;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb;
        Transform t;
        audio = GetComponent<AudioSource>();
        currentMP = MP.GiveMaxResource();

        InvokeRepeating("Auto_MP_Recovery", 1, 5);
        
    }
    
    // Update is called once per frame
    void Update()
    {
        //telling ray variable location
        myRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(myRay, out hit))
        { // here I ask : if myRay hits something, store all the info you can find in the raycasthit varible.

            if (Input.GetMouseButtonDown(0) && (PauseMenu.isPaused != true))
            {
                if (MP.GiveValue() >= 1)
                {
                    currentMP = MP.GiveValue() - 2.5f;
                    MP.SetResource(currentMP);
                    Instantiate(objectToinstantiate, hit.point, Quaternion.identity);// instatiate a prefab on the position where the ray hits the floor.
                    Debug.Log(hit.point);// debugs the vector3 of the position where I clicked
                }
            }

        }// end physics.raycast    


        if (Input.GetMouseButtonDown(1))
        {
            if (MP.GiveValue() >= 25)
            {
                GameObject newBullet = GameObject.Instantiate(bullet, cannon.transform.position, cannon.transform.rotation) as GameObject;
                newBullet.GetComponent<Rigidbody>().velocity += Vector3.up * 2;
                newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * 1500);
                audio.Play();
                currentMP = MP.GiveValue() - 25;
                MP.SetResource(currentMP);
                Debug.Log("Player pressed right mouse button");
            }
        }
        if (Input.GetMouseButtonDown(2))
        {
            Debug.Log("Player pressed middle mouse button");
        }
    }

    void Auto_MP_Recovery()
    {
        if (MP.GiveValue() < MP.GiveMaxResource() && (MP.GiveMaxResource() - MP.GiveValue()) > 10)
        {
            currentMP = MP.GiveValue() + 10;
            MP.SetResource(currentMP);
        }
        else if(MP.GiveValue() < MP.GiveMaxResource() && (MP.GiveMaxResource() - MP.GiveValue()) <= 10)
        {
            currentMP = MP.GiveMaxResource();
            MP.SetResource(currentMP);
        }
    }



}
