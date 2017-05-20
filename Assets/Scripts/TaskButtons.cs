using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TaskButtons : MonoBehaviour {

	public Button yourButton;
    private Task task;
	public GameObject ModalBox;
	private GameObject box;


	// Use this for initialization
	void Start () {
		Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
	}
	 public void TaskOnClick()
    {
    box = Instantiate(ModalBox,Vector3.zero,Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
