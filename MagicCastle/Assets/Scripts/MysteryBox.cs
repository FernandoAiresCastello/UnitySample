using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryBox : MonoBehaviour
{
	public int resistance = 4;
	public AudioClip soundHit;
	public AudioClip soundDestroy;
	public GameObject hiddenObject;
	
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
	}
	
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.CompareTag("PlayerProjectile")) {
			Destroy(col.gameObject);
			audioSource.PlayOneShot(soundHit);
			resistance--;
			if (resistance <= 0) {
				DestroySelf();
			}
		}
	}
	
	void DestroySelf()
	{
		audioSource.PlayOneShot(soundDestroy);
		GetComponent<Collider>().enabled = false;
		Instantiate(hiddenObject, transform.position, transform.rotation);
		Destroy(gameObject, soundDestroy.length);
	}
}
