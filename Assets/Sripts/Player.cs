using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	private delegate void UpdateDelegate();
	private UpdateDelegate onUpdateDelegate;
	
	void Start () 
	{
		
	}
	
	void Update () 
	{ 
		
	}
	
	private void StartGame()
	{
		Game.EarnScore();//score akan ditambah
		Destroy (this.gameObject);
	}
	
	protected void OnMouseDown ()
	{
		Game.EarnScore();//score akan ditambah
		Destroy (this.gameObject);
	}
	
}