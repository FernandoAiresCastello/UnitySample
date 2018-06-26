using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchManager : MonoBehaviour
{
	private List<Switch> switches = new List<Switch>();
	private Text switchIndicator;
	
	public int Count
	{
		get { return switches.Count; }
	}
	
	public int CountActive
	{
		get {
			int active = 0;
			foreach (Switch s in switches)
				active += s.IsActive ? 1 : 0;
			return active;
		}
	}
	
	public bool AllSwitchesActivated
	{
		get {
			return CheckAllSwitchesActivated();
		}
	}
	
	void Awake()
	{
		switchIndicator = GameObject.Find("HUD3/SwitchIndicator").GetComponent<Text>();
	}
	
	void Start()
	{
		foreach (Transform child in transform) {
			switches.Add(child.gameObject.GetComponent<Switch>());
		}
	}

	void Update()
	{
		switchIndicator.text = CountActive + "/" + Count;
	}
	
	private bool CheckAllSwitchesActivated()
	{
		bool allSwitchesActivated = true;
		foreach (Switch s in switches) {
			if (!s.IsActive)
				allSwitchesActivated = false;
		}
		
		return allSwitchesActivated;
	}
}
