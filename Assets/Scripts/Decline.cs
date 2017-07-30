using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Decline : MonoBehaviour {

	private Button yourButton;

    void Start(){
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
	// Update is called once per frame
	void TaskOnClick(){
		Destroy(transform.parent.gameObject.transform.parent.gameObject);
	}
}
