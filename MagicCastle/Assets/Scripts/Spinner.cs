using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
	public float speed = 0.1f;
	public float multiplier = -45;
	
	void Start()
	{
	}
	
	void Update()
	{
		Transform t = GetComponent<Transform>();
		t.Rotate(Vector3.forward * multiplier);
	}
}
