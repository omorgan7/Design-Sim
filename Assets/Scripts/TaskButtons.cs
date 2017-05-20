using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TaskButtons : MonoBehaviour {

	public Button buttonComponent;
    public Text nameLabel;
  
    private Task task;
    private List_of_briefs scrollList;
    

	// Use this for initialization
	void Start () {
		buttonComponent.onClick.AddListener (HandleClick);
	}
	 public void HandleClick()
    {
    
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
