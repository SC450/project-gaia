using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum State
{
    Idle,
    Moving,
}

public class Pathfinder : MonoBehaviour
{
    private Animator animator;
    private IEnumerator coroutine;

    [Header("Wandering")]
    public float wanderDistance = 50f;
    public float maxWalkTime = 6f;

    [Header("Idling")]
    public float idleTime = 5f;

    protected NavMeshAgent navAgent;
    protected State currentState = State.Idle;

    public bool redirectAnimal;


    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        Initialise();
    }

    protected virtual void Initialise()
    {
        navAgent = GetComponent<NavMeshAgent>();

        currentState = State.Idle;
        UpdateState();
    }

    protected virtual void UpdateState()
    {
        switch (currentState)
        {
            case State.Idle:
                HandleIdleState();
                break;
            case State.Moving:
                HandleMovingState();
                break;
                
        }
    }

    protected Vector3 GetRandomNavMeshPosition(Vector3 origin, float distance)
    {
        Vector3 randomDirection = Random.insideUnitSphere * distance;
        randomDirection += origin;
        NavMeshHit navMeshHit;

        if (NavMesh.SamplePosition(randomDirection, out navMeshHit, distance, NavMesh.AllAreas))
        {
            return navMeshHit.position;
        }
        else
        {
            return GetRandomNavMeshPosition(origin, distance);
        }
    }
    
    protected virtual void HandleIdleState()
    {
        coroutine = WaitToMove();
        StartCoroutine(coroutine);
    }

    private IEnumerator WaitToMove()
    {
        float waitTime = Random.Range(idleTime / 2, idleTime * 2);
        yield return new WaitForSeconds(waitTime);

        Vector3 randomDestination = GetRandomNavMeshPosition(transform.position, wanderDistance);
        RaycastHit hit;
        while (Physics.Raycast(randomDestination, randomDestination + Vector3.up, out hit, 10f))
        {
            navAgent.ResetPath();
            randomDestination = GetRandomNavMeshPosition(transform.position, wanderDistance);
        }
        navAgent.SetDestination(randomDestination);

        SetState(State.Moving, true);
    }

    protected virtual void HandleMovingState()
    {
        StartCoroutine(WaitToReachDestination());
    }

    private IEnumerator WaitToReachDestination()
    {
        float startTime = Time.time;

        while (navAgent.remainingDistance > navAgent.stoppingDistance)
        {
            if ((Time.time - startTime >= maxWalkTime) || (redirectAnimal)) 
            {
                redirectAnimal = false;
                navAgent.ResetPath();
                SetState(State.Idle, true);
            }
            yield return null;
        }

        SetState(State.Idle, false);
    }

    protected void SetState(State newState, bool animationChanging) 
    {
        if (currentState == newState) {
            return;
        }
        else {
            currentState = newState;
            OnStateChanged(newState, animationChanging);
        }
    }

    protected virtual void OnStateChanged(State newState, bool animationChanging) 
    {
        if (animationChanging) 
        {
            if (newState == State.Idle) 
            {
                animator.SetBool("Run", false);
            }
            else if (newState == State.Moving)
            {
                animator.SetBool("Run", true);
            }
        }
        UpdateState();
    }

    void Update() {
        if (navAgent.velocity == Vector3.zero) {
            animator.SetBool("Run", false);
        }
        else {
            animator.SetBool("Run", true);
        }
    }
}
