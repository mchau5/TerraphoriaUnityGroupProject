
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum State
{
    Idle, Walk, Attack, Damage, Dead,
}

public class FSM : MonoBehaviour
{
    public State CurrentState;
    public Transform player;
    public float distance;

    

    private void Start()
    {
        CurrentState = State.Idle;
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {   
        distance = Vector3.Distance(player.transform.position, transform.position);

        switch (CurrentState)
        {
            case State.Idle:
                StateIdle();
                break;
            case State.Walk:
                StateWalk();
                break;
            case State.Attack:
                StateAttack();
                break;
            case State.Damage:
                StateDamage();
                break;
            case State.Dead:
                StateDead();
                break;
        }
    }
    
    public virtual void StateIdle()
    {

    }

    public virtual void StateWalk()
    {

    }

    public virtual void StateAttack()
    {

    }

    public virtual void StateDamage()
    {

    }

    public virtual void StateDead()
    {

    }
    
    public virtual void ChangeIdle()
    {
        CurrentState = State.Idle;
    }
    public virtual void ChangeWalk()
    {
        CurrentState = State.Walk;
    }
    public virtual void ChangeAttack()
    {
        CurrentState = State.Attack;
    }
    public virtual void ChangeDamage()
    {
        CurrentState = State.Damage;
    }
    public virtual void ChangeDead()
    {
        CurrentState = State.Dead;
        
    }
}