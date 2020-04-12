using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	public int goldValue = 1;
	
	private AudioSource audioSource;
	
	void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}

	void Start()
	{
	}
	
	void Update()
	{
	}
	
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.CompareTag("Player")) {
			Player player = col.gameObject.GetComponent<Player>();
			player.gold += goldValue;
			DestroySelf();
		}
	}

	void DestroySelf()
	{
		audioSource.Play();
		GetComponent<Collider>().enabled = false;
		GetComponent<SpriteRenderer>().enabled = false;
		Destroy(gameObject, audioSource.clip.length);
	}
}
