using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : ExtendedMonoBehaviour
{
	public string nextScene = "";
	public AudioClip enterSound;
	public bool flashScreen = true;
	
	private AudioSource audioSource;
	
	void Awake()
	{
		audioSource = GetComponent<AudioSource>();
		if (audioSource != null) {
			audioSource.playOnAwake = false;
			audioSource.loop = false;
		}
	}

	void Update()
	{
	}
	
	void OnCollisionEnter(Collision col)
	{
		EnterNextScene();
	}
	
	void EnterNextScene()
	{
		Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
		player.Hide();
		player.Lock();
		
		if (audioSource != null)
			audioSource.PlayOneShot(enterSound);
		
		if (flashScreen) {
			FlashBang fb = GameObject.Find("FlashPanel").GetComponent<FlashBang>();
			fb.Flash();
		}

		Wait(1, ()=> {
			SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
			//player.Show();
			//player.Unlock();
		});
	}
}
