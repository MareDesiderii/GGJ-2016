using UnityEngine;
using System.Collections;

public class collectible : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        bool b = Input.GetButton("Horizontal");
        float f = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Debug.Log(b.ToString());
        Debug.Log(f.ToString());

	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
