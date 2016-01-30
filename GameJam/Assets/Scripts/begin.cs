using UnityEngine;
using System.Collections;

public class begin : MonoBehaviour {

    public GameObject redCandle;
    public GameObject blueCandle;

    public Quaternion rot;
    public int symbol = 2; // 1 = peace sign, 2 = heart
    private Vector3[] PeaceArray;
    private Vector3[] HeartArray;

    private bool isRedCandle;
    private int candleNum = 0;
    private int maxCandleNum = 0;

	// Use this for initialization
	void Start () {

		//rot = new Quaternion (redCandle.transform.rotation.x, redCandle.transform.rotation.y, redCandle.transform.rotation.z, 0.0);

		//rot = new Quaternion (0.0f, 90.0f, 90.0f, 0.0f);
        //Star();

        //symbol = FindObjectOfType<selection>().symbol;
        if (symbol == 1)
        {
            SetUpPeace();
            Instantiate(redCandle, PeaceArray[candleNum], rot);
            maxCandleNum = 5;
        }
        if (symbol == 2)
        {
            SetUpHeart();
            Instantiate(redCandle, HeartArray[candleNum], rot);
            maxCandleNum = 20;
        }
        isRedCandle = false;

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
        PeaceArray = new Vector3[8];
        PeaceArray[0] = new Vector3(0.0f, 1.0f, 4.0f);
        PeaceArray[1] = new Vector3(3.0f, 1.0f, -4.0f);
        PeaceArray[2] = new Vector3(0.0f, 1.0f, -4.0f);
        PeaceArray[3] = new Vector3(-3.0f, 1.0f, -4.0f);
        PeaceArray[4] = new Vector3(0.0f, 1.0f, -1.0f);
    }

    public void SetUpHeart()
    {
        HeartArray = new Vector3[20];
        HeartArray[0] = new Vector3(0.0f, 1.0f, 2.0f);
        HeartArray[1] = new Vector3(1.0f, 1.0f, 2.5f);
        HeartArray[2] = new Vector3(1.5f, 1.0f, 3.0f);
        HeartArray[3] = new Vector3(2.5f, 1.0f, 3.25f);
        HeartArray[4] = new Vector3(3.0f, 1.0f, 3.0f);
        HeartArray[5] = new Vector3(3.5f, 1.0f, 2.0f);
        HeartArray[6] = new Vector3(3.0f, 1.0f, 1.0f);
        HeartArray[7] = new Vector3(2.25f, 1.0f, 0.0f);
        HeartArray[8] = new Vector3(1.0f, 1.0f, -.75f);
        HeartArray[9] = new Vector3(0.0f, 1.0f, -3.0f);
        HeartArray[10] = new Vector3(-1.0f, 1.0f, -.75f);
        HeartArray[11] = new Vector3(-2.25f, 1.0f, 0.0f);
        HeartArray[12] = new Vector3(-3.0f, 1.0f, 1.0f);
        HeartArray[13] = new Vector3(-3.5f, 1.0f, 2.0f);
        HeartArray[14] = new Vector3(-3.0f, 1.0f, 3.0f);
        HeartArray[15] = new Vector3(-2.5f, 1.0f, 3.25f);
        HeartArray[16] = new Vector3(-1.5f, 1.0f, 3.0f);
        HeartArray[17] = new Vector3(-1.0f, 1.0f, 2.5f);

        HeartArray[18] = new Vector3(0.5f, 1.0f, -1.75f);
        HeartArray[19] = new Vector3(-0.5f, 1.0f, -1.75f);
    }

    public void SwitchCandles()
    {
        candleNum++;
        if (candleNum == maxCandleNum)
            Application.LoadLevel(2);
        else
        {
            if (isRedCandle)
            {
                if(symbol == 1)
                    Instantiate(redCandle, PeaceArray[candleNum], rot);
                if(symbol == 2)
                    Instantiate(redCandle, HeartArray[candleNum], rot);
                isRedCandle = !isRedCandle;
            }
            else
            {
                if (symbol == 1)
                    Instantiate(blueCandle, PeaceArray[candleNum], rot);
                if (symbol == 2)
                    Instantiate(blueCandle, HeartArray[candleNum], rot);
                isRedCandle = !isRedCandle;
            }
        }
    }
}
