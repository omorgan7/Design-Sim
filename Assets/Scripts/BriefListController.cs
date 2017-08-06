using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BriefListController : MonoBehaviour {


	public GameObject buttonprefab ;
	public float uiOffset = 0.15f;
	public RectTransform contentPanel;

	private RectTransform reference;
	private BriefController BC;
	private bool onebutton = false;
	private float height;
	private float width;
	private float buttonheight;

	// Use this for initialization
	void Start () {
		reference = button.GetComponent<RectTransform>();
		contentPanel = gameObject.GetComponent<RectTransform>();
		GameObject EventSystem = GameObject.Find("EventSystem");
		BC = EventSystem.GetComponent<BriefController>();
	}

	private void RemoveButtons(){
		int NumberOfButtons = transform.childCount;
		for(int i=0; i< NumberOfButtons; ++i){
			GameObject.Destroy(contentPanel.GetChild(i).gameObject);
		}
	}
	private void AddButtons(){
		for (int i =0; i<BC.BriefLength; ++i){
			GameObject newbutton = Instantiate(buttonprefab);
			newbutton.GetComponent<RectTransform>().SetParent(gameObject.transform,false);
			UITransform.SetTransform(newbutton,buttonprefab,0,i*uiOffset);
			SetButtonTransform(newbutton,i);
			ArrowController Arrows = newbutton.GetComponent<ArrowController>();
			Arrows.inputPosition(i);
			TaskButtons sampleButton = newbutton.GetComponent<TaskButtons>();
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
