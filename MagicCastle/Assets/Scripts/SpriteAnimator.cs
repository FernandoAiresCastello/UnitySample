using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : ExtendedMonoBehaviour
{
	public float delay = 0.1f;
	public List<Sprite> sprites;
	
    private SpriteRenderer rend;
	private int spriteIndex = 0;
	private float timer = 0.0f;

    void Awake()
	{
        rend = GetComponent<SpriteRenderer>();
    }
	
	void Start()
	{
	}
	
    void Update()
	{
		if (sprites.Count == 0)
			return;
		
		if (timer == 0.0f) {
			rend.sprite = sprites[spriteIndex];
			spriteIndex++;
			if (spriteIndex >= sprites.Count)
				spriteIndex = 0;
		}
		
		timer += Time.deltaTime;
		if (timer > delay)
			timer = 0.0f;
    }
}
