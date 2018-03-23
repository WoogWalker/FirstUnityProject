using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float ceiling = 1;
	public float speedAcceleration = 0.05f;
	public float floor = 1;
	public string jump = "Jump";
	Rigidbody2D rigidbody2d;

	public float jumpForce;
	public float moveSpeed;
   	AudioSource audioS; // 11

	void Start()
	{
		rigidbody2d = GetComponent<Rigidbody2D>();
		audioS = GetComponent<AudioSource>();
	}

	void Update()
	{
		if(Input.GetButtonDown(jump)){
			audioS.Play();
			rigidbody2d.velocity = new Vector2(moveSpeed, jumpForce);
			
		}
		moveSpeed += Time.deltaTime*speedAcceleration;

	}

	/// <summary>
	/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	/// </summary>
	void FixedUpdate()
	{
		//print (transform.position.y);
		rigidbody2d.velocity = new Vector2(moveSpeed, rigidbody2d.velocity.y);
		if(transform.position.y >= ceiling || transform.position.y <= floor){
				Dead();
		}
	}

	public void Dead(){
		print ("dead");
		SceneManager.LoadScene(SceneManager.GetActiveScene().name); // рестарт сцены
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		Dead();
	}
}
