using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
	public Color color1 = new Color(1,1,1,1);
	public Color color2 = new Color(0,0,0,1);
	
	private Camera camera;
	
	void Awake()
	{
		camera = GetComponent<Camera>();
	}
	
	void Start()
	{
	}
	
	void Update()
	{
		camera.backgroundColor = Color.Lerp(Color.black, Color.white, 1 * Time.deltaTime);
	}
}
