using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class EmployeeButton : MonoBehaviour {
	public GameObject ButtonText;
	public GameObject EmployeeOverview;
	private EmployeeController EC;
	private Text txt;
	private GameObject box;

	// Use this for initialization
	void Start () {
		Button btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		GameObject EventSystem = GameObject.Find("EventSystem");
		EC = EventSystem.GetComponent<EmployeeController>();
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void TaskOnClick(){
		GameObject U = GameObject.Find("UI");
		box = Instantiate(EmployeeOverview);
		box.GetComponent<RectTransform>().SetParent(U.transform,false);
		UITransform.SetTransform(box,EmployeeOverview,0,0);
	}
	public void SetUp(Employee E){
		txt = ButtonText.GetComponent<Text>();
		txt.text =(E.id).ToString();
	}
}
