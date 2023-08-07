/*
 * Author: Grace Foo
 * Date: 7/8/2023
 * Description: Code for the ai of the maid
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class maidAI : MonoBehaviour
{
    public NavMeshAgent agent;

    int waypointIndex;
    Vector3 target;
    public Transform[] waypoints;

    //bool talking = false;
    MaidCatSpeak talking;

    string currentState;
    string nextState;

    // Start is called before the first frame update
    void Start()
    {
        talking = FindObjectOfType<MaidCatSpeak>();
        agent = GetComponent<NavMeshAgent>();
        updateDestination();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(talking);

        if (currentState != nextState)
        {
            currentState = nextState;
        }

        //else
        //{
        // StopEnemy();
        //}

    }
    IEnumerator walking()
    {
        while (talking = 0)
        {
            if (Vector3.Distance(transform.position, target) < 1)
            {
                iterateWaypointIndex();
                updateDestination();
            }


            yield return new WaitForEndOfFrame();
        }

        SwitchState();
    }

    void SwitchState()
    {
        StartCoroutine(currentState);
    }

    IEnumerator standing()
    {
        while (talking = 1)
        {
            StopEnemy();


            yield return new WaitForEndOfFrame();
        }

        SwitchState();
    }

    void updateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
        agent.isStopped = false;

    }

    void iterateWaypointIndex()
    {
        waypointIndex++;
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }

    private void StopEnemy()
    {
        agent.isStopped = true;
    }

}
