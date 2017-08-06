using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TaskButtons : MonoBehaviour {
	public GameObject boxprefab;
	public Button yourButton;
	public GameObject btn_text;
	
	private Brief brief;
	private GameObject UI;
	private GameObject box;
	public GameObject parent;
	private BriefController BC;
	private Text txt;

	void Awake(){
		UI = GameObject.Find("UI");
	}

	// Use this for initialization
	void Start (){
		Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
		GameObject EventSystem = GameObject.Find("EventSystem");
		BC = EventSystem.GetComponent<BriefController>();
		
	}
	
	public void TaskOnClick(){
		box = Instantiate(boxprefab,Vector3.zero,Quaternion.identity);
		box.GetComponent<RectTransform>().SetParent(UI.transform,false);
		UITransform.SetTransform(box,boxprefab,0,0);
		TaskData data = box.GetComponent<TaskData>();
		data.Setup(brief);
	}

	
	// Update is called once per frame
	void Update () {

	}
	public void Setup(Brief newbrief){
		brief = newbrief;
		txt = btn_text.GetComponent<Text>();
		txt.text ="  " +  brief.GetBriefName();
	}
}
