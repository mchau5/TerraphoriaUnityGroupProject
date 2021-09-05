using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHP : MonoBehaviour
{
    public Camera camera;

    public Transform monster;

    private float height = 2f;
    public Slider healthSlider;

    // Start is called before the first frame update
    void Start()
    {
        monster = GameObject.FindWithTag("Monster1").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPos = new Vector3(monster.transform.position.x, monster.transform.position.y + height, monster.transform.position.z);

        Vector3 screenPos = camera.WorldToScreenPoint(worldPos);

        healthSlider.transform.position = new Vector3(screenPos.x, screenPos.y, screenPos.z);

        // healthSlider.transform.LookAt(camera.transform);
    }
}
