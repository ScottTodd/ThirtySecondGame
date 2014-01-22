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

	public GameObject tileGrid;

	public bool alive;

	// Use this for initialization
	void Start () {
		moving = false;
		alive = true;
		timeStartedMoving = 0.0f;
		originalPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		
		
		GridController gridController = tileGrid.GetComponent<GridController>();
		if (gridController.HasTileFallen((int)Mathf.Round(transform.localPosition.x),
		                                 (int)Mathf.Round(transform.localPosition.z))) {
			alive = false;
			return;
		}

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
				originalPosition = transform.localPosition;
			}
		}
    }

	void StartMoving() {
		timeStartedMoving = Time.time;
		moving = true;
		originalPosition = transform.localPosition;
	}
}
