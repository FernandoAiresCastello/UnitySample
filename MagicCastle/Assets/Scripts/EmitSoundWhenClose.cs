using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitSoundWhenClose : MonoBehaviour
{
	public float closeDistance = 0.1f;
	public AudioClip clip;
	
	private AudioSource audioSource;
	private Transform player;
	
	void Awake()
	{
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = clip;
		audioSource.loop = false;
		player = GameObject.FindWithTag("Player").GetComponent<Transform>();
	}
	
	void Start()
	{
	}
	
	bool IsCloseToPlayer()
	{
		return Vector3.Distance(player.position, transform.position) <= closeDistance;
	}
	
	void Update()
	{
		if (!audioSource.isPlaying && IsCloseToPlayer()) {
			audioSource.Play();
		}
	}
}
