using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class RepeatSound
{
	public float duration;
	public int times;
	public AudioClip audioClip;
	public string clipName;
	
	public RepeatSound(AudioClip au, int t, float d, string cn)
	{
		audioClip = au;
		times = t;
		duration = d;
		clipName = cn;
	}
}

public class Sound : MonoBehaviour
{
	private static Sound me;
	private static Hashtable usedClips;
	
	private bool muteMusic;
	private bool muteSound;
	
	//-----------------------------------------------------------------
	// public static methods
	//-----------------------------------------------------------------
	
	public static void Play(string clipName, int repeat = 0, bool bgm = false)
	{
		if( (me == null) || (me.GetComponent<AudioSource>() == null) )
			return;
		
		AudioClip clip;
		if( !usedClips.ContainsKey(clipName) )
		{
			clip = Resources.Load("Audio/"+clipName) as AudioClip;
			usedClips.Add(clipName, clip);
		}
		else
		{
			clip = (AudioClip)usedClips[clipName];
		}
		
		if ( bgm )
		{
			me.GetComponent<AudioSource>().clip = clip;
			if ( !me.muteMusic )
				me.GetComponent<AudioSource>().Play();
			return;
		}
		
		if ( me.muteSound )
			return;
		
		GameObject go = new GameObject("Audio_"+clipName);
		go.transform.position = Camera.main.transform.position;
		AudioSource source = go.AddComponent<AudioSource>();
		if ( repeat > 0 )
		{
			source.clip = clip;
			source.Play();
			source.loop = true;
			Destroy(go, clip.length*repeat);
		}
		else
		{
			source.PlayOneShot(clip);
			Destroy(go, clip.length);
		}
	}
	
	public static void Stop(string clipName = "")
	{
		if( (me == null) || (me.GetComponent<AudioSource>() == null) )
			return;
		
		if ( clipName == "" )
		{
			me.GetComponent<AudioSource>().Stop();
			return;
		}
		
		GameObject go = GameObject.Find("Audio_"+clipName);
		if ( go != null )
		{
			Destroy(go);
		}
	}
	
	public static void SetMuteSound(bool mute)
	{
		me.muteSound = mute;
	}
	
	public static void SetMuteMusic(bool mute)
	{
		me.muteMusic = mute;
		if (mute)
		{
			me.GetComponent<AudioSource>().Stop();
		}
		else
		{
			me.GetComponent<AudioSource>().Play();
		}
	}
	
	public static bool isMusicMute()
	{
		return me.muteMusic;
	}
	
	public static bool isSoundMute()
	{
		return me.muteSound;
	}
	
	//-----------------------------------------------------------------
	// public methods
	//-----------------------------------------------------------------
	
	//-----------------------------------------------------------------
	// protected mono methods
	//-----------------------------------------------------------------
	
	protected void Awake ()
	{
		me = this;
		gameObject.AddComponent<AudioSource>();
		usedClips = new Hashtable();
	}
	
	protected void Start ()
	{
		muteMusic = false;
		muteSound = false;
		
		GetComponent<AudioSource>().loop = true;
	}
	
	//-----------------------------------------------------------------
	// private methods
	//-----------------------------------------------------------------
	
}