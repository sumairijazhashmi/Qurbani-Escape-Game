using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class SwipeControls : MonoBehaviour
{
    private Vector2 startPosition = Vector2.zero;
    private Vector2 endPosition;
    private Vector2 direction;
    private float swipeThreshold;
    public bool MoveLeft, MoveRight, Jump, MoveForward;

    private void Start()
    {
        swipeThreshold = Screen.height * (20 / 100); // 20% of the screen height  
        MoveLeft = MoveRight = false;
        direction = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // unity remote app to test 
        // MOUSE CONTROL
        if(Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            // https://findnerd.com/list/view/How-to-get-mouse-swipe-input-in-Unity--3D/9713/

            endPosition = Input.mousePosition;
            float disX = Mathf.Abs(startPosition.x - endPosition.x);
            float disY = Mathf.Abs(startPosition.y - endPosition.y);

            direction.x = disX;
            direction.y = disY;
            MovePlayer();
        }
    }

    public void Reset()
    {
        startPosition = Vector2.zero;
        endPosition = Vector2.zero;
        Jump = MoveLeft = MoveRight = MoveForward = false;
    }

    void MovePlayer()
    {
        // if greater than threshold, find direction in which moved
        // if direction.x > direction.y then move left/right (need to rotate here as well)

        if (direction.x > 0 || direction.y > 0)
        {
            if (direction.x > direction.y)
            {
                if (startPosition.x > endPosition.x)
                {
                    MoveLeft = true;
                }
                else
                {
                    MoveRight = true;
                }
            }
            else
            {
                if (startPosition.y > endPosition.y)
                {
                }
                else
                {
                    MoveForward = true;
                    print(MoveForward);
                }
            }
        }
    }
}
