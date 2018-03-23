using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {
	public float minTime;
	public float maxTime;
	[Space]
	public float minY;
	public float maxY;
	[Space]
	public float generateDistance;
	float generateTime;

	public GameObject coin;
	void Start()
	{
		generateTime = Random.Range(minTime, maxTime) + Time.time;
	
	}

		
	void Generate(){
		GameObject newCoin = GameObject.Instantiate(coin);
		newCoin.transform.position = new Vector3(transform.position.x + generateDistance, Random.Range(minY, maxY));

	}

	void Update()
	{
		if (Time.time > generateTime){
			Generate();
			generateTime =  Random.Range(minTime, maxTime) + Time.time;
		}
	}
}