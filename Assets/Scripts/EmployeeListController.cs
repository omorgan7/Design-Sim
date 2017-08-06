using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EmployeeListController : MonoBehaviour {

	public GameObject button;
	private EmployeeController EC;
	private float width;
	private float height;
	private RectTransform panel;
	private float buttonheight;

	// Use this for initialization
	void Start () {
		GameObject EventSystem = GameObject.Find("EventSystem");
		EC = EventSystem.GetComponent<EmployeeController>();
		panel = gameObject.GetComponent<RectTransform>();
		width = panel.rect.width;
		height = panel.rect.height;
		buttonheight = button.GetComponent<RectTransform> ().rect.height;
		StartCoroutine(DelayedStart());	
		
	}
	IEnumerator DelayedStart(){
		while(EC.isSpawned == false){
			yield return null;
		}
		for(int i=0; i<EC.NumEmployees; ++i){
			Vector3 pos = new Vector3(- width/2.0f, height/2.0f-(buttonheight + 5.0f)*(i+1), 0.0f );
			GameObject newButton = Instantiate(button, pos, Quaternion.identity);
			newButton.transform.SetParent(panel.transform, false);
			EmployeeButton sampleButton = newButton.GetComponent<EmployeeButton>();
			sampleButton.SetUp(EC.EmployeeList[i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
