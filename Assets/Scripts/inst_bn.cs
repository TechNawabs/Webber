﻿using UnityEngine;
using System.Collections;

public class inst_bn : MonoBehaviour 
{
	public GameObject uis;
	public string t;
	
	void OnMouseEnter()
	{
		GetComponent<Renderer>().material.color = Color.cyan;
		GetComponent<AudioSource>().Play ();
		iTween.MoveTo (uis,iTween.Hash ("Path", iTweenPath.GetPath (t), "time", 5));
	}

	void OnMouseUp()
	{
		Application.LoadLevelAsync("instruction");
	}

	void OnMouseExit()
	{
		GetComponent<Renderer>().material.color = Color.white;
		GetComponent<AudioSource>().Stop ();
		iTween.MoveTo (uis,iTween.Hash ("Path", iTweenPath.GetPathReversed (t), "time", 5));
	}
}