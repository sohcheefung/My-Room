using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void Play() {
	Application.LoadLevel("My Room1");
	}
	
	public void Quit() {
	Application.Quit();
	}
	
	public void Next(){
	Application.LoadLevel("My Room2");
	}
	
	public void Next1(){
	Application.LoadLevel("My Room3");
	}
	
	public void menu() {
	Application.LoadLevel("menu");
	}
}
