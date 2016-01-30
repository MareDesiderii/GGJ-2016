using UnityEngine;
using System.Collections;

public class begin : MonoBehaviour {

    public GameObject redCandle;
    public GameObject blueCandle;

    public Quaternion rot;
    private Vector3[] PeaceArray;

    private bool isRedCandle;
    private int candleNum = 0;

	// Use this for initialization
	void Start () {
		//rot = new Quaternion (redCandle.transform.rotation.x, redCandle.transform.rotation.y, redCandle.transform.rotation.z, 0.0);

		//rot = new Quaternion (0.0f, 90.0f, 90.0f, 0.0f);
        //Star();
        SetUpPeace();
		Instantiate(redCandle, PeaceArray[candleNum],   rot);
        isRedCandle = false;
        candleNum++;
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

    public void SetUpPeace()
    {
        PeaceArray = new Vector3[5];
        PeaceArray[0] = new Vector3(0.0f, 1.0f, 4.0f);
        PeaceArray[1] = new Vector3(3.0f, 1.0f, -4.0f);
        PeaceArray[2] = new Vector3(0.0f, 1.0f, -4.0f);
        PeaceArray[3] = new Vector3(-3.0f, 1.0f, -4.0f);
        PeaceArray[4] = new Vector3(0.0f, 1.0f, -1.0f);
    }

    public void SwitchCandles()
    {
        if (isRedCandle)
        {
            Instantiate(redCandle, PeaceArray[candleNum], rot);
            isRedCandle = !isRedCandle;
        }
        else
        {
            Instantiate(blueCandle, PeaceArray[candleNum], rot);
            isRedCandle = !isRedCandle;
        }
        candleNum++;
    }
}
