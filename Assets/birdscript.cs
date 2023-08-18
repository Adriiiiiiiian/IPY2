using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class birdscript : MonoBehaviour
{
    //Variables
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask GroundLayerM, PlayerM;

    private Vector3 groundLayer;

    public float moveSpeed = 3.0f;

    public PlayerController scripting;

    public AudioSource tweet;
    //Attack
    bool alreadyAttack;
    bool attackPlayer;

    //States
    public string currentState;
    public string nextState;
    
    //Random attack time
    public int minMinutes = 1;
    public int maxMinutes = 5;  
    
    //To find player
    private void LookForPlayer()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        //Define new vector 3
        groundLayer = new Vector3(0, 2f, 0);
    }

    

     private void Start()
    {
        currentState = "Still";
        nextState = currentState ;
        SwitchState();
    }
    
    private void SwitchState()
    {
        StartCoroutine(currentState);
    }

    private void Update()
    {
        if(nextState != currentState)
        {
            currentState = nextState;
            Debug.Log(nextState);
        }
    }
    IEnumerator Still()

    {
        Debug.Log("Still Motion");
        bool stillAi = true;
        scripting.playerHasBeenAttacked = false;
        while(stillAi)
        {
            if(attackPlayer == false)
            {
                int randomInt = 5 * (Random.Range(minMinutes, maxMinutes));
                Debug.Log(randomInt);
                yield return new WaitForSeconds(randomInt);         
                nextState = "Attack";
                stillAi = false;
            }
            yield return new WaitForEndOfFrame();
        }
        Debug.Log("Switched state");
        SwitchState();
    }

    IEnumerator Attack()
    {
        //attackPlayer = true;
        Debug.Log("Attacking");
        bool attackAi = true;
        Debug.Log(currentState);
        tweet.Play();
        while(attackAi)
        {
            Debug.Log("testing");
            if(attackPlayer == false)
            {                
                Debug.Log("Attack player has changed to true");
                    if (!alreadyAttack)
                    {   
                        
                        // Calculate direction towards the player
                        //Vector3 direction = (player.position - transform.position).normalized;
            
                        // Move the enemy towards the player
                        //transform.Translate(direction * moveSpeed * Time.deltaTime);

                        // Calculate the direction to the player in local space
                        Vector3 localDirection = transform.InverseTransformPoint(player.position).normalized;
            
                        // Move the enemy forward based on local direction
                        transform.Translate(localDirection * moveSpeed * Time.deltaTime);
            
                        // Rotate the enemy to face its local forward direction
                        float targetAngle = Mathf.Atan2(localDirection.x, localDirection.z) * Mathf.Rad2Deg;
                        transform.rotation = Quaternion.Euler(0, targetAngle, 0);
                        
                        
                    
                    }

                if(scripting.playerHasBeenAttacked)

                {
                    nextState = "Still";

                    Debug.Log("Attack player has changed to FALSE");

                    attackAi = false;

                }
            }
            yield return new WaitForEndOfFrame();
        }
        SwitchState();
    }
}