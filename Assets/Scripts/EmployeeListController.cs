using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EmployeeListController : MonoBehaviour {
	public GameObject buttonprefab;
	public float uiOffset = 0.15f;
	private EmployeeController EC;
	
	void Start () {
		GameObject EventSystem = GameObject.Find("EventSystem");
		EC = EventSystem.GetComponent<EmployeeController>();
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
}
