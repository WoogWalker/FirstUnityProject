using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {
	public Transform target; //Transform компонент отвечющий за расположение объекта
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
	}
}
