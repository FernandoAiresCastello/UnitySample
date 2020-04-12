using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoBox : MonoBehaviour
{
	private Player player;
	private Text indicatorText;
	
	void Awake()
	{
		player = GameObject.FindWithTag("Player").GetComponent<Player>();
		indicatorText = transform.Find("Text").GetComponent<Text>();
	}
	
	void Start()
	{
	}
	
	void Update()
	{
		indicatorText.text = 
			player.health + "/" + player.maxHealth  + "\n" + 
			player.gold + "\n" + 
			player.aura + "%";
	}
}
