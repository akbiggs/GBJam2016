using UnityEngine;
using System.Collections;

public class MovingBlock : MonoBehaviour {

	public enum MoveDirection {
	  Left, Up, Down, Right
	}

	private new Rigidbody rigidbody;

	private void Awake() {
		this.rigidbody = this.GetComponent<Rigidbody>();
	}

	private void FixedUpdate() {
		
	}
}
