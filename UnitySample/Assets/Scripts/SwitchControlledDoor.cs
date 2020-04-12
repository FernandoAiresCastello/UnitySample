using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchControlledDoor : MonoBehaviour
{
	public string nextScene;
	public Texture openTexture;
	public AudioClip openSound;
	public AudioClip enterSound;
	
	private bool open = false;
	private Material mat;
	private SwitchManager mgr;
	private AudioSource audioSource;
	
	void Awake()
	{
		mat = GetComponent<Renderer>().material;
		mgr = GameObject.Find("SwitchManager").GetComponent<SwitchManager>();
		audioSource = GetComponent<AudioSource>();
	}

	void Update()
	{
		if (mgr.AllSwitchesActivated && !open) {
			open = true;
			mat.mainTexture = openTexture;
			audioSource.PlayOneShot(openSound);
		}
	}
	
	void OnCollisionEnter(Collision col)
	{
		if (open)
			EnterNextScene();
	}
	
	void EnterNextScene()
	{
		audioSource.PlayOneShot(enterSound);
		SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
	}
}
