using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public KeyCode minusXKey;
	public KeyCode plusXKey;
	public KeyCode minusZKey;
	public KeyCode plusZKey;

	public float timeToMove = 0.5f;
	private bool moving;
	private float timeStartedMoving;
	private Vector3 originalPosition;
	private Vector3 targetPosition;

	// Use this for initialization
	void Start () {
		moving = false;
		timeStartedMoving = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (!moving) {
			if (Input.GetKey(minusXKey)) {
				StartMoving();
				targetPosition = new Vector3(originalPosition.x - 1, originalPosition.y, originalPosition.z);
			}
			if (Input.GetKey(plusXKey)) {
				StartMoving();
				targetPosition = new Vector3(originalPosition.x + 1, originalPosition.y, originalPosition.z);
			}
			if (Input.GetKey(minusZKey)) {
				StartMoving();
				targetPosition = new Vector3(originalPosition.x, originalPosition.y, originalPosition.z - 1);
			}
			if (Input.GetKey(plusZKey)) {
				StartMoving();
				targetPosition = new Vector3(originalPosition.x, originalPosition.y, originalPosition.z + 1);
			}
		}

		if (moving) {
			float timeDiff = Time.time - timeStartedMoving;

			transform.localPosition = Vector3.Lerp(originalPosition, targetPosition, timeDiff / timeToMove);

			if (timeDiff > timeToMove) {
				moving = false;
			}
		}
    }

	void StartMoving() {
		timeStartedMoving = Time.time;
		moving = true;
		originalPosition = transform.localPosition;
	}
}
