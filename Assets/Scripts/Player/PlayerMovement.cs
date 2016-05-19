using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField]
	private float speed;

	private float accel = 0.095f;
	private float currentSpeed = 0;

	[SerializeField]
	private float jumpSpeed;

	private bool grounded = true;
	private bool isJumping = false;
	private bool isSpinning = false;
	private bool isRunning = false;

	public Animator anim;
	Rigidbody playerRigidBody;
	int floorMask;
	float camRayLength = 100f;
	private float hor = 0;
	private float ver = 0;

	public Text hText;
	public Text vText;
	public Text debug;

	private Vector2 touchOrigin = Vector2.one;


	void Awake() {
		floorMask = LayerMask.GetMask("Floor");
		anim = GetComponent<Animator> ();
		playerRigidBody = GetComponent<Rigidbody> ();
	}

	void Move(float h, float v) {

		if (h != 0 || v != 0) {
			isRunning = true;
			anim.SetBool("Running", true);
		} else {
			isRunning = false;
			anim.SetBool("Running", false);
		}

		//If the player is jumping, use the last input before jump was pressed to continue moving in the air.
		Vector3 move;
		if (isJumping) {
			move = new Vector3(hor + h * 0.35f, 0f, ver + v * 0.5f);
			anim.SetBool("Jumping", true);
		} else {
			anim.SetBool("Jumping", false);
			move = new Vector3(h, 0f, v);
			if (h == 0 && v == 0) {
				currentSpeed = 0;		
			}
		}

		//Start moving slowly
		float calcedSpeed = currentSpeed;
		if (currentSpeed < speed) {
			calcedSpeed = currentSpeed;
		} else {
			calcedSpeed = speed;
		}

		// Rigidbody.MovePosition gets passed the current position + a new position * speed * Delta time.
		playerRigidBody.MovePosition (transform.position + move * calcedSpeed * Time.deltaTime);

		currentSpeed = currentSpeed + accel;

		//Store the last non-jumping input.

		if (!isJumping) {
			ver = v;
			hor = h;
		}

	}

	void Turning () {
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorHit;

		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask) && !isJumping) {
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			playerRigidBody.MoveRotation(newRotation);

			Ray ray = Camera.main.ScreenPointToRay(new Vector3(0, 0, 0));
			Debug.DrawRay(ray.origin, playerToMouse * 10, Color.yellow);
		}
	}

	void Animating (float h, float v) {
		bool walking = h !=0f || v != 0f;
//		anim.SetBool ("IsWalking", walking);
	}

	void FixedUpdate() 
	{

		if (Input.GetKey(KeyCode.Space)) {
			Jump ();
		}
		
		if (Input.GetKeyDown ("g")) {
			playerRigidBody.useGravity = !playerRigidBody.useGravity;		
		}




		float h = 0f;
		float v = 0f;


		h = Input.GetAxisRaw("Horizontal");
		v = Input.GetAxisRaw ("Vertical");

		Move (h,v);
		Turning ();
		Animating (h, v);


		if (isJumping) {
			transform.Rotate (transform.right, 1f * 36 * Time.deltaTime);	
		}

		RaycastHit hit;
		if (Physics.Raycast (transform.position, Vector3.down, out hit)) {
			if (hit.distance < 0.5) {
				grounded = true;
				isJumping = false;
			}
		}
	}


	void Jump() {
		isJumping = true;

		if (grounded) {
			playerRigidBody.velocity = playerRigidBody.velocity + new Vector3(0,jumpSpeed,0);
			grounded = false;
		}
	}



}



















