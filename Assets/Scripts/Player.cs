using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float movementSpeed = 12f;
	public float standingStillSpeed = 0.1f;
	public float startMovingSpeed = 100f;
	public Animator animator;
	private Rigidbody rigidbody;

	private void Awake() {
		this.rigidbody = this.GetComponent<Rigidbody>();
	}

	private void Update() {
		Vector3 movement = new Vector2();
		if (Input.GetKey(KeyCode.UpArrow)) {
			movement.z = 1;
		} else if (Input.GetKey(KeyCode.DownArrow)) {
			movement.z = -1;
		}

		if (Input.GetKey(KeyCode.LeftArrow)) {
			movement.x = -1;
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			movement.x = 1;
		}

		movement.Normalize();
		if (this.rigidbody.velocity.sqrMagnitude < (standingStillSpeed)) {
			if (Mathf.Abs(movement.magnitude) < 0.001) {
				this.animator.SetBool("moving", false);
			} else {
				this.rigidbody.AddForce(movement * startMovingSpeed * Time.deltaTime);
			}
		} else {
			this.rigidbody.AddForce(movement * movementSpeed * Time.deltaTime);
			animator.SetBool("moving", true);
		}
	}
}
