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
    [SerializeField] float jumpHeight = 20f;
    [SerializeField] float g = -8f;
    private CharacterController characterController;
    private string GroundTag = "Ground";
    Vector3 move;
    

    private void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        move = transform.forward * player.Speed;
    }

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
        if (controls.MoveForward)
        {
            if (characterController.isGrounded)
            {
                //print("Jumped");
                move.y = jumpHeight;
            }
        }
        if (controls.MoveRight)
        {
            if (PlayerRaycast.canMoveRight)
            {
                transform.eulerAngles += RIGHT_ROTATION;
                move = transform.forward * player.Speed;
            }
        }
        if (controls.MoveLeft)
        {
            if(PlayerRaycast.canMoveLeft)
            {
                transform.eulerAngles += LEFT_ROTATION;
                move = transform.forward * player.Speed;
            }
        }
        move.y += g * Time.deltaTime;
        characterController.Move(move * Time.deltaTime);
        controls.Reset();
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("Enter collision");
        if (hit.collider.tag == "obstacle")
        {
            Time.timeScale = 0;
            player.CurrentState = Player.PlayerState.Dead;
        }
    }
    //private void (Collision collision)
    //{
    //    Debug.Log("Enter collision");
    //    if (collision.collider.tag == "obstacle")
    //    {
    //        Time.timeScale = 0;
    //        player.CurrentState = Player.PlayerState.Dead;
    //    }
    //}
}
