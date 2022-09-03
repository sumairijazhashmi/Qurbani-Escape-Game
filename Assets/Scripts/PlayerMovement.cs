using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public SwipeControls controls;
    public Player player;
    public Transform playerTransform;
    private float jumpVelocity;
    private float groundTimer;
    private float jumpHeight = 1.0f;
    private float g = 9.81f;
    private bool isOnGround = true;
    private CharacterController characterController;
    private string GroundTag = "Ground";

    // constant face direction/rotation of animal with the current camera angle. Values taken from inspector 

    private void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }

    //private Vector3 FORWARD_ROTATION
    //{
    //    get
    //    {
    //        return new Vector3(0, 192.537f, 0); 
    //    }
    //}

    //private Vector3 BACKWARD_ROTATION
    //{
    //    get
    //    {
    //        return new Vector3(0, 372.537f, 0);
    //    }
    //}

    private Vector3 RIGHT_ROTATION
    {
        get
        {
            return new Vector3(0, 90f, 0);
        }
    }

    private Vector3 LEFT_ROTATION
    {
        get
        {
            return new Vector3(0, 270f, 0);
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (isOnGround)
        {
            // cooldown interval to allow reliable jumping even whem coming down ramps
            groundTimer = 0.2f;
        }
        if (groundTimer > 0)
        {
            groundTimer -= Time.deltaTime;
        }

        // slam into the ground
        if (isOnGround && jumpVelocity < 0)
        {
            // hit ground
            jumpVelocity = 0f;
        }

        // apply gravity always, to let us track down ramps properly
        jumpVelocity -= g * Time.deltaTime;

    
        // allow jump as long as the player is on the ground
        if (controls.Jump)
        {
            // must have been grounded recently to allow jump
            if (groundTimer > 0)
            {
                // no more until we recontact ground
                groundTimer = 0;

                // Physics dynamics formula for calculating jump up velocity based on height and gravity
                jumpVelocity += Mathf.Sqrt(jumpHeight * 2 * g);
            }
        }

   

// get current rotation

        //if(controls.MoveForward)
        //{
            
        //    // rotation if currentRotation != Foward_Rotation
        //    if (currentRotation != FORWARD_ROTATION)
        //    {
        //        playerTransform.transform.eulerAngles = FORWARD_ROTATION;

        //    }
        //    //desiredPosition += Vector3.forward; // youtube video
        //}   
        //if(controls.MoveBackward)
        //{
        //    // rotation if currentRotation != Backward_Rotation
        //    if (currentRotation != BACKWARD_ROTATION)
        //    {
        //        playerTransform.transform.eulerAngles = BACKWARD_ROTATION;
        //    }
        //    //desiredPosition += Vector3.back;
        //}
       if (controls.MoveRight)
        {
            // rotation if currentRotation != Right_Rotation
            if (PlayerRaycast.canMoveRight)
            {
                transform.eulerAngles += RIGHT_ROTATION;
            }
            //desiredPosition += Vector3.right;
            // move
        }
        if (controls.MoveLeft)
        {
            // rotation if currentRotation != ;Left_Rotation
            //playerTransform.transform.eulerAngles += LEFT_ROTATION;
            if(PlayerRaycast.canMoveLeft)
            {
                transform.eulerAngles += LEFT_ROTATION;
            }
        }
        // move
        Vector3 move = transform.forward * player.Speed;
        move.y += jumpVelocity;
        //playerTransform.transform.position = Vector3.MoveTowards(playerTransform.transform.position, desiredPosition, 3f * Time.deltaTime);
        characterController.Move(move * Time.deltaTime);

        controls.Reset();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(GroundTag))
        {
            isOnGround = true;
        }
    }
}
