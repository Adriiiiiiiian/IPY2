/*
 * Author: Adrian
 * Date: 9/8/2023
 * Description: Code for AI of the manager
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ManagerAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public float range;
    public Transform centrepoint;
    public Transform player;

    public float detect = 5f;

    public ManagerSpeak speakingScript;
    public bool talked = false;

    

    

    
    
    private string currentstate;
    private string nextstate;
    
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randompoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randompoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    IEnumerator Patrolling()
    {
        if(currentstate == "Patrolling")
        {
            agent.isStopped = false;
            if(agent.remainingDistance <= agent.stoppingDistance)
            {
                Vector3 point;
                if(RandomPoint(centrepoint.position, range, out point))
                {
                    agent.SetDestination(point);
                    yield return new WaitForEndOfFrame();
                }
            }
        }

        
    }

    IEnumerator StopEnemy()
    {
        talked = true;
        if(currentstate == "StopEnemy")
        {
            agent.isStopped = true;
            yield return new WaitForEndOfFrame();
        }

    }

    IEnumerator ChasePlayer()
    {


        if(currentstate == "ChasePlayer")
        {
            
            agent.SetDestination(player.position);
            yield return new WaitForEndOfFrame();

            
        }

    }

    IEnumerator Behaviour()
    {

        float distance = Vector3.Distance(player.position, transform.position);
        if(speakingScript.talking == 0)
        {
            nextstate = "Patrolling";
            
            if(distance <= detect)
            {
                if(talked != true)
                {
                    Debug.Log("sdkihfvsihfbaijd");
                    nextstate = "ChasePlayer";
                }
            }
        }

        if(speakingScript.talking == 1)
        {

            nextstate = "StopEnemy";
            yield return new WaitForSeconds(40);
            speakingScript.talking = 0;
            

        }

        SwitchState();

    }

    private void SwitchState()
    {
        StartCoroutine(currentstate);
    }

    private void runStateMachine()
    {
        if(nextstate != currentstate)
        {
            currentstate = nextstate;
        }
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        player = GameObject.Find("Body").GetComponent<Transform>();
        
        nextstate = "Patrolling";
        runStateMachine();
        SwitchState();

        
        
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        SwitchState();
        runStateMachine();
        StartCoroutine(Behaviour());

        
        //Debug.Log(nextstate);

        

        
        

        

        
    }
}