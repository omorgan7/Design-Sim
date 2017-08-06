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
	private Employee employee;

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
		EmployeePanelData E = box.GetComponent<EmployeePanelData>();
		E.SetUp(employee);
	}
	public void SetUp(Employee _employee){
		employee = _employee;
		txt = ButtonText.GetComponent<Text>();
		txt.text =(employee.id).ToString();
	}
}
