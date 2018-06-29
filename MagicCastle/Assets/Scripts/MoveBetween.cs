using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetween : MonoBehaviour
{
     public Transform objectA;
     public Transform objectB;
	 public float speed = 0.1f;
	 
     void Update()
     {
         transform.position = Vector3.Lerp(
			objectA.position, objectB.position, 
			Mathf.PingPong(Time.time * speed, 1.0f));
     }
 }
 