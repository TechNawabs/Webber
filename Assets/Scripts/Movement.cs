using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour 
{

	private float fingerStartTime  = 0.0f;
	private Vector2 fingerStartPos = Vector2.zero;

	public bool isSwipe = false;
	private float minSwipeDist  = 5.0f;
	private float maxSwipeTime = 0.5f;

	public string[] path;
	public GameObject sp;

	void Update()
	{

		if (Input.touchCount > 0 && Time.timeScale > 0.0f) 
		{

			foreach (Touch touch in Input.touches) 
			{

				switch (touch.phase) 
				{

				case TouchPhase.Began:
					/* this is a new touch */
					isSwipe = true;
					fingerStartTime = Time.time;
					fingerStartPos = touch.position;
					break;

				case TouchPhase.Canceled:
					/* The touch is being canceled */
					isSwipe = false;
					break;

				case TouchPhase.Ended:

					float gestureTime = Time.time - fingerStartTime;
					float gestureDist = (touch.position - fingerStartPos).magnitude;

					if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist)
					{

						Vector2 direction = touch.position - fingerStartPos;

						//Vector2 swipeType = Vector2.zero;
						int swipeType = -1;

						if (Mathf.Abs(direction.normalized.x) > 0.8)
						{
							// swipe right
							if (Mathf.Sign(direction.x) > 0) 
								swipeType = 0; 

							// swipe left
							else 
								swipeType = 1; 

						}
						else if (Mathf.Abs(direction.normalized.y) > 0.9)
						{
							// swipe up
							if (Mathf.Sign(direction.y) > 0) 
								swipeType = 2; 

							// swipe down
							else 
								swipeType = 3; 
						}
						else
						{
							// diagonal:
							if (Mathf.Sign(direction.x) > 0)
							{
								// swipe diagonal up-right
								if (Mathf.Sign(direction.y) > 0) 
									swipeType = 4;

								// swipe diagonal down-right
								else 
									swipeType = 5; 
							}
							else
							{
								// swipe diagonal up-left
								if (Mathf.Sign(direction.y) > 0)
									swipeType = 6;

								// swipe diagonal down-left
								else 
									swipeType = 7; 
							}

						}

						switch(swipeType)
						{

						case 0: //right
							iTween.MoveTo(sp,iTween.Hash("Path",iTweenPath.GetPath(path[0]),"Time",5));
							break;

						case 1: //left
							iTween.MoveTo(sp,iTween.Hash("Path",iTweenPath.GetPath(path[1]),"Time",5));
							break;

						case 2: //up
							/*Not required now*/
							break;

						case 3: //down
							/*Not required now*/
							break;

						case 4: //up right
							iTween.MoveTo(sp,iTween.Hash("Path",iTweenPath.GetPath(path[2]),"Time",5));
							break;

						case 5: //down right
							iTween.MoveTo(sp,iTween.Hash("Path",iTweenPath.GetPath(path[3]),"Time",5));
							break;

						case 6: //up left
							iTween.MoveTo(sp,iTween.Hash("Path",iTweenPath.GetPath(path[4]),"Time",5));
							break;

						case 7: //down left
							iTween.MoveTo(sp,iTween.Hash("Path",iTweenPath.GetPath(path[5]),"Time",5));
							break;
						}
					}
					break;
				}
			}
		}
	}
}