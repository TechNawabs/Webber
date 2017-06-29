using UnityEngine;
using System.Collections;

public class bn : MonoBehaviour 
{
	public GameObject uis;
	public string t;

	void OnMouseEnter()
	{
		GetComponent<Renderer>().material.color = Color.green;
		GetComponent<AudioSource>().Play ();
		iTween.MoveTo (uis,iTween.Hash ("Path", iTweenPath.GetPath (t), "time", 5));
	}

	void OnMouseUp()
	{
		Application.LoadLevelAsync("main_web");
	}

	void OnMouseExit()
	{
		GetComponent<Renderer>().material.color = Color.white;
		GetComponent<AudioSource>().Stop ();
		iTween.MoveTo (uis,iTween.Hash ("Path", iTweenPath.GetPathReversed (t), "time", 5));
	}
	
}