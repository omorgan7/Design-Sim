using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class List_of_briefs : MonoBehaviour {

    public RectTransform contentPanel;
	public GameObject button;
	private BriefController BC;
	private ArrowController AC;
	private bool onebutton = false;
	private float height;
	private float width;
	private float buttonheight;

	// Use this for initialization
	void Start () {
		GameObject EventSystem = GameObject.Find("EventSystem");
		BC = EventSystem.GetComponent<BriefController>();
		width = contentPanel.rect.width;
		height = contentPanel.rect.height;
		buttonheight = button.GetComponent<RectTransform> ().rect.height;
	}
	void RefreshDisplay(){
	
	}
	private void RemoveButtons(){
		int NumberOfButtons = transform.childCount;
		for(int i=0; i< NumberOfButtons; i++){
			GameObject.Destroy(contentPanel.GetChild(i).gameObject);
		}
	}
	private void AddButtons(){
			for (int i =0; i<BC.BriefLength; i++){
				Vector3 pos = new Vector3(- width/2.0f, height/2.0f-(buttonheight + 5.0f)*(i+1), 0.0f );
				GameObject newButton = Instantiate(button, pos, Quaternion.identity);
				ArrowController Arrows = newButton.GetComponent<ArrowController>();
				Arrows.inputPosition(i);
				newButton.transform.SetParent(contentPanel.transform, false);
				TaskButtons sampleButton = newButton.GetComponent<TaskButtons>();
				sampleButton.Setup(BC.BriefsList[i]);
			}
		

	}
	
	// Update is called once per frame
	void Update () {
		if(BC.isChanged == true){
			if(BC.BriefLength>0){
				RemoveButtons();
				AddButtons();
			}
			else{
				RemoveButtons();
			}
			BC.isChanged = false;	
		}
	}
}
