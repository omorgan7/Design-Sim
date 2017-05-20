using System.Collections;
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
	public float priorityFactor;

	// Use this for initialization

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
		priorityFactor = 1.0f/(deadline - elapsedTime);
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

public class BriefComparer: IComparer<Brief>{
	public int Compare(Brief x, Brief y){
		if(x == null){
			if(y==null){
				return 0;
			}
			return -1;
		}
		else{
			if(y == null){
				return 1;
			}
		}
		if(x.priorityFactor > y.priorityFactor){
			return 1;
		}
		else if(x.priorityFactor == y.priorityFactor){
			return 0;
		}
		else{
			return -1;
		}
	}
}