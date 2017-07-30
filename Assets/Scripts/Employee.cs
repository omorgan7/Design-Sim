using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Employee{
	public Employee(){}

	enum Seniority {Junior=1, Mid=3, Senior=5,Director=10};
	Seniority rank = Seniority.Junior;

	public SortedSet<WorkChunk> WorkQueue = new SortedSet <WorkChunk>(new CompareBriefPriority());

	private float BaseProjectPointsRate = 0.1f;
	public bool isBusy = false;

	public float GetProjectPointsRate(){
		return (float) rank * BaseProjectPointsRate;
	}

	public float GetCost(){
		return Mathf.Pow(2, (float) rank);
	}

	public void AddWork(Brief b, float duration){
		WorkQueue.Add(new WorkChunk(duration, b));
	}
	public void RemoveCompletedWork(){
		WorkQueue.Remove(WorkQueue.First());
	}

	public void UpdatePriorityQueue(Brief a, Brief b){
		// WorkQueue.Remove(a); //might fail later;
		// WorkQueue.Remove(b);
		// WorkQueue.Add(a);
		// WorkQueue.Add(b);		
	}
	public void Update(float TimeFromLastUpdate){
		float ProjectPointsCompleted = TimeFromLastUpdate*GetProjectPointsRate();
		WorkQueue.First().brief.PerformProgress(ProjectPointsCompleted); 
		if(WorkQueue.First().brief.RemainingProjectPoints()<=0.0f){
			RemoveCompletedWork();
		}
	}

}

public class CompareBriefPriority:Comparer<WorkChunk>{
	public override int Compare(WorkChunk a, WorkChunk b){ 
		return System.Convert.ToInt32(a.brief.priorityFactor > b.brief.priorityFactor); //is this correct way round?
	}
}