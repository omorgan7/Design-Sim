﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brief : MonoBehaviour {

	private string BriefName ;
	private float ProjectPoints;
	List<Employee> assignedEmployees = new List<Employee>();
	public int NumEmployees = 5;
	public float Cost;
	public float time;
	public float reward;
	public float deadline = 20f;
	public float elapsedTime;

	// Use this for initialization


	void Start () {
	public Brief() {
		BriefName = "Test Project";
		ProjectPoints = 10f;
		for(int i = 0; i<NumEmployees; i++){
			assignedEmployees.Add(new Employee());
		}
	}

	public float RemainingProjectPoints(){
		return ProjectPoints;
	}

	public void PerformProgress(){
		for(int i = 0; i<NumEmployees; i++){
			ProjectPoints -= assignedEmployees[i].ProjectPointsRate *Time.deltaTime;
		}
		elapsedTime += Time.deltaTime;
	}

	public void AddEmployee(){
		assignedEmployees.Add(new Employee());
		NumEmployees++;
	}
	public void RemoveEmployee(int EmployeeIndex){
		assignedEmployees.RemoveAt(EmployeeIndex);
		NumEmployees--;
	}

	public string GetBriefName(){
		return BriefName;
	}
	public string GetNumEmployees(){
		return NumEmployees.ToString();
	}
	public string GetProjectPoints(){
		return ProjectPoints.ToString();
	}
	
}
