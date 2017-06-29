using UnityEngine;
using System.Collections;

public class GameControl: MonoBehaviour 
{
	private bool Gameover,win;
	private bool pause;
	public int score;
	public float tm;
	private string niceTime;
	private bool P = true;
	private bool S;
	private bool show = false;

	public GUIText Sc;
	public GUIText tym;

	void Start()
	{
		Time.timeScale = 1;
		StartCoroutine ("StartGame");
	}

	IEnumerator StartGame()
	{
		yield return new WaitForSeconds(1f);
		Gameover = false;
		win = false;
		score = 0;
		niceTime = "0:00";
		tm = 181;
		UpdateScore ();
		S = true;	
	}

	void Update()
	{
		if (Input.GetKeyUp (KeyCode.Escape)) 
		{	
			if (P) 
			{
				Time.timeScale = 0;
				AudioListener.pause = true;
				pause = true;
			}
		}

		if (S) 
		{
			tym.enabled = true;
			tym.text = "Time : "+niceTime;
			Timer ();
		}
		if (score >= 1170)
		{
			win = true;
		}
		else
			return;
		
	}

	public void Timer()
	{
		int minutes = Mathf.FloorToInt(tm / 60F);
		int seconds = Mathf.FloorToInt(tm - minutes * 60);
		
		niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);

		if (tm > 0) 
		{
			tm -= Time.deltaTime;
		}
		if (tm < 0) 
		{
			tm =0;
		}
		if (tm == 0) 
		{
			GameOver();
		}
	}

	public void OnGUI()
	{
		if (show) 
		{
			P = false;
			GUI.Box (new Rect (290, 140, 480, 300), "!!!! GAME OVER !!!!");//change
			GUI.backgroundColor = Color.cyan;
			GUI.contentColor = Color.green;
			if (GUI.Button (new Rect (330, 320, 170, 80), "RESTART")) 
			{
				Time.timeScale = 1;
				Application.LoadLevel (Application.loadedLevel);                           //Loading current level.
			}
			GUI.backgroundColor = Color.gray;
			GUI.contentColor = Color.yellow;
			if (GUI.Button (new Rect (560, 320, 170, 80), "MAIN MENU")) 
			{
				Time.timeScale = 1;
				Application.LoadLevelAsync("Menu");
			}
		} 

		if (pause) 
		{
			GUI.Box (new Rect (350, 165, 320, 220), "GAME PAUSED");
			GUI.backgroundColor = Color.cyan;
			GUI.contentColor = Color.green;

			if (GUI.Button (new Rect (390, 300, 100, 70), "RESUME")) 
			{
				AudioListener.pause = false;

				pause = false;
				Time.timeScale = 1;
			}
			if (GUI.Button (new Rect (540, 300, 100, 70), "QUIT")) 
			{
				Application.Quit();
				AudioListener.pause = false;
				pause = false;
				Time.timeScale = 1;
			}
		}

		if (Gameover)
		{
			show = true;
			Time.timeScale = 0;
		}		

		if(win)
		{
			P = false;
			Time.timeScale = 0;
			GUI.Box (new Rect (290, 140, 480, 300), "!!!! YOU WON !!!!");//change
			GUI.backgroundColor = Color.cyan;
			GUI.contentColor = Color.green;
			if (GUI.Button (new Rect (330, 320, 170, 80), "PLAY AGAIN")) 
			{
				Time.timeScale = 1;
				Application.LoadLevel (Application.loadedLevel);                           //Loading current level.
			}
			GUI.backgroundColor = Color.gray;
			GUI.contentColor = Color.yellow;
			if (GUI.Button (new Rect (560, 320, 170, 80), "MAIN MENU")) 
			{
				Time.timeScale = 1;
				Application.LoadLevelAsync("Menu");
			}
		}
		else
			return;
	}

	void levelClear()
	{
		Sc.enabled = false;
	}

	public void AddScore(int Val)
	{
		score += Val;
		UpdateScore ();
	}
	void UpdateScore()
	{
		Sc.text = "SCORE : "+ score;
	}

	public void GameOver()
	{
		Gameover = true;
		//Sc.enabled = false;
		//tym.enabled = false;
	}
}