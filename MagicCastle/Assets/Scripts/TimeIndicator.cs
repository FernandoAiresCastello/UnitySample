using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeIndicator : MonoBehaviour
{
	public int maxTime = 100000;
	public bool autoStart = true;
	public bool loop = false;
	
	private Text textElement;
	
	void Awake()
	{
		textElement = GetComponent<Text>();
	}
	
	void Update()
	{
		textElement.text = StaticTimer.time.ToString();
		
		if (autoStart) {
			if (StaticTimer.time < maxTime) {
				StaticTimer.time++;
				if (StaticTimer.time >= maxTime && loop)
					StaticTimer.time = 0;
			}
		}
	}
}
