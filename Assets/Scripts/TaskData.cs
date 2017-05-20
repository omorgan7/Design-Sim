using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskData : MonoBehaviour {
	public GameObject BriefName;
	public GameObject ProjectPoints;
	public GameObject NumEmployees;

	private BriefController BC;
	private Text one;
	private Text two;
	private Text three;
	Brief brief;
	public GameObject panel;

	//Use this for initialization
	void Start () {
		one = BriefName.GetComponent<Text>();
		two = ProjectPoints.GetComponent<Text>();
		three = NumEmployees.GetComponent<Text>();
		GameObject EventSystem = GameObject.Find("EventSystem");
		BC = EventSystem.GetComponent<BriefController>();
		brief = BC.BriefsList[0];
				
	}
	
	// Update is called once per frame
	void Update () {
		if(brief == null){
			Destroy(panel);
		}
		else{
			one.text = "Brief Name: " + brief.GetBriefName();
			two.text= "Project Points: " + brief.GetProjectPoints();
			three.text = "Number of Employees: " + brief.GetNumEmployees();	
		}
	}
}
