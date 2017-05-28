using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskData : MonoBehaviour {
	public GameObject BriefName;
	public GameObject ProjectPoints;
	public GameObject NumEmployees;
	public GameObject reward;
	public GameObject deadline;
	public GameObject cost;
	public GameObject panel;
	public GameObject close;
	public Button closeButton;
	
	private BriefController BC;
	private Text one;
	private Text two;
	private Text three;
	private Text four;
	private Text five;
	private Text six;
	private Brief brief;

	//Use this for initialization
	void Start () {
		one = BriefName.GetComponent<Text>();
		two = ProjectPoints.GetComponent<Text>();
		three = cost.GetComponent<Text>();
		four = reward.GetComponent<Text>();
		five = NumEmployees.GetComponent<Text>();
		six = deadline.GetComponent<Text>();
		GameObject EventSystem = GameObject.Find("EventSystem");
		BC = EventSystem.GetComponent<BriefController>();	
		Button btn = closeButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);		
	}
	void TaskOnClick(){
		Destroy(close);
	}
	// Update is called once per frame
	void Update () {
		brief = BC.BriefsList[0];
		print(brief== null);
		one.text = brief.GetBriefName();
		two.text= "Project Points: " + brief.GetProjectPoints();
		three.text = "Project Cost: £" + brief.GetProjectCost();
		four.text = "Project Reward: £" + brief.GetProjectReward();
		five.text = "Number of Employees: " + brief.GetNumEmployees();	
		six.text = "Project Deadline: " + brief.GetProjectDeadline();
	}
}