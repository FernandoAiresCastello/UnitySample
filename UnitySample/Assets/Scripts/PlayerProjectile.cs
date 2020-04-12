using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : ExtendedMonoBehaviour
{
	public float speed = 0.4f;
	public float maxDistance = 10.0f;
	public Vector3 offset = new Vector3(0.0f, 0.05f, 0.0f);
	public List<Sprite> sprites;
	
	private Vector3 initialPosition;
	private int spriteIndex = 0;
	private SpriteRenderer rend;

	void Awake()
	{
		initialPosition = transform.position;
		rend = GetComponent<SpriteRenderer>();
	}
	
	void Start()
	{
	}
	
	void Update()
	{
		rend.sprite = sprites[spriteIndex++];
		if (spriteIndex >= sprites.Count)
			spriteIndex = 0;

		transform.Translate(0, 0, speed);
		
		float dist = Vector3.Distance(initialPosition, transform.position);
		if (dist > maxDistance)
			DestroySelf();
	}
	
	void OnCollisionEnter(Collision col)
	{
		//DestroySelf();
	}
	
	void OnTriggerEnter(Collider col)
	{
		if (!col.gameObject.CompareTag("Player"))
			DestroySelf();
	}
	
	void DestroySelf()
	{
		Destroy(gameObject);
	}
}
