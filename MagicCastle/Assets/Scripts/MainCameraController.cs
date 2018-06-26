using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;
 
public class MainCameraController : MonoBehaviour
{
	public Transform target;
	public Vector3 offsetPosition = new Vector3(0.0f,0.2f,-1.0f);
	public bool followTarget = true;
	
	private Space offsetPositionSpace = Space.Self;
	private bool lookAt = false;
 
	void Awake()
	{
		Screen.SetResolution(640, 480, false);
		
		if (followTarget) {
			if (target == null) {
				target = GameObject.FindWithTag("Player").GetComponent<Transform>();
			}
		}
	}
 
	void Update()
	{
		Refresh();
	}
 
	void Refresh()
	{
		if (target == null) {
			Debug.LogWarning("Missing target ref!", this);
			return;
		}

		if (offsetPositionSpace == Space.Self)
			transform.position = target.TransformPoint(offsetPosition);
		else
			transform.position = target.position + offsetPosition;

		if (lookAt)
			transform.LookAt(target);
		else
			transform.rotation = target.rotation;
    }
}
 