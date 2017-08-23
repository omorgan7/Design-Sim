using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Incrementor : MonoBehaviour {

	// Use this for initialization

	private int num = 0;
	public GameObject NumberRepresentation;
	private Text numbertext;
	void Start () {
		numbertext = NumberRepresentation.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		numbertext.text = num.ToString();
	}

	public int ReturnNum(){
		return num;
	}

	public void Addone(){
		++num;
	}
	public void Subtractone(){
		if(num==0){
			return;
		}
		--num;
	}

}
