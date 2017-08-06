using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeAddList : MonoBehaviour {

	public GameObject ScrollViewContent;
	public GameObject EmployeeViewPrefab;
	public float uiOffset = 0.15f;
	public List<GameObject> EmployeeViews = new List<GameObject>();
	
	private int idx = -1;
	private BriefController bc;
	private EmployeeController ec;

	void Start(){
		GameObject eventsystem = GameObject.Find("EventSystem");
		bc = eventsystem.GetComponent<BriefController>();
		ec = eventsystem.GetComponent<EmployeeController>();
	}

	public void AddEmployee(){
		if(idx + 1 < ec.NumEmployees){
			EmployeeViews.Add(Instantiate<GameObject>(EmployeeViewPrefab));
			++idx;
			EmployeeViews[idx].GetComponent<RectTransform>().SetParent(ScrollViewContent.transform,false);
			UITransform.SetTransform(EmployeeViews[idx],EmployeeViewPrefab,0,idx*uiOffset);
		}
	}
	
	public void RemoveEmployee(){
		if(idx < 0){
			return;
		}
		Destroy(EmployeeViews[idx]);
		EmployeeViews.RemoveAt(idx);
		--idx;
	}

	public void FinishBriefs(){
		if(idx < 0){
			return;
		}
		print(idx);
		
		float[] durations = new float[idx+1];
		int count = 0;
		foreach(var ev in EmployeeViews){
			durations[count] = (float) ev.GetComponentInChildren<Incrementor>().ReturnNum();
			++count;
		}
		ec.AddWork(new Brief(),idx+1,durations);
		Destroy(gameObject);
	}

}
