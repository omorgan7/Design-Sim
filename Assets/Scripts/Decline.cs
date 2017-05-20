using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Decline : MonoBehaviour {
	public GameObject parent;
	public Button yourButton;

    void Start(){
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
	// Update is called once per frame
	void TaskOnClick(){
		Destroy(parent);
	}
}
