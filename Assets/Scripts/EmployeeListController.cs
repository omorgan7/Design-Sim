using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EmployeeListController : MonoBehaviour {

	public GameObject button;
	private EmployeeController EC;
	private float width;
	private float height;
	private RectTransform reference;
	private float buttonheight;

	// Use this for initialization
	void Start () {
		GameObject EventSystem = GameObject.Find("EventSystem");
		EC = EventSystem.GetComponent<EmployeeController>();
		reference = gameObject.GetComponent<RectTransform>();
		width = reference.rect.width;
		height = reference.rect.height;
		buttonheight = button.GetComponent<RectTransform> ().rect.height;
		StartCoroutine(DelayedStart());	
		
	}
	IEnumerator DelayedStart(){
		while(EC.isSpawned == false){
			yield return null;
		}
		for(int i=0; i<EC.NumEmployees; ++i){
			GameObject newButton = Instantiate(button);
			SetButtonTransform(newButton,i);
			newButton.transform.SetParent(reference.transform, false);
			EmployeeButton sampleButton = newButton.GetComponent<EmployeeButton>();
			sampleButton.SetUp(EC.EmployeeList[i]);
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
		
	}
}
