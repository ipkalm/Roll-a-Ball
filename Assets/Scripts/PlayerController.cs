using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public float speed;
	public Text countText;
	public Text winText;
	private int pickupsCount;

	private Rigidbody rb;
	private int count;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		this.count = 0;
		pickupsCount = GameObject.FindGameObjectsWithTag("PickUp").Length;
		SetCoungText ();
		winText.text = "";
	}
		
	void FixedUpdate () {
		float moveH = Input.GetAxis ("Horizontal");
		float moveV = Input.GetAxis ("Vertical");

		rb.AddForce (new Vector3 (moveH, 0.0f, moveV) *  speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("PickUp")) {
			other.gameObject.SetActive (false);
			this.count++;
			SetCoungText ();
		}
	}
	void SetCoungText() {
		countText.text = "Count :: " + this.count.ToString ();
		if (this.count >= pickupsCount) {
			winText.text = "You win!";
		}
	}
}