using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BriefController : MonoBehaviour {

	public GameObject BriefGameObject;
	public List<Brief> BriefsList = new List<Brief>();
	public int BriefLength = 0;
	//Brief brief;
	// Use this for initialization
	void Start(){
		AddBrief();
		AddBrief();
	}
	// Update is called once per frame
	void Update () {
		for(int i =0; i<BriefLength; i++){
			BriefsList[i].PerformProgress();
			if(BriefsList[i].RemainingProjectPoints() <= 0.0f){
				BriefsList.RemoveAt(i);
				BriefLength--;
				i--;
			}
		}
	}
	void AddBrief(){
		BriefsList.Add(new Brief());
		BriefLength++;
	}

	void userUpvote(int currentIndex){
		if(currentIndex == 0){
			return;
		}
		swapBriefs(currentIndex, currentIndex);

	}
	void userDownvote(int currentIndex){
		if(currentIndex + 1 == BriefLength){
			return;
		}
		swapBriefs(currentIndex, currentIndex+1);
	}

	void swapBriefs(int from, int to){
		Brief temp = BriefsList[from];
		BriefsList[from] = BriefsList[to];
		BriefsList[to] = temp;
	}
}
