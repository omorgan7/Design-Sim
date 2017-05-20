using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class List_of_briefs : MonoBehaviour {
	
  //  public List<Brief> TaskList;
    public Transform contentPanel;

	private Brief brief;

	// Use this for initialization
	void Start () {
		RefreshDisplay ();
		var BriefObject = GameObject.Find("EventSystem/Briefs");
		brief = BriefObject.GetComponent<Brief>();

	}
	void RefreshDisplay(){
	
	}
	private void RemoveButtons(){

	}
	private void AddButtons(){
		GameObject newButton = GameObject.Find("Task Button");
		newButton.transform.SetParent(contentPanel);   

	}
	
	// Update is called once per frame
	void Update () {
		if(brief != null){
			AddButtons();
		}
		
	}
}
