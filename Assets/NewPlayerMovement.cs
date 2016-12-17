using UnityEngine;
using System.Collections;
using Kewb;

public class NewPlayerMovement : MonoBehaviour {

	CharacterController controller{get;set;}
	public float Speed;
	public float JumpSpeed = 8.0F;
	public float TurnSpeed = 8f;
    public float gravity = 20.0F;
	public bool TrampolineJump;
	public float TrampolineBoost;
	private Vector3 moveDirection = Vector3.zero;
	private InputManager inputManager {get;set;}

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		inputManager = new InputManager();
	}
	void OnControllerColliderHit(ControllerColliderHit hit) {
		ICollideable other = hit.gameObject.GetComponent<ICollideable>();
		if (other == null) {
			return;
		}
		other.CollidedWithCharacter(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		float h = inputManager.Horizontal;
		float v = inputManager.Vertical;
		float turnSpeed = TurnSpeed;
		if (controller.isGrounded) {
			if (v == 0) {// Not running forward
				moveDirection = new Vector3(0, 0, 0);
			} else {// Running forward
				moveDirection = new Vector3(h, 0, v);
				turnSpeed = TurnSpeed/2;
			}
            
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= Speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = JumpSpeed;

			if(TrampolineJump)
				moveDirection.y = TrampolineBoost;
            
        }
		TrampolineJump = false;
		transform.Rotate(0, h * turnSpeed, 0);
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
	}
}
