using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthIndicator : MonoBehaviour
{
	private Player player;
	private Text indicatorText;
	private string indicator;
	
	void Awake()
	{
		player = GameObject.FindWithTag("Player").GetComponent<Player>();
		indicatorText = GetComponent<Text>();
	}
	
	void Start()
	{
	}
	
	void Update()
	{
		//indicator = new string('|', player.health);
		//indicatorText.text = indicator;
		indicatorText.text = "H" + player.health;
	}
}
