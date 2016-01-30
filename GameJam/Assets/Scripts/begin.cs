using UnityEngine;
using System.Collections;

public class begin : MonoBehaviour {

    public GameObject redCandle;
    public GameObject blueCandle;

    private Quaternion rot;

	// Use this for initialization
	void Start () {
        rot = new Quaternion(0, 0, 0, 0);
        Star();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void Star()
    {
        Instantiate(redCandle, new Vector3(0.0f, 1.0f, 1.0f), rot);
        Instantiate(blueCandle, new Vector3(-.5f, 1.0f, 0.0f), rot);
        Instantiate(redCandle, new Vector3(-1.0f, 1.0f, 0.0f), rot);
        Instantiate(redCandle, new Vector3(0.5f, 1.0f, 0.0f), rot);
        Instantiate(blueCandle, new Vector3(1.0f, 1.0f, 0.0f), rot);
        Instantiate(blueCandle, new Vector3(-.5f, 1.0f, -.5f), rot);
        Instantiate(redCandle, new Vector3(0.5f, 1.0f, -0.5f), rot);
        Instantiate(blueCandle, new Vector3(-0.5f, 1.0f, -1.0f), rot);
        Instantiate(redCandle, new Vector3(0.5f, 1.0f, -1.0f), rot);

    }
}
