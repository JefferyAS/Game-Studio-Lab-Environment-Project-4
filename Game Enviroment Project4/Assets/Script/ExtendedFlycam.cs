using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendedFlycam : MonoBehaviour
{
	/*
	EXTENDED FLYCAM
		Desi Quintans (CowfaceGames.com), 17 August 2012.
		Based on FlyThrough.js by Slin (http://wiki.unity3d.com/index.php/FlyThrough), 17 May 2011.
 
	LICENSE
		Free as in speech, and free as in beer.
 
	FEATURES
		WASD/Arrows:    Movement
		          Q:    Climb
		          E:    Drop
                      Shift:    Move faster
                    Control:    Move slower
                        End:    Toggle cursor locking to screen (you can also press Ctrl+P to toggle play mode on and off).
	*/
	public GameObject camera;
	public Rigidbody rigidbody;

	public float cameraSensitivity = 90;
	public float climbSpeed = 4;
	public float normalMoveSpeed = 10;
	public float slowMoveFactor = 0.25f;
	public float fastMoveFactor = 3;

	private float camRotationX = 0.0f;
	private float camRotationY = 0.0f;
	private float shipRotationX = 0.0f;
	private float shipRotationY = 0.0f;
	private Vector3 startRot;

	public float spaceshipTunringSpeed;

	public AudioSource aceAudio;
	public AudioSource deceAudio;

	void Start()
	{
		Screen.lockCursor = true;
		startRot = camera.transform.localEulerAngles;
	}

	void Update()
	{
		camRotationX += Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
		camRotationY += Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
		camRotationY = Mathf.Clamp(camRotationY, -30, 30);
		camRotationX = Mathf.Clamp(camRotationX, -20, 20);
		float turning = spaceshipTunringSpeed * Time.deltaTime;
		if (camRotationY > 0 && camRotationY > turning)
		{
			camRotationY -= turning;
			shipRotationY += turning;
		}
		else if (camRotationY < 0 && Mathf.Abs(camRotationY) > turning)
		{
			camRotationY += turning;
			shipRotationY -= turning;
		}
		else if (Mathf.Abs(camRotationY) < turning) {
			shipRotationY += camRotationY;
			camRotationY = 0;
		}

		if (camRotationX > 0 && camRotationX > turning)
		{
			camRotationX -= turning;
			shipRotationX += turning;
		}
		else if (camRotationX < 0 && Mathf.Abs(camRotationX) > turning)
		{
			camRotationX += turning;
			shipRotationX -= turning;
		}
		else if (Mathf.Abs(camRotationX) < turning)
		{
			shipRotationX += camRotationX;
			camRotationX = 0;
		}


		camera.transform.localRotation = Quaternion.AngleAxis(camRotationX-startRot.y, Vector3.up);
		camera.transform.localRotation *= Quaternion.AngleAxis(camRotationY-startRot.x, Vector3.left);

		transform.localRotation = Quaternion.AngleAxis(shipRotationX, Vector3.up);
		transform.localRotation *= Quaternion.AngleAxis(shipRotationY, Vector3.left);


		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
		{
			if (!aceAudio.isPlaying) {
				aceAudio.Play();
			}
			rigidbody.velocity=(transform.forward * (normalMoveSpeed * fastMoveFactor) * Input.GetAxis("Vertical") * Time.deltaTime);
			rigidbody.velocity += transform.right * (normalMoveSpeed * fastMoveFactor) * Input.GetAxis("Horizontal") * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
		{
			rigidbody.velocity = (transform.forward * (normalMoveSpeed * slowMoveFactor) * Input.GetAxis("Vertical") * Time.deltaTime);
			rigidbody.velocity += transform.right * (normalMoveSpeed * slowMoveFactor) * Input.GetAxis("Horizontal") * Time.deltaTime;
		}
		else
		{
			rigidbody.velocity = (transform.forward * normalMoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
			rigidbody.velocity += transform.right * normalMoveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
		}


		if (Input.GetKey(KeyCode.Q)) { transform.position += transform.up * climbSpeed * Time.deltaTime; }
		if (Input.GetKey(KeyCode.E)) { transform.position -= transform.up * climbSpeed * Time.deltaTime; }

		if (Input.GetKeyDown(KeyCode.End))
		{
			Screen.lockCursor = (Screen.lockCursor == false) ? true : false;
		}
	}
}
