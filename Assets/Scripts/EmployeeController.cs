using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EmployeeController : MonoBehaviour {

	//public List<Employee> EmployeeList = new List<Employee>();
	public LiteSortedList<Employee> EmployeeList = new LiteSortedList<Employee>(new ByQueueLength());
	
	public int NumEmployees = 6;
	public bool isChanged = false;
	public bool isSpawned = false;

	private BriefController bc;
	
	void Start(){
		for(int i=0; i<NumEmployees; ++i){
			EmployeeList.Add(new Employee(i));
		}
		bc = gameObject.GetComponent<BriefController>();

		isSpawned = true;
	}
	public void AddWork(Brief b, int NumBriefEmployees, float[] duration){
		for(int i=0; i<NumBriefEmployees; i++){
			print(duration[i]);
			print(EmployeeList.Count);
			print(EmployeeList[i]);
			EmployeeList[i].AddWork(b,duration[i]);
			b.AddEmployee(EmployeeList[i]);
		}
		bc.AddBrief(b);
	}
	
	void Update(){
		for(int i=0; i<NumEmployees; ++i){
			EmployeeList[i].Update(Time.deltaTime);
		}
	}
}

public class ByQueueLength : Comparer<Employee>{
	public override int Compare(Employee a, Employee b){
		return System.Convert.ToInt32(a.WorkQueue.Count < b.WorkQueue.Count);
	}
}

