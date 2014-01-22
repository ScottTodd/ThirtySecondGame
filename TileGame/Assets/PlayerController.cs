using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = transform.localPosition;

		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			newPosition.x = newPosition.x - 1;
		}
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			newPosition.x = newPosition.x + 1;
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			newPosition.z = newPosition.z + 1;
		}
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			newPosition.z = newPosition.z - 1;
		}

		transform.localPosition = newPosition;
    }
}
