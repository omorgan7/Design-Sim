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
	private Vector3 parentPos;
	private float height;
	private float width;
	private float buttonheight;
	// Use this for initialization
	void Start () {
		//RefreshDisplay ();
		GameObject EventSystem = GameObject.Find("EventSystem");
		BC = EventSystem.GetComponent<BriefController>();
	//	parentPos = new Vector3(contentPanel.localposition.x,contentPanel.position.y, contentPanel.position.z) ;
		width = contentPanel.rect.width;
		height = contentPanel.rect.height;
		buttonheight = button.GetComponent<RectTransform> ().rect.height;
		print(height);

	}
	void RefreshDisplay(){
	
	}
	private void RemoveButtons(){

	}
	private void AddButtons(){
		if(onebutton == false){
			for (int i =0; i<BC.BriefLength; i++){
				Vector3 pos = new Vector3(- width/2.0f, height/2.0f-(buttonheight+5.0f)*(i+1), 0.0f );
				GameObject newButton = Instantiate(button, pos, Quaternion.identity);

				newButton.transform.SetParent(contentPanel.transform, false);
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
