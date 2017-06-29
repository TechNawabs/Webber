using UnityEngine;
using System.Collections;

public class eatGiant : MonoBehaviour 
{
	private GameControl gk;
	public int sc;
	
	void Start()
	{
		gk = GameObject.Find ("game").GetComponent<GameControl> ();
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.name == "Spider")
		{
			other.GetComponent<AudioSource>().Play();
			gk.AddScore(sc);
			Destroy(gameObject);
		}
	}
}
