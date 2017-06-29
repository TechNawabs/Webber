using UnityEngine;
using System.Collections;

public class moveIt : MonoBehaviour 
{
	public string[] p;
	public GameObject s;

	Vector2 firstPressPos;
	Vector2 secondPressPos;
	Vector2 currentSwipe;

	void OnMouseEnter()
	{
		GetComponent<Renderer>().material.color = Color.green;
	}

	void Update()
	{
		// Using Keyboard

		/*if(Input.GetKeyUp(KeyCode.UpArrow))
		{
			
		}
		if(Input.GetKeyUp(KeyCode.LeftArrow))
		{
			
		}
		if(Input.GetKeyUp(KeyCode.RightArrow))
		{
			
		}*/
		touchSwipe ();                           //............................Using Touch

		// Using Mouse Click n Drag
		//mouseDrag ();
	}

	void OnMouseExit()
	{
		GetComponent<Renderer>().material.color = Color.white;
	}

	// For Mouse Drag
	/*public void mouseDrag()
	{
		if(Input.GetMouseButtonDown(0))
		{
			//save began touch 2d point
			firstPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
		}
		if(Input.GetMouseButtonUp(0))
		{
			//save ended touch 2d point
			secondPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
			
			//create vector from the two points
			currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
			
			//normalize the 2d vector
			currentSwipe.Normalize();
			
			//swipe upwards
			if(currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
			{
				
			}

			//swipe down
			//if(currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
			//{
			//	Debug.Log("down swipe");
			//}

			//swipe left
			if(currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
			{
				
			}
			//swipe right
			if(currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
			{
				
			}
		}
	}*/
	
	// For Touch 
	
	public void touchSwipe()
	{
		if(Input.touches.Length > 0)
		{
			Touch t = Input.GetTouch(0);
			if(t.phase == TouchPhase.Began)
			{
				//save began touch 2d point
				firstPressPos = new Vector2(t.position.x,t.position.y);
			}
			if(t.phase == TouchPhase.Ended)
			{
				//save ended touch 2d point
				secondPressPos = new Vector2(t.position.x,t.position.y);
				
				//create vector from the two points
				currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
				
				//normalize the 2d vector
				currentSwipe.Normalize();

				//swipe upwards
				if(currentSwipe.y > 0  && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
				{
					
				}

				//swipe down
				//if(currentSwipe.y < 0 && currentSwipe.x > -0.5f &&  currentSwipe.x < 0.5f)
				//{
				//	Debug.Log("down swipe");
				//}
				
				//swipe left
				if(currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
				{
					
				}
					
				//swipe right
				if(currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
				{
					
				}
			}
		}
	}
}