using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBrief : MonoBehaviour {

	public float spawnChanceInitial = 0.01f;
	private float briefSpawnChance;
	public float chanceIncrease = 0.001f;
	public GameObject ModalBox;
	private GameObject box;

	// Update is called once per frame
	void Start(){
		briefSpawnChance = spawnChanceInitial;
	}
	void Update () {
		if(box == null){
			briefSpawnChance += chanceIncrease*Time.deltaTime;
			float randomNum = Random.value;
			if(randomNum <= briefSpawnChance){
				box = Instantiate(ModalBox,Vector3.zero,Quaternion.identity);
				briefSpawnChance = spawnChanceInitial;
			}
		}
	}
}
