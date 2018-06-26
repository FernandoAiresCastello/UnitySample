using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class Scene : MonoBehaviour
{
	public string title = "Undefined";
	public AudioClip mainTrack;
	public AudioClip subTrack;
	private AudioSource audioSource;
	
	void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}
	
	void Start()
	{
		if (Application.isPlaying) {
			audioSource.loop = true;
			audioSource.clip = mainTrack;
			audioSource.Play();
		}
	}
	
	public void PlaySubTrack()
	{
		audioSource.Stop();
		audioSource.clip = subTrack;
		audioSource.Play();
	}
}
