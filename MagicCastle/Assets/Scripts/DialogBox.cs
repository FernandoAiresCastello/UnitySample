using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour {
	
	public bool startHidden = true;

	private Text dialogText;
	private float initialHeight;
	
	void Awake()
	{
		dialogText = GameObject.Find("DialogText").GetComponent<Text>();
		RectTransform rectTransform = (RectTransform)transform;
		initialHeight = rectTransform.sizeDelta.y;
	}
	
	void Start()
	{
		if (startHidden)
			Hide();
	}
	
	void Update()
	{
	}
	
	public void Hide()
	{
		transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
	}
	
	public void Show()
	{
		transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
	}
	
	public void Show(string text, int fontSize, Color color)
	{
		SetText(text);
		SetFontSize(fontSize);
		SetColor(color);
		Show();
	}
	
	public void SetText(string text)
	{
		dialogText.text = text;
	}

	public void SetFontSize(int fontSize)
	{
		dialogText.fontSize = fontSize;
	}
	
	public void SetHeight(float height)
	{
		RectTransform rectTransform = (RectTransform)transform;
		rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, initialHeight + height);
	}
	
	public void Clear()
	{
		GameObject.Find("DialogText").GetComponent<Text>().text = "";
	}
	
	public void SetColor(Color color)
	{
		dialogText.color = color;
	}
}
