using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BriefController : MonoBehaviour {

	public List<Brief> BriefsList = new List<Brief>();
	public EmployeeController ec;
	public int BriefLength = 0;
	public bool isChanged;
	//Brief brief;
	// Use this for initialization
	void Start(){
		StartCoroutine(DelayedStart());
	}

	IEnumerator DelayedStart(){
		while(ec.isSpawned == false){
			yield return null;
		}
	}

	// Update is called once per frame
	void Update () {
		for(int i =0; i<BriefLength; i++){
			BriefsList[i].PerformProgress();
			if(BriefsList[i].RemainingProjectPoints() <= 0.0f){
				BriefsList.RemoveAt(i);
				BriefLength--;
				i--;
				isChanged = true;
			}
		}
	}
	public void AddBrief(int NumEmployees){
		BriefsList.Add(new Brief(NumEmployees,ec));
		BriefLength++;
		isChanged = true;
	}

	public void AddBrief(Brief b){
		BriefsList.Add(b);
		++BriefLength;
		isChanged = true;
	}

	public void UserUpvote(int currentIndex){
		if(currentIndex == 0){
			return;
		}
		swapBriefs(currentIndex, currentIndex-1);
	}
	public void UserDownvote(int currentIndex){
		if(currentIndex + 1 == BriefLength){
			return;
		}
		swapBriefs(currentIndex, currentIndex+1);
	}

	private void swapBriefs(int from, int to){
		Brief temp = BriefsList[from];
		BriefsList[from] = BriefsList[to];
		BriefsList[to] = temp;
		isChanged = true;
	}
}
