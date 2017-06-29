using UnityEngine;
using System.Collections;

public class randomPrey : MonoBehaviour 
{
	public GameObject[] pr;
	private GameObject act;

	void Start()
	{
		act = pr[Random.Range (0,pr.Length)];
		act.SetActive (true);
	}
}