using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employee{
	public Employee(){}
	enum Seniority {Junior=1, Mid=2, Senior=5,Director=10};
	private float BaseProjectPointsRate = 0.1f;
	public bool isBusy = false;

	public float GetProjectPointsRate(){
		return 1f*BaseProjectPointsRate;
	}

}
