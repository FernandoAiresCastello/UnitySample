using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackAndForth : MonoBehaviour {

	public float dx = 0.0f;
	public float dy = 0.0f;
	public float dz = 0.0f;
	public float maxDistance = 0.0f;
	public bool flipSpriteX = false;
	public bool flipSpriteY = false;
	
	private Vector3 initialPos;
	private SpriteRenderer rend;

	void Awake()
	{
		initialPos = GetComponent<Transform>().position;
		rend = GetComponent<SpriteRenderer>();
	}
	
	void Update()
	{
		Transform t = GetComponent<Transform>();
		t.Translate(dx * Time.deltaTime, dy * Time.deltaTime, dz * Time.deltaTime, Space.World);
		if (Vector3.Distance(initialPos, t.position) >= maxDistance || Vector3.Distance(initialPos, t.position) < 0) {
			dx *= -1;
			dy *= -1;
			dz *= -1;
			if (flipSpriteX)
				rend.flipX = !rend.flipX;
			if (flipSpriteY)
				rend.flipY = !rend.flipY;
		}
	}
}
