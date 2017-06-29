using UnityEngine;
using System.Collections;

public class movInAllDirection : MonoBehaviour 
{

	private float fingerStartTime  = 0.0f;
	private Vector2 fingerStartPos = Vector2.zero;
	
	private bool isSwipe = false;
	private float minSwipeDist  = 30.0f;
	private float maxSwipeTime = 0.5f;

	public GameObject spi;
	public string[] pt;

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
						if (Mathf.Abs(direction.normalized.x) > 0.9)
						{
							
							if (Mathf.Sign(direction.x) > 0) swipeType = 0; // swipe right
							else swipeType = 1; // swipe left
							
						}
						else if (Mathf.Abs(direction.normalized.y) > 0.9)
						{
							if (Mathf.Sign(direction.y) > 0) swipeType = 2; // swipe up
							else swipeType = 3; // swipe down
						}
						else
						{
							// diagonal:
							if (Mathf.Sign(direction.x) > 0)
							{
								
								if (Mathf.Sign(direction.y) > 0) swipeType = 4; // swipe diagonal up-right
								else swipeType = 5; // swipe diagonal down-right
								
							}
							else
							{
								
								if (Mathf.Sign(direction.y) > 0) swipeType = 6; // swipe diagonal up-left
								else swipeType = 7; // swipe diagonal down-left
								
							}
							
						}
						
						switch(swipeType)
						{
							case 0: //left
								iTween.MoveTo(spi,iTween.Hash("Path",iTweenPath.GetPath(pt[0]),"Time",5));
								break;

							case 1: //right
								iTween.MoveTo(spi,iTween.Hash("Path",iTweenPath.GetPath(pt[1]),"Time",5));
								break;
							
							case 2: //up
								break;
							
							case 3: //down
								break;
						
							case 4: //up left
							 iTween.MoveTo(spi,iTween.Hash("Path",iTweenPath.GetPath(pt[2]),"Time",5));
								break;

							case 5: //up right
								iTween.MoveTo(spi,iTween.Hash("Path",iTweenPath.GetPath(pt[3]),"Time",5));
								break;
							
							case 6: //down left
								iTween.MoveTo(spi,iTween.Hash("Path",iTweenPath.GetPath(pt[4]),"Time",5));
								break;
							
							case 7: //down right
								iTween.MoveTo(spi,iTween.Hash("Path",iTweenPath.GetPath(pt[5]),"Time",5));
								break;
						}
					}
					break;	
				}	
			}		
		}
	}
}