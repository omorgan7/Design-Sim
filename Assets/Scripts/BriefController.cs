using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BriefController : MonoBehaviour {

	public GameObject BriefGameObject;
	public List<Brief> BriefsList = new List<Brief>();
	public List<float> PriorityFactor = new List<float>();
	public int BriefLength = 0;
	//Brief brief;
	// Use this for initialization
	void Start(){
		AddBrief();
	}
	// Update is called once per frame
	void Update () {
		for(int i =0; i<BriefLength; i++){
			BriefsList[i].PerformProgress();
			PriorityFactor[i] = 1.0f/(BriefsList[i].deadline - BriefsList[i].elapsedTime);
			if(BriefsList[i].RemainingProjectPoints() <= 0.0f){
				BriefsList.RemoveAt(i);
				BriefLength--;
				i--;
			}
		}
	}
	void AddBrief(){
		BriefsList.Add(new Brief());
		PriorityFactor.Add(0f);
		BriefLength++;
	}
}
