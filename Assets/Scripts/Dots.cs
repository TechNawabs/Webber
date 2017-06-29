using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dots : MonoBehaviour 
{
	public string p;
	public GameObject sp;

	void OnMouseOver()
	{
		GetComponent<Renderer> ().material.color = Color.green;
	}

	void OnMouseExit()
	{
		GetComponent<Renderer> ().material.color = Color.white;
	}

	void OnMouseUp()
	{
		iTween.MoveTo (sp, iTween.Hash ("Path", iTweenPath.GetPath (p), "time", 5));
	}
}