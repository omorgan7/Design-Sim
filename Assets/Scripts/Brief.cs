using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brief : MonoBehaviour {

	private string BriefName;
	private float ProjectPoints;
	Employee[] assignedEmployees;
	public int NumEmployees = 5;
	// Use this for initialization

	void Start () {
		BriefName = "Test Project";
		ProjectPoints = 10f;
		assignedEmployees = new Employee[NumEmployees];
	}

	public float RemainingProjectPoints(){
		return ProjectPoints;
	}

	public void PerformProgress(){
		for(int i = 0; i<NumEmployees; i++){
			ProjectPoints -= assignedEmployees[i].ProjectPointsRate *Time.deltaTime;
		}
	}
}
