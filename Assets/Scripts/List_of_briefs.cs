using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class List_of_briefs : MonoBehaviour {
	
  //  public List<Brief> TaskList;
    public RectTransform contentPanel;
	public GameObject button;

	private Brief brief;
	private BriefController BC;
	private bool onebutton = false;
	// Use this for initialization
	void Start () {
		//RefreshDisplay ();
		GameObject EventSystem = GameObject.Find("EventSystem");
		BC = EventSystem.GetComponent<BriefController>();
		//Vector3
		float width = contentPanel.rect.width;
		float height = contentPanel.rect.height;

	}
	void RefreshDisplay(){
	
	}
	private void RemoveButtons(){

	}
	private void AddButtons(){
		if(onebutton == false){
			for (int i =0; i<1; i++){
				Vector3 pos = 
				GameObject newButton = Instantiate(button, Vector3.zero, Quaternion.identity);

			//	newButton.transform.SetParent(contentPanel.transform, false);
				GameObject temp = GameObject.Find("Task 1");
				TaskButtons sampleButton = temp.GetComponent<TaskButtons>();
				sampleButton.Setup(brief);
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		brief = BC.BriefsList[0];
		if(BC.BriefLength>0){
			AddButtons();
			onebutton = true;
		}
	}
}
