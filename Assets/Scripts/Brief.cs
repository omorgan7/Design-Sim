using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brief{

	private string BriefName ;
	private float ProjectPoints, InitialProjectPoints;
	public EmployeeController employeecontroller;
	List<Employee> assignedEmployees = new List<Employee>();
	public int NumEmployees = 0;
	public float Cost;
	public float time;
	public float reward;
	public float deadline = 20f;
	public float elapsedTime;
	public float priorityFactor;

	// Use this for initialization
	public Brief(int _NumEmployees, EmployeeController _employeecontroller) {
		employeecontroller = _employeecontroller;
		BriefName = "Test Project";
		ProjectPoints = 10f;
		InitialProjectPoints = ProjectPoints;
		Cost = 50f;
		reward = 100f;
		int i =0;
		int j =0;
		while(i < _NumEmployees && j <employeecontroller.EmployeeList.Count){
			if(employeecontroller.EmployeeList[j].isBusy == false){
				assignedEmployees.Add(employeecontroller.EmployeeList[j]);
				employeecontroller.EmployeeList[j].isBusy = true;
				++i;
			}

			++j;
		}
		NumEmployees = i;
	}

	public float RemainingProjectPoints(){
		return ProjectPoints;
	}

	public void PerformProgress(){
		for(int i = 0; i<NumEmployees; i++){
			ProjectPoints -= assignedEmployees[i].GetProjectPointsRate() *Time.deltaTime;
		}
		elapsedTime += Time.deltaTime;
		priorityFactor = 1.0f/(deadline - elapsedTime);
	}

	public float PercentageDone(){
		return ProjectPoints/InitialProjectPoints;
	}

	public void AddEmployee(){
		assignedEmployees.Add(new Employee());
		NumEmployees++;
	}
	public void RemoveEmployee(int EmployeeIndex){
		assignedEmployees[EmployeeIndex].isBusy = false;
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
	public string GetProjectCost(){
		return Cost.ToString();
	}
	public string GetProjectReward(){
		return reward.ToString();
	}
	public string GetProjectDeadline(){
		return deadline.ToString();
	}
	public void ChangeName(string name){
		BriefName = name;
	}
	
}