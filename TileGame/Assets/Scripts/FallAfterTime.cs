using UnityEngine;
using System.Collections;

public class FallAfterTime : MonoBehaviour {

    public float minTimeToFallAfter = 3.0f;
    public float maxTimeToFallAfter = 30.0f;
    public bool hasFallen;
    private float timeToFallAfter;
    private float startTime;

    // Use this for initialization
    void Start () {
        hasFallen = false;
        rigidbody.useGravity = false;
        startTime = Time.time;
        timeToFallAfter = Random.Range(minTimeToFallAfter, maxTimeToFallAfter);
    }

    // Update is called once per frame
    void Update () {
        if (Time.time - timeToFallAfter > startTime) {
            rigidbody.useGravity = true;
            hasFallen = true;
        }
    }
}
