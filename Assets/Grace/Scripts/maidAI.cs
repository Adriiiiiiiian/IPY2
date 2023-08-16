/*
 * Author: Grace Foo
 * Date: 7/8/2023
 * Description: Code for AI of the maid
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

    Coroutine startCouroutine;

    public MaidCatSpeak speakingScript;

    string currentState;
    string nextState;

    public int talk;

    // Start is called before the first frame update
    void Start()
    {
        //talk = talk.talking;
        speakingScript = FindObjectOfType<MaidCatSpeak>();
        //talking = GetComponent<MaidCatSpeak>();
        agent = GetComponent<NavMeshAgent>();
        updateDestination();

        currentState = "walking";
        nextState = currentState;
        SwitchState();
    }

    // Update is called once per frame
    void Update()
    {
        //talk = GetComponent<MaidCatSpeak>().talking;
        //talk = speakingScript.talking;

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
        Debug.Log("testing1");
        updateDestination();

        while (talk == 0)
        {
            talk = speakingScript.talking1;
            Debug.Log(talk);
            if (Vector3.Distance(transform.position, target) < 1)
            {
                iterateWaypointIndex();
                updateDestination();
                Debug.Log(" walking ");
            }

            nextState = "standing";
            yield return new WaitForEndOfFrame();
        }

        SwitchState();
    }

    void SwitchState()
    {
        StartCoroutine(currentState);
    }
    /// <summary>
    ///  when talk = 1 then state switches and the ai stops
    /// </summary>
    /// <returns></returns>
    IEnumerator standing()
    {
        while (talk == 1)
        {
            Debug.Log(speakingScript.talking1);
            talk = speakingScript.talking1;
            StopEnemy();

            nextState = "walking";
            yield return new WaitForEndOfFrame();
        }
        Debug.Log("out");
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
