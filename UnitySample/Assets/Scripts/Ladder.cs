using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
	void Start()
	{
	}
	
	void Update()
	{
	}
	
	void OnCollisionStay(Collision col)
	{
		if (col.gameObject.CompareTag("Player")) {
			col.gameObject.GetComponent<Rigidbody>().useGravity = false;
			col.gameObject.transform.position += new Vector3(0.0f, 0.03f, 0.0f);
		}
	}
	
	void OnCollisionExit(Collision col)
	{
		if (col.gameObject.CompareTag("Player"))
			col.gameObject.GetComponent<Rigidbody>().useGravity = true;
	}
}
