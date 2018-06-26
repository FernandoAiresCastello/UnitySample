using UnityEngine;
using System.Collections;
 
public class CameraFacingBillboard : MonoBehaviour
{
    public Camera mainCamera;
	
	void Awake()
	{
		if (mainCamera == null)
			mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
	}
	
	void Start()
	{
	}
 
    void Update()
    {
        transform.LookAt(
			transform.position + mainCamera.transform.rotation * Vector3.forward,
            mainCamera.transform.rotation * Vector3.up);
    }
}
