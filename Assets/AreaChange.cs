using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaChange : MonoBehaviour
{
    public Player player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Collision detected (AreaChange)");
            player.audioSource.Stop();
            player.audioSource.PlayOneShot(player.audioClips[1]);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Collision detected (AreaChange)");
            player.audioSource.Stop();
            player.audioSource.PlayOneShot(player.audioClips[0]);
        }
    }
}
