using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Employee{
	public int id = 0;

	public Employee(){}

	public Employee(int _id){
		id = _id;
	}

	enum Seniority {Junior=1, Mid=3, Senior=5,Director=10};
	Seniority rank = Seniority.Junior;

	public LiteSortedList<WorkChunk> WorkQueue = new LiteSortedList <WorkChunk>(new CompareBriefPriority());

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
		WorkQueue.RemoveAt(0);
	}
	
	public void UpdatePriorityQueue(Brief a){
		int index;
		index = WorkQueue.FindIndex(x => x == a);
		float durationa = WorkQueue[index].duration - WorkQueue[index].currenttime;
		WorkQueue.RemoveAt(index); 
		AddWork(a, durationa);		
	}

	public void Update(float TimeFromLastUpdate){
		float ProjectPointsCompleted = TimeFromLastUpdate*GetProjectPointsRate();
		if(WorkQueue.Count> 0){
			WorkQueue[0].brief.PerformProgress(ProjectPointsCompleted); 
			if(WorkQueue[0].brief.RemainingProjectPoints()<=0.0f){
				RemoveCompletedWork();
			}
		}
		if(WorkQueue.Count>0){
			float TimeSpent = TimeFromLastUpdate;
			UpdateBriefTime(TimeSpent);
			if(WorkQueue[0].currenttime >= WorkQueue[0].duration){
				RemoveCompletedWork();
			}
		}
	}
	public void UpdateBriefTime(float TimeSpent){
		WorkQueue[0].currenttime += TimeSpent;
	}
}

public class CompareBriefPriority:Comparer<WorkChunk>{
	public override int Compare(WorkChunk a, WorkChunk b){ 
		return System.Convert.ToInt32(a.brief.priorityFactor > b.brief.priorityFactor); //is this correct way round?
	}
}