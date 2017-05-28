﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TaskButtons : MonoBehaviour {
	public GameObject ModalBox;
	public Button yourButton;
	public GameObject btn_text;
	
	private Brief brief;

	private GameObject box;
	public GameObject parent;
	private BriefController BC;
	private Text txt;


	// Use this for initialization
	void Start (){
		Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
		GameObject EventSystem = GameObject.Find("EventSystem");
		BC = EventSystem.GetComponent<BriefController>();
		
	}
	public void TaskOnClick(){
    	box = Instantiate(ModalBox,Vector3.zero,Quaternion.identity);
		//RectTransform boxPanel = box.GetComponentInChildren<RectTransform>();
		//find panel in the children, then do get component on the panel child to get that.
		 GameObject boxPanel= GameObject.Find("BoxPanel");
		 TaskData data = boxPanel.GetComponent<TaskData>();
		print(data);
		data.Setup(brief);
	}

	
	// Update is called once per frame
	void Update () {
		// if (BC.BriefLength>0){
		// 	txt.text =" " + brief.GetBriefName();
		// }


	}
	public void Setup(Brief newbrief){
		brief = newbrief;
		txt = btn_text.GetComponent<Text>();
		txt.text ="  " +  brief.GetBriefName();
	}
}
