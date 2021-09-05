using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{

    public int totalCollectibles = 5;
    public int currentCollected = 0;

    public GameObject S;
    public GameObject S1;
    public GameObject S2;
    public GameObject S3;
    public GameObject S4;

    int SE = 0;
    int SE1 = 0;
    int SE2 = 0;
    int SE3 = 0;
    int SE4 = 0;

    // Start is called before the first frame update
    void Start()
    {



    }

    void Update()
    {
        if (!S)
        {
            SE = 1;
        }

        if (!S1)
        {
            SE1 = 1;
        }

        if (!S2)
        {
            SE2 = 1;
        }

        if (!S3)
        {
            SE3 = 1;
        }

        if (!S4)
        {
            SE4 = 1;
        }
        currentCollected = SE + SE1 + SE2 + SE3 + SE4;

        if (currentCollected == totalCollectibles)
        {
            Debug.Log("will display credits");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }

    // whenever the player collects a chip we will add a point
    public void addPoint()
    {
        Debug.Log(currentCollected);
        currentCollected++;


        if (currentCollected == totalCollectibles)
        {
            Debug.Log("will display credits");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }

    public int myCurrentCollected()
    {

        return currentCollected;


    }
    public int myTotalChips()
    {
        return totalCollectibles;
    }

    public void setScore(int sc)
    {

        currentCollected = sc;


    }
}
