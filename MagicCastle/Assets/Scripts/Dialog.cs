using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
	[TextArea(5,10)]
	public string text = "";
	public Color color = new Color(1,1,1,1);
	private float height = 1.0f;

	private DialogBox dialogBox;

	void Awake()
	{
		dialogBox = GameObject.Find("DialogBox").GetComponent<DialogBox>();
	}
	
	void Start()
	{
	}
	
	void Update()
	{
	}
	
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.CompareTag("Player")) {
			dialogBox.Show(text, color, height);
		}
	}
	
	void OnCollisionExit(Collision col)
	{
		if (col.gameObject.CompareTag("Player")) {
			dialogBox.Clear();
			dialogBox.Hide();
		}
	}
}
