/*
 * Author: Adrian, Grace
 * Date: 18/7/2023
 * Description: Basic Player movement
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// The Vector3 used to store the WASD input of the user.
    /// </summary>
    Vector3 movementInput = Vector3.zero;

    /// <summary>
    /// The Vector3 used to store the left/right mouse input of the user.
    /// </summary>
    Vector3 rotationInput = Vector3.zero;

    /// <summary>
    /// The Vector3 used to store the up/down mouse input of the user.
    /// </summary>
    Vector3 headRotationInput;

    /// <summary>
    /// The Vector3 used to be able to clamp the camera.
    /// </summary>
    Vector3 localCameraRot;

    /// <summary>
    /// True if the player can jump
    /// </summary>
    private bool canJump;

    /// <summary>
    /// The amount of upward force to apply to the player when jumping
    /// </summary>
    public float jumpForce;

    /// <summary>
    /// The movement speed of the player per second.
    /// </summary>
    public float baseMoveSpeed = 5f;

    /// <summary>
    /// The speed at which the player rotates
    /// </summary>
    public float rotationSpeed = 60f;

    /// <summary>
    /// The camera attached to the player object
    /// </summary>
    public Transform playerCamera;

    /// <summary>
    /// The Body attached to the player object
    /// </summary>
    public GameObject playerBody;

    bool mouseclick = false;

    /// <summary>
    /// this is for the scene to fade
    /// </summary>
    private nextSceneAnimation transitionFade;

    /// <summary>
    /// These are the numbers and varibles needed for sprinting and the stamina bar
    /// </summary>

    private float sprintSpeed = 9f;
    private float originalSpeed = 5f;

    private GameObject sprintPool;

    private StaminaController stamina;
    public float playerStamina = 100.0f;
    [SerializeField] public float maxStamina = 100.0f;
    public bool weAreSprinting = false;
    public bool hasRegenerated = true;

    /// <summary>
    /// this bool is to make sure the pop up after talking to the maid doesnt trigger again
    /// </summary>
    bool talkToMaid = false;

    /// <summary>
    /// this bool is to make sure the pop up after talking to the maid doesnt trigger again
    /// </summary>
    bool talkToManager = false;

    /// <summary>
    /// this bool is for the player to be unable to move or move their camera when talking to any npc
    /// </summary>
    bool isTalking = false;

    int catsTalkedTo = 0;

    //public int maidNo;
    //public MaidCatSpeak maidSpeaking;

    /// <summary>
    /// things needed to load the forth scene
    /// </summary>
    private UIandAudio accessNoise;
    private GameObject doorS1;
    private GameObject door1UI;
    private GameObject doorNoise1;
    private UIandAudio doorMsg1;

    /// <summary>
    /// things needed to load the third scene
    /// </summary>
    private GameObject doorS2;
    private GameObject door2UI;
    private GameObject doorNoise2;
    private UIandAudio doorMsg2;

    int collectedItems;

    /// <summary>
    /// things needed to load the forth scene
    /// </summary>
    //private UIandAudio accessNoise;
    private GameObject doorS3;
    private GameObject door3UI;
    //private GameObject doorNoise2;
    private UIandAudio doorMsg3;

    /// <summary>
    /// Called when the Move action is detected.
    /// </summary>
    ///  
    /////////////////////////
    
    public int maxHP = 100;
    //int hpGone = -1;
    public bool playerHasBeenAttacked;

    public AudioSource Hit;
    ////////////////////////
    public showGameOver gameOverCanvas;
    void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();

    }

    

    //Player Movement
    private void Movement()
    {
        if (Input.GetKey("left shift"))
        {
            stamina = sprintPool.GetComponent<StaminaController>();
            stamina.sprinting();
            baseMoveSpeed = sprintSpeed;

            weAreSprinting = false;
            Debug.Log("run run run");

        }
        else
        {
            baseMoveSpeed = originalSpeed;


        }
        //Moving forward
        Vector3 forwardDirection = transform.forward;

        //Moving right + left
        Vector3 rightDirection = transform.right;

        //Player Movement
        transform.position += ((forwardDirection * movementInput.y + rightDirection * movementInput.x) * baseMoveSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Called when the Jump action is detected.
    /// </summary>

    void OnJump()
    {
        if (canJump == true)
        {
            this.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }





    /// <summary>
    /// Called when the Look action is detected.
    /// </summary>
    /// <param name="value"></param>
    void OnLook(InputValue value)
    {

        //rotation value for camera to look up and down
        rotationInput.x = -value.Get<Vector2>().y;

        //rotation value for camera to look left and right
        rotationInput.y = value.Get<Vector2>().x;

    }

    /// Player rotation
    private void Rotation()
    {
        //up and down
        localCameraRot.x += rotationInput.x * rotationSpeed * Time.deltaTime;

        //left and right
        localCameraRot.y += rotationInput.y * rotationSpeed * Time.deltaTime;

        //Camera will not go upsidedown
        localCameraRot.x = Mathf.Clamp(localCameraRot.x, -90, 90);

        //Player Camera movement
        playerCamera.localRotation = Quaternion.Euler(localCameraRot.x, transform.rotation.y, 0);

        //Player will move along with the camera direction
        transform.rotation = Quaternion.Euler(0, localCameraRot.y, 0);


    }

    /// <summary>
    /// Called when a collision is detected
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        //Player can only jump while touching the ground
        if (collision.gameObject.tag == "Floor")
        {
            canJump = true;
        }

        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("HealthGone");
            //maxHP += hpGone;
            maxHP = maxHP - 4;
            Debug.Log(maxHP);
            Debug.Log("Player has been hit!");
            playerHasBeenAttacked = true;
            Debug.Log(playerHasBeenAttacked);

            Hit.Play();
            if (maxHP == 0)
            {
                gameOverCanvas.gameOverPopup();
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {

        //Player can only jump while touching the ground
        if (collision.gameObject.tag == "Floor")
        {
            canJump = false;
        }
    }


    void OnFire()
    {



        mouseclick = true;




    }
    // Start is called before the first frame update
    void Start()
    {
        //maidNo = maidSpeaking.talking;

        //Cursor.lockState = CursorLockMode.Locked;
        sprintPool = GameObject.Find("Stamina_Canvas");

        doorS1 = GameObject.Find("doorScene1");
        door1UI = GameObject.Find("doorScene1");
        //doorNoise1 = GameObject.Find("doorsScene1");

        doorS2 = GameObject.Find("doorScene2");
        door2UI = GameObject.Find("doorScene2");
        doorNoise2 = GameObject.Find("doorsScene2");


        doorS3 = GameObject.Find("doorScene3");
        door3UI = GameObject.Find("doorScene3");
        //doorNoise2 = GameObject.Find("doorsScene3");

    }

    // Update is called once per frame
    void Update()
    {
        if ( isTalking == false)
        {
            Movement();
            Rotation();
            RaycastHit hitInfo;
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hitInfo, 3))
            {
                //when in the raycast area infront of the camera and when clicking on the game object to collect, it will update collected items and call collectCode to play a sound and destroy a game object
                if (hitInfo.transform.tag == "collectable" && mouseclick)
                {
                    Debug.Log("collectable" + hitInfo.transform.gameObject.name);
                    Debug.Log("click");
                    collectedItems += 1;
                    hitInfo.transform.GetComponent<collectCode>().Collected();

                }
                if (hitInfo.transform.tag == "doors1" && mouseclick)
                {
                    Debug.Log("ray");
                    Debug.Log(doorS1);
                    if (doorS1 != null) //&& doorNoise1 != null)
                    {
                        //accessNoise = doorNoise1.GetComponent<UIandAudio>();
                        //UIandAudio.doorBGM();
                        transitionFade = doorS1.GetComponent<nextSceneAnimation>();
                        nextSceneAnimation.FadeToLevel2();
                        Debug.Log("click door");
                    }
                }
                if (hitInfo.transform.tag == "doors2" && mouseclick)
                {
                    if (catsTalkedTo < 2)
                    {
                        if (door2UI != null)
                        {
                            doorMsg2 = door2UI.GetComponent<UIandAudio>();
                            UIandAudio.showDoors2Text();
                            //collectListScript.showDoorText();
                        }


                    }
                    else
                    {
                        if (doorS2 != null)// && doorNoise2 != null)
                        {
                            //accessNoise = doorNoise2.GetComponent<UIandAudio>();
                            //UIandAudio.doorBGM();
                            transitionFade = doorS2.GetComponent<nextSceneAnimation>();
                            nextSceneAnimation.FadeToLevel3();
                            Debug.Log("click door");
                        }
                    }



                }
///This is to show a message if player hasnt collected all items, if they did they can enter the next scene
                if (hitInfo.transform.tag == "doors3" && mouseclick)
                {
                    if (collectedItems < 3)
                    {
                        if (door3UI != null)
                        {
                            doorMsg3 = door3UI.GetComponent<UIandAudio>();
                            UIandAudio.showDoors3Text();
                            //collectListScript.showDoorText();
                        }


                    }
                    else
                    {
                        if (doorS3 != null)// && doorNoise2 != null)
                        {
                            //accessNoise = doorNoise2.GetComponent<UIandAudio>();
                            //UIandAudio.doorBGM();
                            transitionFade = doorS3.GetComponent<nextSceneAnimation>();
                            nextSceneAnimation.FadeToLevel4();
                            Debug.Log("click door");
                        }
                    }



                }


            }
        }
        //Debug.Log(canJump);

        mouseclick = false;

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Manager")
        {
            if (talkToManager == false)
            {
                talkToManager = true;
                other.GetComponent<ManagerSpeak>().showManagerUI();
                catsTalkedTo = catsTalkedTo + 1;
            }
            

        }

        if (other.gameObject.tag == "Maid")
        {
            if (talkToMaid == false)
            {
                other.GetComponent<MaidCatSpeak>().showMaidUI();
                talkToMaid = true;
                catsTalkedTo = catsTalkedTo + 1;
                //Debug.Log(catsTalkedTo);
                //isTalking = true;
            }


        }

       
    }

    
}

