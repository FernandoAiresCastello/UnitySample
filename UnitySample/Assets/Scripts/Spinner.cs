using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
	public Vector3 rotationSpeed = Vector3.forward * 10;
	
	void Update()
	{
		transform.Rotate(rotationSpeed);
	}
}
