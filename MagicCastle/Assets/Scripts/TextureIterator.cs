using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureIterator : MonoBehaviour {

	public float delay = 1.0f;
	public List<Texture> textures;
	
    private Renderer rend;
	private int textureIndex = 0;
	private float timer = 0.0f;
	
    void Awake()
	{
        rend = GetComponent<Renderer>();
    }
	
	void Start()
	{
		foreach (Texture tex in textures) {
			tex.anisoLevel = 1;
			tex.filterMode = FilterMode.Point;
		}
	}
	
    void Update()
	{
		if (textures.Count == 0)
			return;
		
		if (timer == 0.0f) {
			rend.material.SetTexture("_MainTex", textures[textureIndex]);
			textureIndex++;
			if (textureIndex >= textures.Count)
				textureIndex = 0;
		}
		
		timer += Time.deltaTime;
		if (timer > delay)
			timer = 0.0f;
    }
}
