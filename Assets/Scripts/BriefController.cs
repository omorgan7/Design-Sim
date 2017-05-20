using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BriefController : MonoBehaviour {

	public GameObject BriefGameObject;
	Brief brief;
	// Use this for initialization
	void Start(){
		brief = BriefGameObject.GetComponent<Brief>();
	}
	// Update is called once per frame
	void Update () {
		if(BriefGameObject != null){
			brief.PerformProgress();
			if(brief.RemainingProjectPoints() <= 0f){
				Destroy(BriefGameObject);
			}
		}
	}
}
