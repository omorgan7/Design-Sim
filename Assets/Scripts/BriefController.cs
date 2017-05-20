using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BriefController : MonoBehaviour {

	GameObject BriefGameObject;
	Brief brief;
	// Use this for initialization
	void Start(){
		BriefGameObject = GameObject.Find("Briefs");
		brief = BriefGameObject.GetComponent<Brief>();
	}
	// Update is called once per frame
	void Update () {
		print(brief.RemainingProjectPoints());
	}
}
