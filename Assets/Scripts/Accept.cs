using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Accept : MonoBehaviour { //CLOSES BUTTON AND PARENT

	private Button yourButton;

    void Start(){
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
	// Update is called once per frame
	void TaskOnClick(){
		Destroy(transform.parent.gameObject);
	}
}
