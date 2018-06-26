using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldIndicator : MonoBehaviour
{
	private Player player;
	private Text indicatorText;
	
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
		indicatorText.text = "G" + player.gold;
	}
}
