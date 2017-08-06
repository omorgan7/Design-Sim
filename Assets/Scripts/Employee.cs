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

	public void UpdatePriorityQueue(Brief a, Brief b){
		int index;
		index = WorkQueue.data.FindIndex(x => x == a);
		float durationa = WorkQueue.data[index].duration - WorkQueue.data[index].currenttime;
		WorkQueue.RemoveAt(index); //might fail later;
		index = WorkQueue.data.FindIndex(x => x == b);
		float durationb = WorkQueue.data[index].duration - WorkQueue.data[index].currenttime;
		WorkQueue.RemoveAt(index);
		AddWork(a, durationa);
		AddWork(b, durationb);		
	}
	public void Update(float TimeFromLastUpdate){
		float ProjectPointsCompleted = TimeFromLastUpdate*GetProjectPointsRate();
		WorkQueue.data[0].brief.PerformProgress(ProjectPointsCompleted); 
		if(WorkQueue.data[0].brief.RemainingProjectPoints()<=0.0f){
			RemoveCompletedWork();
		}
		float TimeSpent = TimeFromLastUpdate;
		UpdateBriefTime(TimeSpent);
		if(WorkQueue.data[0].currenttime>=WorkQueue.data[0].duration){
			RemoveCompletedWork();
		}
	}
	public void UpdateBriefTime(float TimeSpent){
		WorkQueue.data[0].currenttime += TimeSpent;
	}
}

public class CompareBriefPriority:Comparer<WorkChunk>{
	public override int Compare(WorkChunk a, WorkChunk b){ 
		return System.Convert.ToInt32(a.brief.priorityFactor > b.brief.priorityFactor); //is this correct way round?
	}
}