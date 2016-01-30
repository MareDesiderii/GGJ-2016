using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public int playerID = 1;
    public float speed = 10.0f;
    public float gravity = 20.0f;

    public GameObject otherLight;
    public float maxDist = 1.0f;

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


        if (transform.position.y != 1.0f)
            transform.Translate(new Vector3(0.0f, 1 - transform.position.y, 0.0f));

        horDir = Input.GetAxis(horizontal);
        vertDir = Input.GetAxis(vertical);

        moveDirection = new Vector3(horDir, 0, vertDir);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        // moveDirection.y -= gravity * Time.deltaTime;
         controller.Move(moveDirection * Time.deltaTime);

         if (!CompareDistanceToLight())
             Destroy(gameObject);
	
	}

    bool CompareDistanceToLight()
    {
        float dx = transform.position.x - otherLight.transform.position.x;
        float dy = transform.position.z - otherLight.transform.position.z;

        float distance = Mathf.Sqrt(dx * dx + dy * dy);

        if (distance < maxDist)
            return true;
        else
            return false;
    }
}
