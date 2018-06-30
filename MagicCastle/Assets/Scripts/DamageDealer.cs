using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
	public int damage = 0;
	public float delay = 1.0f;
	
	private Player player;
	private float timer = 0.0f;
	private bool colliding = false;
	
	void Awake()
	{
		player = GameObject.FindWithTag("Player").GetComponent<Player>();
	}
	
	void Update()
	{
		if (colliding) {
			
			if (timer == 0.0f) {
				player.Damage(damage);
			}
			
			timer += Time.deltaTime;
			if (timer > delay)
				timer = 0.0f;
		}
	}
	
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.CompareTag("Player")) {
			colliding = true;
		}
	}
	
	void OnCollisionExit(Collision col)
	{
		if (col.gameObject.CompareTag("Player")) {
			colliding = false;
		}
	}
}
