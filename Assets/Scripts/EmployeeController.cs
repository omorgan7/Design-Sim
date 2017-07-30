using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EmployeeController : MonoBehaviour {

	//public List<Employee> EmployeeList = new List<Employee>();
	public SortedSet<Employee> EmployeeList = new SortedSet<Employee>(new ByQueueLength());
	public int NumEmployees = 6;
	public bool isChanged = false;
	public bool isSpawned = false;
	
	void Start(){
		for(int i=0; i<NumEmployees; ++i){
			EmployeeList.Add(new Employee());
		}
		isSpawned = true;
	}
	public void AddWork(Brief b, int NumBriefEmployees, float duration){
		for(int i=0; i<NumBriefEmployees; i++){
			EmployeeList.ElementAt(i).AddWork(b,duration);
		}
	}
	
	void Update(){
		for(int i=0; i<NumEmployees; ++i){
			EmployeeList.ElementAt(i).Update(Time.deltaTime);
		}
	}
}

public class ByQueueLength : Comparer<Employee>{
	public override int Compare(Employee a, Employee b){
		return System.Convert.ToInt32(a.WorkQueue.Count < b.WorkQueue.Count);
	}
}

