using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackAndForth : MonoBehaviour {

	public float dx = 0.0f;
	public float dy = 0.0f;
	public float dz = 0.0f;
	public float maxDistance = 0.0f;
	public float distance = 0.0f;
	public bool flipSpriteX = false;
	public bool flipSpriteY = false;
	
	private SpriteRenderer rend;

	void Awake()
	{
		rend = GetComponent<SpriteRenderer>();
		distance = 0.0f;
	}
	
	void Update()
	{
		if (maxDistance <= 0.0f)
			return;

		transform.Translate(dx * Time.deltaTime, dy * Time.deltaTime, dz * Time.deltaTime, Space.World);
		distance += 0.1f * Time.deltaTime;
		if (distance > maxDistance) {
			distance = 0.0f;
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
