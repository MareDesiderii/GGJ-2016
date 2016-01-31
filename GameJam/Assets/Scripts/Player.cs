using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public int playerID = 1;
    public float speed = 10.0f;
    public float gravity = 20.0f;

    public GameObject otherLight;
    public float maxDist = 0.3f;

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

        // clamp our movment to just inside the light
        Vector3 newPos = transform.position + moveDirection;
        Vector3 oldOffset = transform.position - otherLight.transform.position;

        //offset from the center of the otherlight accounting for both players moves
        Vector3 newOffset = (transform.position + moveDirection) - (otherLight.transform.position);
        //clamp our movment to just inside the otherlight

        Vector3 AllowedMove = Vector3.ClampMagnitude(newOffset, maxDist) - oldOffset;
        //pull on the other player if we would be moving outside the light
        //if (IsOutsideLight(moveDirection)) 
        //{
        //   // otherLight.GetComponentInParent<Player>().controller.Move(-moveDirection * Time.deltaTime * 0.3f);
        //}

        controller.Move(AllowedMove * 3 * Time.deltaTime);
    }

    bool IsOutsideLight(Vector3 move)
    {
        float dx = transform.position.x + move.x - otherLight.transform.position.x;
        float dy = transform.position.z + move.z - otherLight.transform.position.z;

        float distance = Mathf.Sqrt(dx * dx + dy * dy);

        if (distance < maxDist)
            return false;
        else
            return true;
    }

    void OnTriggerExit(Collider col)
    {
        if (col.transform == otherLight.transform)
        {
            //otherLight.GetComponentInParent<Player>().controller.Move(-moveDirection * Time.deltaTime);
        }
    }
}
