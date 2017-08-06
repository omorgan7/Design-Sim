using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EmployeeButton : MonoBehaviour {
	public GameObject EmployeeOverview;
	private Text txt;
	private Employee employee;
	void Start () {
		Button btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		GameObject U = GameObject.Find("UI");
		GameObject box = Instantiate(EmployeeOverview);
		box.GetComponent<RectTransform>().SetParent(U.transform,false);
		EmployeePanelData E = box.GetComponent<EmployeePanelData>();
		E.SetUp(employee);
	}
	public void SetUp(Employee _employee){
		employee = _employee;
		txt = gameObject.transform.GetChild(0).GetComponent<Text>();
		txt.text =(employee.id).ToString();
	}
}
