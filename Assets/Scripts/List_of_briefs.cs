using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task
{
    public string TaskName;
	public GameObject TaskDescription;
	public float time_diff;

}
public class List_of_briefs : MonoBehaviour {
	
    public List<Task> TaskList;
    public Transform contentPanel;

	// Use this for initialization
	void Start () {
		RefreshDisplay ();
	}
	void RefreshDisplay(){
		RemoveButtons();
		AddButtons();
	}
	private void RemoveButtons(){

	}
	private void AddButtons(){

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
