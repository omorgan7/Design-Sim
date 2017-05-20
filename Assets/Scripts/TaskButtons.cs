using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TaskButtons : MonoBehaviour {

	public Button yourButton;
	public GameObject btn_text;
	private Brief brief;
	public GameObject ModalBox;
	private GameObject box;
	public GameObject parent;
	private BriefController BC;

	private Text txt;


	// Use this for initialization
	void Start (){
		Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
		txt = btn_text.GetComponent<Text>();
		GameObject EventSystem = GameObject.Find("EventSystem");
		BC = EventSystem.GetComponent<BriefController>();
		brief = BC.BriefsList[0];
		txt.text ="  " +  brief.GetBriefName();
	}
	public void TaskOnClick(){
    	box = Instantiate(ModalBox,Vector3.zero,Quaternion.identity);
	}

	
	// Update is called once per frame
	void Update () {
		brief = BC.BriefsList[0];
		txt.text =" " + brief.GetBriefName();
	}
	public void Setup(Brief newbrief){
		brief = newbrief;
	}
}
