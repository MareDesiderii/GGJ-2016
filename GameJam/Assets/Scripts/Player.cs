using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed = 10.0f;
    public float gravity = 20.0f;

    private float horDir;
    private float vertDir;
    private Vector3 moveDirection;
    private CharacterController controller;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        horDir = Input.GetAxis("Horizontal");
        vertDir = Input.GetAxis("Vertical");

        Debug.Log("Hor: " + horDir);
        Debug.Log("Ver: " + vertDir);
        moveDirection = new Vector3(horDir, 0, vertDir);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        // moveDirection.y -= gravity * Time.deltaTime;
         controller.Move(moveDirection * Time.deltaTime);

	
	}
}
