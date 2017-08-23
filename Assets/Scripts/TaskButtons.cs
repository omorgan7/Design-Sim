using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TaskButtons : MonoBehaviour {
	public GameObject boxprefab;
	private Brief brief;
	private GameObject UI;
	private Text txt;

	void Awake(){
		UI = GameObject.Find("UI");
	}
	void Start (){
		Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);		
	}
	public void TaskOnClick(){
		GameObject box = Instantiate(boxprefab);
		box.GetComponent<RectTransform>().SetParent(UI.transform,false);
		TaskData data = box.GetComponent<TaskData>();
		data.Setup(brief);
	}
	public void Setup(Brief newbrief){
		brief = newbrief;
		txt = gameObject.transform.GetChild(0).GetComponent<Text>();
		txt.text = brief.GetBriefName();
	}
}
