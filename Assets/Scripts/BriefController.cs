using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BriefController : MonoBehaviour {

	public GameObject BriefGameObject;
	public List<Brief> BriefsList = new List<Brief>();
	public int BriefLength = 0;
	BriefComparer briefcomparer;
	//Brief brief;
	// Use this for initialization
	void Start(){
		AddBrief();
		briefcomparer = new BriefComparer();
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
		BriefsList.Sort(briefcomparer);
	}
	void AddBrief(){
		BriefsList.Add(new Brief());
		BriefLength++;
	}
}
