using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CI.QuickSave;
using System.IO;

public enum StatePlayer
{
    Idle, Run, Back,
}

public class Player : MonoBehaviour
{
    public StatePlayer playerState;
    bool footstepsPlaying = false;
    bool playerIsMoving = false;






    bool isgrounded = true;

    public float speed = 1f;
    public float rotationSpeed = 90;
    public float jumpForce = 50f;

    Rigidbody rb;
    Transform t;
    public Animator anim;
    private Vector3 defaultVector;

    private bool movingForward = false;
    private bool movingBackward = false;
    private bool isIdle = true;

    public int maxResource = 100;
    public int currentResource = 100;

    public Slider HPslider;
    public float playerHP;

    public Slider StaBar;
    public float playerSta;

    public ResourceBar resourceBar;

    public MonsterScript monster;

    private GameObject MonsterHP;

    public Slider MonsterSlider;

    private Renderer render;

    public AudioSource audioSource;

    public AudioClip[] audioClips;

    public Transform IGMO;

    public Transform MainPlayer;
    Vector3 currentPos;
    Quaternion currentRot;

    Vector3 defaultPos;
    Quaternion defaultRot;

    public GameObject S;
    public GameObject S1;
    public GameObject S2;
    public GameObject S3;
    public GameObject S4;
    public GameObject DefeatMonster;
    public GameObject BrokenOb;

    public int SE = 0;
    public int SE1 = 0;
    public int SE2 = 0;
    public int SE3 = 0;
    public int SE4 = 0;
    public int DM = 0;

    public ScoreScript scoreManager;

    private int damageStack = 5;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();
        playerHP = HPslider.maxValue;
        playerSta = StaBar.maxValue;
        currentResource = 100;
        resourceBar.SetResource(currentResource);
        Application.targetFrameRate = 60;
        MonsterHP = GameObject.Find("JmoAITest");

        playerState = StatePlayer.Idle;
        render = MonsterHP.GetComponent<Renderer>();

        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioClips[0]);

        if(PlayerPrefs.GetString("Load") == "load")
        {
            var reader = QuickSaveReader.Create("Player");
            var savedpos = reader.Read<Vector3>("currentPos");
            var savedrot = reader.Read<Quaternion>("currentRot");
            var g = reader.Read<int>("SE");
            var g1 = reader.Read<int>("SE1");
            var g2 = reader.Read<int>("SE2");
            var g3 = reader.Read<int>("SE3");
            var g4 = reader.Read<int>("SE4");
            var d = reader.Read<int>("DM");
            var sc = reader.Read<int>("Score");
            if (g == 1)
            {
                Destroy(S);
            }

            if (g1 == 1)
            {
                Destroy(S1);
            }

            if (g2 == 1)
            {
                Destroy(S2);
            }

            if (g3 == 1)
            {
                Destroy(S3);
            }

            if (g4 == 1)
            {
                Destroy(S4);
            }
            if(d == 1)
            {
                Destroy(DefeatMonster);
                Destroy(BrokenOb);
            }
            MainPlayer.transform.position = savedpos;
            MainPlayer.transform.rotation = savedrot;
            

            scoreManager.setScore(sc);
            Debug.Log(scoreManager.myCurrentCollected());
        }


    }

    


    // Update is called once per frame
    void Update()
    {
        // check if can see monster
        if (GameObject.Find("JmoAITest") != null)
        {
            if (render.isVisible)
            {

                MonsterSlider.gameObject.SetActive(true);

            }
            else
            {
                MonsterSlider.gameObject.SetActive(false);
            }
        }



        switch (playerState)
        {
            case StatePlayer.Idle:
                StateIdle();
                break;
            case StatePlayer.Run:
                StateRun();
                break;
            case StatePlayer.Back:
                StateBack();
                break;
        }


        if (Input.GetKey(KeyCode.W))
        {
            
            if (isgrounded == true)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift) && playerSta >= 50)
                {
                    rb.velocity += this.transform.forward * (speed * 30f) * Time.deltaTime;
                    playerSta -= 50;
                    StaBar.value = playerSta;
                }
                else
                {
                    rb.velocity += this.transform.forward * (speed / 1.5f) * Time.deltaTime;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.LeftShift) && playerSta >= 50)
                {
                    rb.velocity += this.transform.forward * (speed * 15f) * Time.deltaTime;
                    playerSta -= 50;
                    StaBar.value = playerSta;
                }
                else
                {
                    rb.velocity += this.transform.forward * (speed / 3f) * Time.deltaTime;
                }
            }
            
        }
        else if (Input.GetKey(KeyCode.S))
        {
            
            if (isgrounded == true)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift) && playerSta >= 50)
                {
                    rb.velocity -= this.transform.forward * (speed * 30f) * Time.deltaTime;
                    playerSta -= 50;
                    StaBar.value = playerSta;
                }
                else
                {
                    rb.velocity -= this.transform.forward * (speed / 2.5f) * Time.deltaTime;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.LeftShift) && playerSta >= 50)
                {
                    rb.velocity -= this.transform.forward * (speed * 15f) * Time.deltaTime;
                    playerSta -= 50;
                    StaBar.value = playerSta;
                }
                else
                {
                    rb.velocity -= this.transform.forward * (speed / 5f) * Time.deltaTime;
                }
            }
            
        }


        if (Input.GetKey(KeyCode.LeftBracket))
        {
            rotationSpeed -= 5;
        }

        if (Input.GetKey(KeyCode.RightBracket))
        {
            rotationSpeed += 5;
        }

        if (Input.GetKey(KeyCode.D))
        {
            t.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            t.rotation *= Quaternion.Euler(0, -rotationSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (isgrounded == true)
            {
                rb.AddForce(t.up * jumpForce);
                isgrounded = false;
            }
            Debug.Log(scoreManager.myCurrentCollected());


        }


        if (Input.GetKey(KeyCode.P))
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

            if (!BrokenOb)
            {
                DM = 1;
            }

            var writer = QuickSaveWriter.Create("Player");
            writer.Write("currentPos",MainPlayer.position);
            writer.Write("currentRot", MainPlayer.rotation);
            writer.Write("SE", SE);
            writer.Write("SE1", SE1);
            writer.Write("SE2", SE2);
            writer.Write("SE3", SE3);
            writer.Write("SE4", SE4);
            writer.Write("DM", DM);
            writer.Write("Score", scoreManager.myCurrentCollected());
            writer.Commit();
            
            Debug.Log("Save Detected");
        }

        if (Input.GetKey(KeyCode.L))
        {
            string loadfile = Application.persistentDataPath + "/QuickSave/Player.json";
            if (!File.Exists(loadfile))
            {
                Debug.Log( "no " + loadfile + " file exists" );
            }
            else
            {
                Debug.Log(loadfile + " file exists, deleting..." );

                File.Delete(loadfile);
            }
        }

        if(playerHP <= 0)
        {
            Application.LoadLevel(0);
        }


    }


    public virtual void StateIdle()
    {
        
        if(playerHP < HPslider.maxValue)
        {
            playerHP += 0.05f;
            HPslider.value = playerHP;
        }

        if(playerSta < StaBar.maxValue)
        {
            playerSta += 1;
            StaBar.value = playerSta;
        }

        if (Input.GetKey(KeyCode.W))
        {
            anim.SetTrigger("Run");
            playerIsMoving = true;
            ChangeRun();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetTrigger("Back");
            playerIsMoving = true;
            ChangeBack();
        }
    }

    public virtual void StateRun()
    {
        if (resourceBar.GiveValue() < resourceBar.GiveMaxResource())
        {
            resourceBar.ExtraRecovery(0.1f);
        }

        if (playerSta > 0)
        {
            playerSta -= 1f;
            StaBar.value = playerSta;
        }

        if(playerSta <= 0)
        {
            if(playerHP > 0)
            {
                playerHP -= 0.1f;
                HPslider.value = playerHP;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            anim.SetTrigger("Back");
            ChangeBack();
        }
        else if (!Input.GetKey(KeyCode.W))
        {
            anim.SetTrigger("Idle");
    
            ChangeIdle();
        }
    }

    public virtual void StateBack()
    {
        if (playerSta > 0)
        {
            playerSta -= 1f;
            StaBar.value = playerSta;
        }

        if (playerSta <= 0)
        {
            if (playerHP > 0)
            {
                playerHP -= 0.1f;
                HPslider.value = playerHP;
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetTrigger("Run");
            ChangeRun();
        }
        else if (!Input.GetKey(KeyCode.S))
        {
            anim.SetTrigger("Idle");
            ChangeIdle();
        }
    }

    public virtual void ChangeIdle()
    {
        playerState = StatePlayer.Idle;
    }
    public virtual void ChangeRun()
    {
        playerState = StatePlayer.Run;
    }
    public virtual void ChangeBack()
    {
        playerState = StatePlayer.Back;
    }





    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "vampire_a_lusth@Capoeira" && monster.CurrentState == State.Attack)
        {

            // printing if collision is detected on the console
            Debug.Log("Collision Detected");


            playerHP -= damageStack;
            damageStack += 5;

            HPslider.value = playerHP;
            
        }
        

        if ((collision.gameObject.tag == "Ground") || (collision.gameObject.tag == "Obstacle"))
        {
            isgrounded = true;
        }

        if (collision.gameObject.name == "YakuzaMember")
        {
            playerHP -= 10;
            HPslider.value = playerHP;

        }



    }



}
