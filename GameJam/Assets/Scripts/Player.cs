using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public int playerID = 1;
    public float speed = 10.0f;
    public float gravity = 20.0f;

    private float horDir;
    private float vertDir;
    private Vector3 moveDirection;
    private CharacterController controller;

    private string horizontal;
    private string vertical;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {


        if (playerID == 1)
        {
            horizontal = "Horizontal";
            vertical = "Vertical";
        }
        else
        {
            horizontal = "Horizontal2";
            vertical = "Vertical2";
        }
        horDir = Input.GetAxis(horizontal);
        vertDir = Input.GetAxis(vertical);

        moveDirection = new Vector3(horDir, 0, vertDir);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        // moveDirection.y -= gravity * Time.deltaTime;
         controller.Move(moveDirection * Time.deltaTime);

	
	}
}
