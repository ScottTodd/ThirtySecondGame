using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public KeyCode minusXKey;
	public KeyCode plusXKey;
	public KeyCode minusZKey;
	public KeyCode plusZKey;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = transform.localPosition;

		if (Input.GetKeyDown(minusXKey)) {
			newPosition.x = newPosition.x - 1;
		}
		if (Input.GetKeyDown(plusXKey)) {
			newPosition.x = newPosition.x + 1;
		}
		if (Input.GetKeyDown(minusZKey)) {
			newPosition.z = newPosition.z + 1;
		}
		if (Input.GetKeyDown(plusZKey)) {
			newPosition.z = newPosition.z - 1;
		}

		transform.localPosition = newPosition;
    }
}
