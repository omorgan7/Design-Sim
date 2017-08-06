using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BriefListController : MonoBehaviour {


	public GameObject button;
	public float uiOffset = 0.15f;
	public RectTransform contentPanel;

	private RectTransform reference;
	private BriefController BC;
	private ArrowController AC;
	private float height;
	private float width;
	private float buttonheight;

	// Use this for initialization
	void Start () {
		reference = button.GetComponent<RectTransform>();
		contentPanel = gameObject.GetComponent<RectTransform>();
		GameObject EventSystem = GameObject.Find("EventSystem");
		BC = EventSystem.GetComponent<BriefController>();
		width = contentPanel.rect.width;
		height = contentPanel.rect.height;
		buttonheight = button.GetComponent<RectTransform>().rect.height;	
	}
	void RefreshDisplay(){
	
	}
	private void RemoveButtons(){
		int NumberOfButtons = transform.childCount;
		for(int i=0; i< NumberOfButtons; ++i){
			GameObject.Destroy(contentPanel.GetChild(i).gameObject);
		}
	}
	private void AddButtons(){
		for (int i =0; i<BC.BriefLength; ++i){
			GameObject newbutton = Instantiate(button);
			SetButtonTransform(newbutton,i);
			ArrowController Arrows = newbutton.GetComponent<ArrowController>();
			Arrows.inputPosition(i);
			TaskButtons sampleButton = newbutton.GetComponent<TaskButtons>();
			sampleButton.Setup(BC.BriefsList[i]);
		}
	}

	void SetButtonTransform(GameObject newbutton, int idx){
		RectTransform rt = newbutton.GetComponent<RectTransform>();
		rt.SetParent(gameObject.transform,false);
		rt.offsetMax = Vector2.zero;
		rt.offsetMin = Vector2.zero;
		rt.anchorMax = new Vector2(reference.anchorMax.x,reference.anchorMax.y-idx*uiOffset);
		rt.anchorMin = new Vector2(reference.anchorMin.x,reference.anchorMin.y-idx*uiOffset);
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
