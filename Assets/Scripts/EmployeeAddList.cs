﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeAddList : MonoBehaviour {

	public GameObject ScrollViewContent;
	public GameObject EmployeeViewPrefab;
	public float uiOffset = 0.15f;
	public List<GameObject> EmployeeViews = new List<GameObject>();
	
	private int idx = -1;
	private RectTransform reference;
	private BriefController bc;

	void Start(){
		reference = EmployeeViewPrefab.GetComponent<RectTransform>();
		GameObject eventsystem = GameObject.Find("EventSystem");
		bc = eventsystem.GetComponent<BriefController>();
	}

	public void AddEmployee(){
		EmployeeViews.Add(Instantiate<GameObject>(EmployeeViewPrefab));
		++idx;
		SetTransform();
	}
	public void RemoveEmployee(){
		if(idx < 0){
			return;
		}
		Destroy(EmployeeViews[idx]);
		EmployeeViews.RemoveAt(idx);
		--idx;
	}
	void SetTransform(){
		RectTransform rt = EmployeeViews[idx].GetComponent<RectTransform>();
		rt.SetParent(ScrollViewContent.transform,false);
		rt.offsetMax = Vector2.zero;
		rt.offsetMin = Vector2.zero;
		rt.anchorMax = new Vector2(reference.anchorMax.x,reference.anchorMax.y-idx*uiOffset);
		rt.anchorMin = new Vector2(reference.anchorMin.x,reference.anchorMin.y-idx*uiOffset);
	}
	public void FinishBriefs(){
		if(idx < 0){
			return;
		}
		bc.AddBrief(idx);
		Destroy(gameObject);
	}

}