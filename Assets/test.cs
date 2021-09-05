using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    [SerializeField] private AudioClip[] grassSteps;
    private AudioSource audioSource;


    public void footstep1()
    {

        footstepFunction();



    }
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void backwardsfs()
    {
        footstepFunction();
    }

    private void footstepFunction()
    {
       
     
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            var floortag = hit.collider.gameObject.tag;
            if (floortag == "Ground")
            {
                AudioClip clip = GetRandomClip();
                audioSource.PlayOneShot(clip);
            }
            else if (floortag == "Obstacle")
            {
                AudioClip clip = GetRandomClip();
                audioSource.PlayOneShot(clip);
            }
        }

    }

    private AudioClip GetRandomClip()
    {
        return grassSteps[UnityEngine.Random.Range(0, grassSteps.Length)];
    }

}
