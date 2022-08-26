using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public SwipeControls controls;
    public Player player;
    public Transform playerTransform;
    private Vector3 desiredPosition;

    private CharacterController characterController;

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
        // get current rotation
        Vector3 currentRotation = playerTransform.transform.rotation.eulerAngles;

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

            transform.eulerAngles += RIGHT_ROTATION;

            //desiredPosition += Vector3.right;
            // move
        }
        if (controls.MoveLeft)
        {
            // rotation if currentRotation != ;Left_Rotation
            //playerTransform.transform.eulerAngles += LEFT_ROTATION;
            transform.eulerAngles += LEFT_ROTATION;
        }
        // move
        //playerTransform.transform.position = Vector3.MoveTowards(playerTransform.transform.position, desiredPosition, 3f * Time.deltaTime);
        characterController.Move(transform.forward * player.Speed * Time.deltaTime);

        controls.Reset();
    }
}
