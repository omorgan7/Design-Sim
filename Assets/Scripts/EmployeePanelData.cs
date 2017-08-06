using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmployeePanelData : MonoBehaviour {
	public GameObject inputs;
	
	// Use this for initialization
	void Start () {

	}
		

	
	// Update is called once per frame
	void Update () {
		
	}
	public void SetUp(Employee E){
		Text[] textComponents = inputs.GetComponentsInChildren<Text>(true);
		textComponents[0].text = (E.id).ToString();
		textComponents[1].text = "rank";
		if(E.WorkQueue.Count>0){
			textComponents[2].text = (E.WorkQueue[0].brief.GetBriefName());
			textComponents[3].text = (E.WorkQueue[0].duration - E.WorkQueue[0].currenttime).ToString() + " minutes";
		}
		else{
			textComponents[2].text = "No current tasks";
			textComponents[3].text = "0 minutes";
		}
	}
}
