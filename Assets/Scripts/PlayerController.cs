using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

	public float inputDelay = 0.1f;
	public float forwardVelocity = 12;
	public float rotateVelocity = 30;

	public Quaternion targetRotation {get; private set;}
	Rigidbody _rigidbody;
	Animator animator;
	float forwardInput = 0;
	float turnInput = 0;

	void Start() {
		targetRotation = transform.rotation;
		_rigidbody = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
	}

	void getInput() {
		forwardInput = CrossPlatformInputManager.GetAxis("Vertical");
		turnInput = CrossPlatformInputManager.GetAxis("Horizontal");
		animator.SetFloat("Forward", Mathf.Abs(forwardInput));
	}

	void Update() {
		getInput();
		Turn();
	}
	void FixedUpdate() {
		Move();
	}

	void Turn() {
		float angle = rotateVelocity * turnInput * Time.deltaTime;
		targetRotation *= Quaternion.AngleAxis(angle, Vector3.up);
		transform.rotation = targetRotation;
	}

	void Move() {
		if(Mathf.Abs(forwardInput) > inputDelay) {
			_rigidbody.velocity = transform.forward * forwardInput * forwardVelocity;
		} else {
			_rigidbody.velocity = Vector3.zero;
		}
	}
}
