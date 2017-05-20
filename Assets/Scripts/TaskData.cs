using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskData : MonoBehaviour {
	public GameObject BriefName;
	public GameObject ProjectPoints;
	public GameObject NumEmployees;
	private Text one;
	private Text two;
	private Text three;
	Brief brief;

	//Use this for initialization
	void Start () {
		one = BriefName.GetComponent<Text>();
		two = ProjectPoints.GetComponent<Text>();
		three = NumEmployees.GetComponent<Text>();
		var BriefObject = GameObject.Find("EventSystem/Briefs");
		brief = BriefObject.GetComponent<Brief>();
				
	}
	
	// Update is called once per frame
	void Update () {

		one.text = "Brief Name: " + brief.GetBriefName();
		two.text= "Project Points: " + brief.GetProjectPoints();
		three.text = "Number of Employees: " + brief.GetNumEmployees();	

		if(brief.GetProjectPoints()<=0){
			
		}
	}
}
