using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcceptBrief : MonoBehaviour {

	private Button yourButton;
	public GameObject prefab;

    void Start(){
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
	// Update is called once per frame
	void TaskOnClick(){
		Instantiate(prefab);
		Destroy(transform.parent.gameObject);
	}
}
