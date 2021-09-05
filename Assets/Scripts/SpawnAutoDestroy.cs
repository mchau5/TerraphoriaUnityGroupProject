using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAutoDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Auto_Destroy", 15);
    }

    void Auto_Destroy()
    {
        Destroy(gameObject);
    }
}
