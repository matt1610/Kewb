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
	private bool sideWays = false;

	public Animator anim;
	Rigidbody playerRigidBody;
	int floorMask;
	float camRayLength = 100f;
	private float hor = 0;
	private float ver = 0;

	public Text hText;
	public Text vText;
	public Text debug;

	public CharacterController controller;

	// private Vector2 touchOrigin = Vector2.one;


	void Awake() {
		floorMask = LayerMask.GetMask("Floor");
		anim = GetComponent<Animator> ();
		playerRigidBody = GetComponent<Rigidbody> ();
		// controller = gameObject.GetComponent<CharacterController>();

		GameManager.Instance.onClicked += SubscribeMethod;
	}

	void SubscribeMethod()
	{
		Debug.Log ("From PlayerMovement.cs!");
	}

	void Move(float h, float v) {	
		// currentSpeed = currentSpeed + accel;
		// transform.position += transform.forward * (speed * v) * Time.deltaTime;

		// controller.SimpleMove(Vector3.forward);
	}

	void OnCollisionEnter(Collision other) {
		// if(other.gameObject.tag == "Floor") {
		// 	sideWays = transform.rotation.eulerAngles.x > 45 || transform.rotation.eulerAngles.x < -45 ||
		// 	transform.rotation.eulerAngles.z > 45 || transform.rotation.eulerAngles.z < -45;
		// }
	}

	void RotateBackUpright() {
		Quaternion target = Quaternion.Euler(0, transform.rotation.y, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 2.0f);
		sideWays = transform.rotation.eulerAngles.x > 45 || transform.rotation.eulerAngles.x < -45 ||
		transform.rotation.eulerAngles.z > 45 || transform.rotation.eulerAngles.z < -45;
	}

	void Turning (float h, float v) {
		transform.Rotate(0.0f, h * 3, 0.0f);
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

		// if(sideWays) {
		// 	RotateBackUpright();
		// 	Debug.Log("Trying to fucking rotate back");
		// }


		float h = 0f;
		float v = 0f;


		h = Input.GetAxisRaw("Horizontal");
		v = Input.GetAxisRaw ("Vertical");

		Move (h,v);
		Turning (h, v);
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