using UnityEngine;
using System.Collections;

public class FallAfterTime : MonoBehaviour {

	public float timeToFallAfter = 5.0f;
	private float startTime;

	// Use this for initialization
	void Start () {
		rigidbody.useGravity = false;
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - timeToFallAfter > startTime) {
			rigidbody.useGravity = true;
		}
	}
}
