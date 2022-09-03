using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class SwipeControls : MonoBehaviour
{
    private Vector2 startPosition = Vector2.zero;
    private Vector2 endPosition;
    private bool isSwipe, isTouch;
    private float swipeThreshold;
    public bool MoveLeft, MoveRight, Jump;

    private void Start()
    {
        swipeThreshold = Screen.height * (20 / 100); // 20% of the screen height  
        isSwipe = false;
        MoveLeft = MoveRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        // unity remote app to test 
        // MOUSE CONTROL
        if(Input.GetMouseButtonDown(0))
        {
            isSwipe = true;
            isTouch = true;
            startPosition = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            isSwipe = false;
            endPosition = Input.mousePosition;
        }
        Vector2 distanceM = endPosition - startPosition;
        // distance of swipe > threshold, then carry out the swipe
        if (distanceM.x > swipeThreshold || distanceM.y > swipeThreshold)
        {
            //print("sadness");
            isSwipe = true;
            MovePlayer(distanceM);
            //Reset();
        }
        else if(isTouch == true)
        {
            Jump = true;
        }

        // TOUCH SWIPE CONTROL
        //if (Input.touchCount > 0)
        //{
        //    Touch currentTouch = Input.GetTouch(0); // get touch

        //    //TouchPhase.Moved
        //        //currentTouch.deltaPosition
        //    // if user started to touch
        //    if (currentTouch.phase == TouchPhase.Began)
        //    {
        //        isSwipe = true;
        //        startPosition = currentTouch.position; // update start pos
        //    }

        //    // if user is moving then update end pos
        //    if (currentTouch.phase == TouchPhase.Ended)
        //    {
        //        isSwipe = false;
        //        endPosition = currentTouch.position; // update end pos

        //    }
                
        //    Vector2 distanceT = endPosition - startPosition;
        //    // distance of swipe > threshold, then carry out the swipe
        //    if (distanceT.x > swipeThreshold || distanceT.y > swipeThreshold)
        //    {
        //        isSwipe = true;
        //        Debug.Log("x: " + distanceT.x + "; y: " + distanceT.y);
        //        MovePlayer(distanceT);
        //    }
           
        //}
    }

    public void Reset()
    {
        startPosition = Vector2.zero;
        endPosition = Vector2.zero;
        isTouch = isSwipe = false;
        Jump = MoveLeft = MoveRight = false;
    }

    void MovePlayer(Vector2 direction)
    {
        if(!isSwipe)
        {
            return;
        }
        // if greater than threshold, find direction in which moved
        // if direction.x > direction.y then move left/right (need to rotate here as well)
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {

            //MoveRight = true;
            //print("i am called");
            if (direction.x > 0)
                //{
                //    // swipe right
                MoveRight = true;

        }
        else
        {
            MoveLeft = true;
        }
        //else
        //{
        //    MoveLeft = true;
        //}
        // else move up/don
        //else if(Mathf.Abs(direction.y) > Mathf.Abs(direction.x))
        //{
        //    if(direction.y > 0)
        //    {
        //        MoveForward = true;
        //    }
        //    else
        //    {
        //        MoveBackward = true;
        //    }
        //}
        //Reset();
    }
}
