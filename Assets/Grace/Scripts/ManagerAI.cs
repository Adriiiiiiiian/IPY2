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

    void Patrolling()
    {
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            Vector3 point;
            if(RandomPoint(centrepoint.position, range, out point))
            {
                agent.SetDestination(point);
            }
        }
    }

    void StopEnemy()
    {
        agent.isStopped = true;

    }

    void ChasePlayer()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        Vector3 nearPlayer = new Vector3(player.position.x,player.position.y,player.position.z);

        if(distance <= detect)
        {
            agent.SetDestination(nearPlayer);

        }

    }

    IEnumerator Behaviour()
    {
        if(speakingScript.talking == 0)
        {
            Patrolling();

            if(talked == false)
            {
                ChasePlayer();
            }
            

        }

        if(speakingScript.talking == 1)
        {
            StopEnemy();

            yield return new WaitForSeconds(25);

            speakingScript.talking = 0;
            agent.isStopped = false;
            talked = true; 
        }
        
        
        
    }

    

    
    
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        player = GameObject.Find("Body").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Behaviour());

        
    }
}
