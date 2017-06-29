using UnityEngine;
using System.Collections;

public class startGame : MonoBehaviour 
{
	public GameObject gm,i;

	void OnMouseEnter()
	{
		GetComponent<Renderer>().material.color = Color.blue;
		GetComponent<AudioSource>().Play ();
	}
	
	void OnMouseUp()
	{
		GetComponent<Renderer>().material.color = Color.blue;
		i.SetActive (false);
		gm.SetActive (true);
	}

	void OnMouseExit()
	{
		GetComponent<Renderer>().material.color = Color.white;
		GetComponent<AudioSource>().Stop ();
	}
}