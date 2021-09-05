using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JCervantesAIFSMScript : MonoBehaviour
{
    private enum State
    {
        WaypointA, WaypointB, PlayerInRange
    }

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private State currentState;
    private State previousState;
    private Vector3 defaultVector;

    public float speed = 0.5f;
    public GameObject player;
    public AudioSource audioSource;
    public AudioClip[] audioClips;

    Transform t;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();

        startPosition = transform.position;
        currentState = State.WaypointA;
        previousState = State.WaypointA;
    }

    IEnumerator waitCoroutine()
    {
        yield return new WaitForSeconds(2);
        speed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.WaypointA:
                rb.velocity += this.transform.forward * speed * 0.05f;
                break;
            case State.WaypointB:
                rb.velocity -= this.transform.forward * speed * 0.05f;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AIWaypoint")
        {
            if (currentState == State.WaypointA)
            {
                currentState = State.WaypointB;
                rb.velocity = defaultVector;
            }
            else
            {
                currentState = State.WaypointA;
                rb.velocity = defaultVector;
            }

            speed = 0.0f;

            StartCoroutine(waitCoroutine());
            previousState = currentState;
        }

        if (other.tag == "Player")
        {
            
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(audioClips[Random.Range(0, 3)]);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.tag == "Player")
        {

            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }


}
