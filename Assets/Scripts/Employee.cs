using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employee{
	public Employee(){}

	enum Seniority {Junior=1, Mid=3, Senior=5,Director=10};
	Seniority rank = Seniority.Junior;

	public Queue workqueue = new Queue();

	private float BaseProjectPointsRate = 0.1f;
	public bool isBusy = false;

	public float GetProjectPointsRate(){
		return (float) rank * BaseProjectPointsRate;
	}

	public float GetCost(){
		return Mathf.Pow(2,(float) rank);
	}

	public void AddWork(Brief b,float duration){
		workqueue.Enqueue(new Pairing(b,duration));
	}

}

struct Pairing{
	Brief b;
	float duration;
	public Pairing(Brief _b, float _duration){
		b = _b;
		duration = _duration;
	}
}
