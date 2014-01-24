﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public KeyCode minusXKey;
    public KeyCode plusXKey;
    public KeyCode minusZKey;
    public KeyCode plusZKey;

    private Animation _animation;

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

        _animation = GetComponentInChildren<Animation>();
        _animation.Play("Idle");
    }

    // Update is called once per frame
    void Update () {

        GridController gridController = tileGrid.GetComponent<GridController>();
        if (gridController.HasTileFallen((int)Mathf.Round(transform.localPosition.x),
                                         (int)Mathf.Round(transform.localPosition.z))) {
            alive = false;
            _animation.CrossFade("Fall");
            return;
        }

        if (!moving) {
            _animation.PlayQueued("Idle");
            if (Input.GetKey(minusXKey)) {
                transform.localEulerAngles = new Vector3(0, -90, 0);
                targetPosition = new Vector3(transform.localPosition.x - 1,
                                             transform.localPosition.y,
                                             transform.localPosition.z);
                StartMoving();
            }
            if (Input.GetKey(plusXKey)) {
                transform.localEulerAngles = new Vector3(0, 90, 0);
                targetPosition = new Vector3(transform.localPosition.x + 1,
                                             transform.localPosition.y,
                                             transform.localPosition.z);
                StartMoving();
            }
            if (Input.GetKey(minusZKey)) {
                transform.localEulerAngles = new Vector3(0, 180, 0);
                targetPosition = new Vector3(transform.localPosition.x,
                                             transform.localPosition.y,
                                             transform.localPosition.z - 1);
                StartMoving();
            }
            if (Input.GetKey(plusZKey)) {
                transform.localEulerAngles = new Vector3(0, 0, 0);
                targetPosition = new Vector3(transform.localPosition.x,
                                             transform.localPosition.y,
                                             transform.localPosition.z + 1);
                StartMoving();
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
        _animation.Play("Jump");
        timeStartedMoving = Time.time;
        moving = true;
        originalPosition = transform.localPosition;
        RoundTargetPosition();
    }

    void RoundTargetPosition() {
        targetPosition = new Vector3((int)Mathf.Round(targetPosition.x),
                                     targetPosition.y,
                                     (int)Mathf.Round(targetPosition.z));
    }
}
