using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class MonsterScript : FSM
{
    private Animator ani;
    private NavMeshAgent agent;
    private Coroutine async;
    private bool AttackLock;
    private float CD = 2f;

    private AudioSource audio;

    public Slider Slider;
    public float CurrentHP;
    private Rigidbody Monster;

    public GameObject avatar;
    public GameObject firstObstacle;

    public Transform m1;

    Vector3 startPos;
    Quaternion startRot;

    private int damageStack = 5;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        Monster = GetComponent<Rigidbody>();
        
        CurrentHP = Slider.maxValue;
        AttackLock = false;

        startPos = m1.position;
        startRot = m1.rotation;
    }

    public override void StateIdle()
    {
        CurrentHP = Slider.maxValue;
        Slider.value = CurrentHP;
        m1.transform.position = startPos;
        m1.transform.rotation = startRot;
        damageStack = 5;
        if (distance < 15)
        {
            ChangeWalk();
        }
    }

    public override void StateWalk()
    {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        agent.speed = 1f;
        agent.SetDestination(player.transform.position);
        ani.SetFloat("Speed", speedPercent, 0.1f, Time.deltaTime);
        if (distance < 1.25f)
        {
            ChangeAttack();
        }
        if (distance > 15)
        {
            agent.speed = 0f;

            ChangeIdle();
        }
    }

    public override void StateAttack()
    {
        if (AttackLock == false)
        {
            int j = Random.Range(0, 2);
            AttackLock = true;
            agent.speed = 0f;
            gameObject.transform.LookAt(player.transform.position);
            if (j == 0) ani.SetTrigger("Attack1");
            else ani.SetTrigger("Attack2");

            if (async != null)
            {
                StopCoroutine(StateChange());
            }
            async = StartCoroutine(StateChange());
        }



        if (distance > 15)
        {
            ChangeIdle();
        }
    }

    public override void StateDamage()
    {
        agent.speed = 0;
        
    }

    public override void StateDead()
    {
        agent.speed = 0;
        
        Destroy(avatar, 5);
        
    }

    public override void ChangeIdle()
    {
        ani.SetTrigger("Idle");
        base.ChangeIdle();
    }

    public override void ChangeWalk()
    {
        ani.SetTrigger("Walk");

        base.ChangeWalk();
    }

    public override void ChangeDamage()
    {
        ani.SetTrigger("Damage");
        if (async != null)
        {
            StopCoroutine(async);
        }
        async = StartCoroutine(StateChange());
        base.ChangeDamage();
    }

    public override void ChangeDead()
    {
        ani.SetTrigger("Die");
        Monster.constraints = RigidbodyConstraints.FreezeRotation;
        Monster.constraints = RigidbodyConstraints.FreezePosition;
        base.ChangeDead();
    }

    private IEnumerator StateChange()
    {
        yield return new WaitForSeconds(CD);
        AttackLock = false;
        async = null;
        if(CurrentHP <= 0)
        {
            ChangeDead();
        }
        else if (distance > 2f)
        {
            ChangeWalk();
        }
        else
        {
            ChangeAttack();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (CurrentHP > 0)
        {
            if (collision.gameObject.name == "bullet(Clone)")
            {

                // printing if collision is detected on the console
                Debug.Log("Collision Detected");
                
                audio.Play();

                if (Random.Range(0, 10) > 7)
                {
                    CurrentHP -= damageStack * 2;
                }
                else
                {
                    CurrentHP -= damageStack;
                }
                damageStack += 2;
                Slider.value = CurrentHP;
                if (CurrentHP <= 0)
                {
                    Destroy(firstObstacle);
                    ChangeDead();
                    
                }
                ChangeDamage();
                
                

            }
        }
        
    }


}
