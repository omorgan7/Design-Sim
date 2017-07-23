using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeController : MonoBehaviour {

	public List<Employee> EmployeeList = new List<Employee>();
	public int Employees = 6;
	public bool isChanged = false;
	public bool isSpawned = false;
	
	void Start(){
		for(int i=0; i<Employees; ++i){
			EmployeeList.Add(new Employee());
		}
		isSpawned = true;
	}
}
