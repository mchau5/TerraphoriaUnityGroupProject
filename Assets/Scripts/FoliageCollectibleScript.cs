using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoliageCollectibleScript : MonoBehaviour
{
    public Player player;
    public ResourceBar resourceBar;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (resourceBar.GiveValue() <= 80)
                {
                    resourceBar.ExtraRecovery(20);
                    Debug.Log(player.currentResource);
                    Debug.Log("Collision Stay");
                    Destroy(gameObject);
                }
                else if(resourceBar.GiveValue()> 80 && resourceBar.GiveValue() < 100)
                {
                    resourceBar.SetResource(resourceBar.GiveMaxResource());
                    Debug.Log(player.currentResource);
                    Debug.Log("Collision Stay");
                    Destroy(gameObject);
                }
            }
        }
    }
}
