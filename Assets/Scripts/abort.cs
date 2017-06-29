using UnityEngine;
using System.Collections;

public class abort : MonoBehaviour
{
	void OnMouseEnter()

	{
		GetComponent<Renderer>().material.color = Color.gray;
		GetComponent<AudioSource>().Play ();
	}

	void OnMouseUp()
	{
		Application.Quit ();
	}

	void OnMouseExit()
	{
		GetComponent<Renderer>().material.color = Color.white;
		GetComponent<AudioSource>().Stop ();
	}
}