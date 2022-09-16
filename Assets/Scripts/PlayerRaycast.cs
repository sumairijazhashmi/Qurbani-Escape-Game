using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField] float raycastTravel = 1;
    public static bool canMoveLeft;
    public static bool canMoveRight;
    void Update()
    {
        bool raycastRightHit = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out RaycastHit rightHitInfo, raycastTravel);
        bool raycastLeftHit = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out RaycastHit leftHitInfo, raycastTravel);
           
        if(raycastRightHit)
        {
            //Debug.Log("Hit on right");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * rightHitInfo.distance, Color.red);
            if(rightHitInfo.collider.tag == "path")
			canMoveRight = true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 20f, Color.green);
            canMoveRight = false;
        }
        if (raycastLeftHit)
        {
            //Debug.Log("Hit on left");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * leftHitInfo.distance, Color.blue);
            if(leftHitInfo.collider.tag == "path")
			canMoveLeft = true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * 2f, Color.green);
            canMoveLeft = false;
        }
    }
}
