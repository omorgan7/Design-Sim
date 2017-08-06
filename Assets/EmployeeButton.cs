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
		box = Instantiate(EmployeeOverview,Vector3.zero,Quaternion.identity);
		GameObject boxPanel= GameObject.Find("BoxPanel");
		// TaskData data = boxPanel.GetComponent<TaskData>();
		// data.Setup(brief);
	}
	public void SetUp(Employee E){
		txt = ButtonText.GetComponent<Text>();
		txt.text ="  " +  (E.id).ToString();
	}
}
