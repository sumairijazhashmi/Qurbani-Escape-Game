using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// reference: https://gist.github.com/Fonserbc/ca6bf80b69914740b12da41c14023574

public class SwipeControls : MonoBehaviour
{

	private float MIN_SWIPE_DISTANCE = (20/100) * Screen.width;

	public bool MoveRight = false;
	public bool MoveLeft = false;
	public bool Jump = false;

	Vector2 startPosition;

	public void Update()
	{
		MoveRight = MoveLeft = Jump = false;

		if (Input.touchCount > 0)
		{
			Touch currentTouch = Input.GetTouch(0);
			if (currentTouch.phase == TouchPhase.Began)
			{
				startPosition = new Vector2(currentTouch.position.x / (float)Screen.width, currentTouch.position.y / (float)Screen.width);
			}
			if (currentTouch.phase == TouchPhase.Ended)
			{

				Vector2 endPosition = new Vector2(currentTouch.position.x / (float)Screen.width, currentTouch.position.y / (float)Screen.width);

				Vector2 swipeDirection = new Vector2(endPosition.x - startPosition.x, endPosition.y - startPosition.y);

				if (swipeDirection.magnitude < MIN_SWIPE_DISTANCE) // Too short swipe
					return;

				if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
				{ 
					if (swipeDirection.x > 0)
					{
						MoveRight = true;
					}
					else
					{
						MoveLeft = true;
					}
				}
				else
				{ 
					if (swipeDirection.y > 0)
					{
						Jump = true;
					}
				}
			}
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
