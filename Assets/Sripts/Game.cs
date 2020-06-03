using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Game : MonoBehaviour {

	public static bool WinScreenAppear = false;
	public GameObject winscreenUI;
	
	private static Game me;
	
	Text scoreText;
	
	private int score;
	
	private delegate void UpdateDelegate();
	private UpdateDelegate onUpdateDelegate;
	
	public static void EarnScore()
	{
		me.score ++;
		Sound.Play("misc049a");
		
		if (me.score == 4) 
		{
			me.EndGameWin();
		}
	}
	
	void Start () 
	{
		Sound.Play("172561__djgriffin__video-game-7",0,true);//loop the sound
		GameObject go = GameObject.Find ("Score Label");
		scoreText = GetComponent<Text> ();
		score = 0;
		
		me = this;
		
		//onUpdateDelegate = UpdateInGameTitle;
		onUpdateDelegate = UpdateGamePlaying;
	}
	
	void Update () 
	{
		if (onUpdateDelegate != null) 
		{
			onUpdateDelegate();
		}
	}
	
	private void UpdateGamePlaying()
	{
		
		scoreText.text = "Score: " + score;
		
	}
	
	private void EndGameWin()
	{
		Sound.Play("52908__m-red__winning",0,true);
		WinScreenAppear = true;
		winscreenUI.SetActive(true);
	}
	
}