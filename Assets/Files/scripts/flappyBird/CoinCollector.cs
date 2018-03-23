using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour {

	public Text uiCoinCount;
	public int coinCounter = 0;

	void OnTriggerEnter2D(Collider2D other) // вызывается только когда мы входим в него
	{
		Coin coin = other.gameObject.GetComponent<Coin>();
		if(coin != null){ // является ли other coin ом
			coinCounter++;
			GameObject.Destroy(coin.transform.parent.gameObject);
			uiCoinCount.text="Coins: " + coinCounter;
		}
	}
}