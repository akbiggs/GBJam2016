using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	public float followSpeed = 0.1f;

	private Vector3? startOffsetFromPlayer;
	private Player player;

	private void Start() {
		this.player = GameObject.FindObjectOfType<Player>();
	}

	// Update is called once per frame
	private void Update() {
		if (player != null) {
			if (!startOffsetFromPlayer.HasValue) {
				startOffsetFromPlayer = this.transform.position - player.transform.position;
				return;
			}

			Vector3 desiredPosition = player.transform.position + startOffsetFromPlayer.Value;
			Vector3 currentPosition = this.transform.position;
			if (currentPosition.z > desiredPosition.z) {
				this.transform.position =
					currentPosition.SetZ(
						Mathf.Max(desiredPosition.z, currentPosition.z - followSpeed * Time.deltaTime));
			} else {
				this.transform.position =
					currentPosition.SetZ(
						Mathf.Min(desiredPosition.z, currentPosition.z + followSpeed * Time.deltaTime));
			}
		}
	}

}
