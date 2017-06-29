using UnityEngine;
using System.Collections;

public class Bck : MonoBehaviour 
{

	public void OnMouseEnter()
	{
		GetComponent<Renderer>().material.color = Color.blue;  
		GetComponent<AudioSource>().Play ();
	}

	public void OnMouseUp()
	{
		Application.LoadLevelAsync ("Menu");
	}

	public void OnMouseExit()
	{
		GetComponent<Renderer>().material.color = Color.white;
	}
}
