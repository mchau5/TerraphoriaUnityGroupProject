using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JmoAIScript : MonoBehaviour
{
    private NavMeshAgent _mNavMeshAgent;

    public GameObject player;

    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        _mNavMeshAgent = GetComponent<NavMeshAgent>();

        _mNavMeshAgent.stoppingDistance = 2.0f;

        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        _mNavMeshAgent.destination = player.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "bullet(Clone)")
        {

            // printing if collision is detected on the console
            Debug.Log("Collision Detected");

            audio.Play();


            //after collision is detected destroy the gameobject
            Destroy(gameObject, 0.5f);
        }
    }
}
