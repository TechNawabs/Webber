using UnityEngine;
using System.Collections;

public class food : MonoBehaviour 
{
	public GameObject[] g;

	void Update()
	{
		StartCoroutine("GenerateRandom");
	}

	IEnumerator GenerateRandom()
	{
		yield return new WaitForSeconds (2f);
	}
}