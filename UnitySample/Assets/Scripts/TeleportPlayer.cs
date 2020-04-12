using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportPlayer : MonoBehaviour
{
	public Transform destination;
	public AudioClip enterSound;
	
	private AudioSource audioSource;
	
	void Awake()
	{
		audioSource = GetComponent<AudioSource>();
		audioSource.playOnAwake = false;
		audioSource.loop = false;
	}

	void Update()
	{
	}
	
	void OnCollisionEnter(Collision col)
	{
		Teleport();
	}
	
	void Teleport()
	{
		if (audioSource != null)
			audioSource.PlayOneShot(enterSound);
		
		FlashBang fb = GameObject.Find("FlashPanel").GetComponent<FlashBang>();
		fb.Flash();
		
		GameObject player = GameObject.FindWithTag("Player");
		player.transform.position = destination.position;
	}
}
