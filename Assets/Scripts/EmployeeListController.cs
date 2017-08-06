using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EmployeeListController : MonoBehaviour {

	public GameObject buttonprefab;
	private EmployeeController EC;
	private float width;
	private float height;
	private RectTransform reference;
	private float buttonheight;
	public float uiOffset = 0.15f;

	// Use this for initialization
	void Start () {
		GameObject EventSystem = GameObject.Find("EventSystem");
		EC = EventSystem.GetComponent<EmployeeController>();
		reference = gameObject.GetComponent<RectTransform>();
		width = reference.rect.width;
		height = reference.rect.height;
		buttonheight = buttonprefab.GetComponent<RectTransform> ().rect.height;
		StartCoroutine(DelayedStart());	
		
	}
	IEnumerator DelayedStart(){
		while(EC.isSpawned == false){
			yield return null;
		}
		for(int i=0; i<EC.NumEmployees; ++i){
			GameObject newbutton = Instantiate(buttonprefab);
			newbutton.GetComponent<RectTransform>().SetParent(gameObject.transform,false);
			UITransform.SetTransform(newbutton,buttonprefab,0, i*uiOffset);
			EmployeeButton sampleButton = newbutton.GetComponent<EmployeeButton>();
			sampleButton.SetUp(EC.EmployeeList[i]);
		}
	}
	
	
	// Update is called once per frame
	void Update () {
		
	}
}
