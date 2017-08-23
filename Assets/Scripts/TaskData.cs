using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskData : MonoBehaviour {
	public void Setup(Brief brief){
		Text[] textComponents = GetComponentsInChildren<Text>(true);
		textComponents[0].text = brief.GetBriefName();
		textComponents[1].text = "Project Points: " + brief.GetProjectPoints();
		textComponents[2].text  = "Project Cost: £" + brief.GetProjectCost();
		textComponents[3].text  = "Project Reward: £" + brief.GetProjectReward();
		textComponents[4].text  = "Number of Employees: " + brief.GetNumEmployees();	
		textComponents[5].text  = "Project Deadline: " + brief.GetProjectdeadline();
	}
}