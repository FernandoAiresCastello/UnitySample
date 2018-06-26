using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
	public Texture switchedTexture;
	public bool disabled = false;
	
	private bool switched = false;
	private AudioSource audioSource;
	private Material mat;
	
	public bool IsActive
	{
		get { return disabled || switched; }
	}
	
	void Awake()
	{
		audioSource = GetComponent<AudioSource>();
		mat = GetComponent<Renderer>().material;
	}
	
	void OnCollisionEnter(Collision col)
	{
		Activate();
	}
	
	void Activate()
	{
		if (!switched) {
			audioSource.Play();
			mat.mainTexture = switchedTexture;
			switched = true;
		}
	}
}
