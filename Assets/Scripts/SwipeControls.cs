using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControls : MonoBehaviour
{
    // basic idea taken from Unity forums/youtube videos
    
    

  
  
    
    // else move up/down

   
    private Vector2 startPosition;
    private Vector2 endPosition;
    private bool isSwipe;
    private float swipeThreshold;
    public bool MoveLeft, MoveRight, MoveForward, MoveBackward;

    private void Start()
    {
        swipeThreshold = Screen.height * (20 / 100); // 20% of the screen height  
        isSwipe = false;
        MoveBackward = MoveForward = MoveLeft = MoveRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        // unity remote app to test 
        // MOUSE CONTROL
        if(Input.GetMouseButtonDown(0))
        {
            isSwipe = true;
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
            print("sadness");
            isSwipe = true;
            MovePlayer(distanceM);
            //Reset();
        }

        // TOUCH SWIPE CONTROL
        if (Input.touchCount > 0)
        {
            Touch currentTouch = Input.GetTouch(0); // get touch

            //TouchPhase.Moved
                //currentTouch.deltaPosition
            // if user started to touch
            if (currentTouch.phase == TouchPhase.Began)
            {
                isSwipe = true;
                startPosition = currentTouch.position; // update start pos
            }

            // if user is moving then update end pos
            if (currentTouch.phase == TouchPhase.Ended)
            {
                isSwipe = false;
                endPosition = currentTouch.position;
            }

            // if user has ended touch
            if (currentTouch.phase == TouchPhase.Ended)
            {
                endPosition = currentTouch.position; // update end pos
                Vector2 distanceT = endPosition - startPosition;
                // distance of swipe > threshold, then carry out the swipe
                if (distanceT.x > swipeThreshold || distanceT.y > swipeThreshold)
                {
                    isSwipe = true;
                    MovePlayer(distanceT);
                    isSwipe = false;
                }
            }
        }


    }

    public void Reset()
    {
        startPosition = Vector2.zero;
        endPosition = Vector2.zero;
        isSwipe = false;
        MoveForward = MoveBackward = MoveLeft = MoveRight = false;
    }

    void MovePlayer(Vector2 direction)
    {
        if(isSwipe == false)
        {
            return;
        }
        // if greater than threshold, find direction in which moved
        // if direction.x > direction.y then move left/right (need to rotate here as well)
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if(direction.x > 0)
            {
                // swipe right
                MoveRight = true;

            }
            else
            {
                MoveLeft = true;
            }
        }
        // else move up/don
        else if(Mathf.Abs(direction.y) > Mathf.Abs(direction.x))
        {
            if(direction.y > 0)
            {
                MoveForward = true;
            }
            else
            {
                MoveBackward = true;
            }
        }
        //Reset();
    }
}
