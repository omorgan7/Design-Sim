using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowController : MonoBehaviour {

	private int currentPosition;
	public Button Up,Down;
	private BriefController BC;

	// Use this for initialization
	void Start(){
		GameObject Events = GameObject.Find("EventSystem");
		BC = Events.GetComponent<BriefController>();
		Button _Up = Up.GetComponent<Button>();
		Button _Down = Down.GetComponent<Button>();
		_Up.onClick.AddListener(delegate{BC.UserUpvote(currentPosition);});
		_Down.onClick.AddListener(delegate{BC.UserDownvote(currentPosition);});
	}
	public void inputPosition(int p){
		currentPosition = p;
	}
}
