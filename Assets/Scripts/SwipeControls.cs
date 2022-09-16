using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// https://gist.github.com/Fonserbc/ca6bf80b69914740b12da41c14023574

/*
 * Swipe Input script for Unity by @fonserbc, free to use wherever
 *
 * Attack to a gameObject, check the static booleans to check if a swipe has been detected this frame
 * Eg: if (SwipeInput.swipedRight) ...
 *
 * 
 */

public class SwipeControls : MonoBehaviour
{

	// If the touch is longer than MAX_SWIPE_TIME, we dont consider it a swipe
	public const float MAX_SWIPE_TIME = 0.5f;

	// Factor of the screen width that we consider a swipe
	// 0.17 works well for portrait mode 16:9 phone
	public const float MIN_SWIPE_DISTANCE = 0.17f;

	public bool swipedRight = false;
	public bool swipedLeft = false;
	public bool swipedUp = false;
	public bool swipedDown = false;


	public bool debugWithArrowKeys = true;

	Vector2 startPos;
	float startTime;

	public void Update()
	{
		swipedRight = false;
		swipedLeft = false;
		swipedUp = false;
		swipedDown = false;

		if (Input.touches.Length > 0)
		{
			Touch t = Input.GetTouch(0);
			if (t.phase == TouchPhase.Began)
			{
				startPos = new Vector2(t.position.x / (float)Screen.width, t.position.y / (float)Screen.width);
				startTime = Time.time;
			}
			if (t.phase == TouchPhase.Ended)
			{
				if (Time.time - startTime > MAX_SWIPE_TIME) // press too long
					return;

				Vector2 endPos = new Vector2(t.position.x / (float)Screen.width, t.position.y / (float)Screen.width);

				Vector2 swipe = new Vector2(endPos.x - startPos.x, endPos.y - startPos.y);

				if (swipe.magnitude < MIN_SWIPE_DISTANCE) // Too short swipe
					return;

				if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
				{ // Horizontal swipe
					if (swipe.x > 0)
					{
						swipedRight = true;
					}
					else
					{
						swipedLeft = true;
					}
				}
				else
				{ // Vertical swipe
					if (swipe.y > 0)
					{
						swipedUp = true;
					}
					else
					{
						swipedDown = true;
					}
				}
			}
		}

		if (debugWithArrowKeys)
		{
			swipedDown = swipedDown || Input.GetKeyDown(KeyCode.DownArrow);
			swipedUp = swipedUp || Input.GetKeyDown(KeyCode.UpArrow);
			swipedRight = swipedRight || Input.GetKeyDown(KeyCode.RightArrow);
			swipedLeft = swipedLeft || Input.GetKeyDown(KeyCode.LeftArrow);
		}
	}
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System;
//using System.Linq;

//public class SwipeControls : MonoBehaviour
//{


////    private Vector2 startPosition = Vector2.zero;
////    private Vector2 endPosition;
////    private Vector2 direction;
////    private float swipeThreshold;
////    public bool MoveLeft, MoveRight, Jump, MoveForward;

////    private void Start()
////    {
////        swipeThreshold = Screen.height * (20 / 100); // 20% of the screen height  
////        MoveLeft = MoveRight = false;
////        direction = Vector2.zero;
////    }

////    // Update is called once per frame
////    void Update()
////    {
////        // unity remote app to test 
////        // MOUSE CONTROL
////        //if(Input.GetMouseButtonDown(0))
////        //{
////        //    startPosition = Input.mousePosition;
////        //}
////        //else if(Input.GetMouseButtonUp(0))
////        //{
////        //    // https://findnerd.com/list/view/How-to-get-mouse-swipe-input-in-Unity--3D/9713/

////        //    endPosition = Input.mousePosition;
////        //    float disX = Mathf.Abs(startPosition.x - endPosition.x);
////        //    float disY = Mathf.Abs(startPosition.y - endPosition.y);
////        //    print("startPosition.x: " + startPosition.x + " ; endPosition.x: " + endPosition.x + "; startPosition.y: " + startPosition.y + " ; endPosition.y: " + endPosition.y);


////        //    direction.x = disX;
////        //    direction.y = disY;
////        //    MovePlayer();
////        //}
////        if (Input.touchCount > 0)
////        {
////            Touch currentTouch = Input.GetTouch(0);
////            if (currentTouch.phase == TouchPhase.Began)
////            {
////                startPosition = currentTouch.position;
////            }
////            else if (currentTouch.phase == TouchPhase.Ended)
////            {
////                endPosition = currentTouch.position;
////                float disX = Mathf.Abs(startPosition.x - endPosition.x);
////                float disY = Mathf.Abs(startPosition.y - endPosition.y);
////                //print("startPosition.x: " + startPosition.x + " ; endPosition.x: " + endPosition.x + "; startPosition.y: " + startPosition.y + " ; endPosition.y: " + endPosition.y);


////                direction.x = disX;
////                direction.y = disY;
////                MovePlayer();
////            }
////        }
//    }

////    public void Reset()
////    {
////        startPosition = Vector2.zero;
////        endPosition = Vector2.zero;
////        Jump = MoveLeft = MoveRight = MoveForward = false;
////    }

////    void MovePlayer()
////    {
////        // if greater than threshold, find direction in which moved
////        // if direction.x > direction.y then move left/right (need to rotate here as well)
////        //print("direction.x " + direction.x + " direction.y " + direction.y);
////        if (direction.x > 0 || direction.y > 0)
////        {
////           if(direction.x <= 150f)
////           {
////                // move left
////                //Debug.Log("move left");
////                MoveLeft = true;
////           }
////           else if(direction.x > direction.y)
////           {
////                // move right
////                //Debug.Log("move right");
////                MoveRight = true;
////            }
////            else if(direction.y > direction.x)
////            {
////                // jump
////                //Debug.Log("jump");
////                MoveForward = true;
////            }
////            //if (direction.x > direction.y )
////            //{
////            //    if (endPosition.x < 0)
////            //    {
////            //        print("im here");
////            //        MoveLeft = true;
////            //    }
////            //    else 
////            ////    {
////            //        MoveRight = true;
////            //    }
////            //}
////            //else
////            //{
////            //    if (startPosition.y > endPosition.y)
////            //    {
////            //    }
////            //    else
////            //    {
////            //        MoveForward = true;
////            //        //print(MoveForward);
////            //    }
////            //}
////        }
////    }
////}
