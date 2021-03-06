﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class begin : MonoBehaviour {

    public GameObject redCandle;
    public GameObject blueCandle;

    public Component peaceCom;
    public Component loveCom;
    public Component happyCom;

    private SpriteRenderer endImage;

    public Quaternion rot;
    public int symbol = 0; // 0 = peace sign, 1 = heart, 2 = happy
    private Vector3[] PeaceArray;
    private Vector3[] HeartArray;
    private Vector3[] HappyArray;

    private bool isRedCandle;
    private int candleNum = 0;
    private int maxCandleNum = 0;
	private int spawnedCandleNum = 1;

    public float peaceSpeed = 0.02f;
    public float heartSpeed = 0.01f;
    public float happySpeed = 0.01f;

	private int maxCandlesToSpawn = 1;

    private bool endPicScale = false;

    private Score score;

	private float waitTimeToNextScreen=2.0f;
	private float timeToNextDecreaseVol=0; //reset in Finish()
	private float curAudioGoal = 0; // reset in Finish()
	private float audioDecreaseAmount=0;
	private float elapsedTimeToNextScreen=0;


	// Use this for initialization
	void Start () {
        //rot = new Quaternion (redCandle.transform.rotation.x, redCandle.transform.rotation.y, redCandle.transform.rotation.z, 0.0);

        //rot = new Quaternion (0.0f, 90.0f, 90.0f, 0.0f);

        //GetComponent<SpriteRenderer>().sprite = WinSpritesArray[2];

        //Star();
        score = FindObjectOfType<Score>();
        selection sel = new selection();
        if (FindObjectOfType<selection>() != null)
        {
            sel = FindObjectOfType<selection>();
            symbol = sel.symbol;
        }
        else
        {
            Debug.Log("Starting from main, wont go to end scene");
            // VVVV this is not workign good
            //GameObject s = GameObject.Instantiate(Resources.Load("Objects/selection", typeof(GameObject))) as GameObject;// (GameObject)Resources.Load("Assets/Objects/selection", typeof(GameObject));
            //symbol = s.GetComponent<selection>().symbol;
            //symbol = sel.symbol;
        }
        if (symbol == 0)
        {
            SetUpPeace();
            redCandle.transform.FindChild("NewRedCandleHolderInner").GetComponent<Melt>().speed = peaceSpeed;
            blueCandle.transform.FindChild("NewBlueCandleHolderInner").GetComponent<Melt>().speed = peaceSpeed;
            Instantiate(redCandle, PeaceArray[candleNum], rot);
            maxCandleNum = 13;
			spawnedCandleNum = 1;
			maxCandlesToSpawn = 2;
        }
        if (symbol == 1)
        {
            SetUpHeart();
            redCandle.transform.FindChild("NewRedCandleHolderInner").GetComponent<Melt>().speed = heartSpeed;
            blueCandle.transform.FindChild("NewBlueCandleHolderInner").GetComponent<Melt>().speed = heartSpeed;
            Instantiate(redCandle, HeartArray[candleNum], rot);
            maxCandleNum = 20;
			spawnedCandleNum = 1;
			maxCandlesToSpawn = 3;
        }
        if (symbol == 2)
        {
            SetUpHappy();
            redCandle.transform.FindChild("NewRedCandleHolderInner").GetComponent<Melt>().speed = happySpeed;
            blueCandle.transform.FindChild("NewBlueCandleHolderInner").GetComponent<Melt>().speed = happySpeed;
            Instantiate(redCandle, HappyArray[candleNum], rot);
            maxCandleNum = 23;
			spawnedCandleNum = 1;
			maxCandlesToSpawn = 4;
        }

	}
	
	// Update is called once per frame
	void Update () {
        //win fx
        if (endPicScale == true)
        {
			endImage.color += new Color(0,0,0,Time.deltaTime/3.0f);
            
			elapsedTimeToNextScreen += Time.deltaTime;
			if ( elapsedTimeToNextScreen > curAudioGoal )
			{
				curAudioGoal += timeToNextDecreaseVol;		

				AudioSource music = GameObject.Find( 
					"CandleMusic" ).GetComponent<AudioSource>();
				music.volume -= audioDecreaseAmount;
				
			}
        }
	}

    public void SetUpPeace()
    {
        PeaceArray = new Vector3[13];
        PeaceArray[0] = new Vector3(0.0f, 1.0f, 4.0f);
        PeaceArray[1] = new Vector3(3.0f, 1.0f, -3.5f);
        PeaceArray[2] = new Vector3(0.0f, 1.0f, -4.0f);
        PeaceArray[3] = new Vector3(-3.0f, 1.0f, -3.5f);
        PeaceArray[4] = new Vector3(0.0f, 1.0f, -1.0f);
        PeaceArray[5] = new Vector3(-4.0f, 1.0f, 0.0f);
        PeaceArray[6] = new Vector3(4.0f, 1.0f, 0.0f);
        PeaceArray[7] = new Vector3(3.5f, 1.0f, 2f);
        PeaceArray[8] = new Vector3(-3.5f, 1.0f, 2f);
        PeaceArray[9] = new Vector3(3.5f, 1.0f, -2f);
        PeaceArray[10] = new Vector3(-3.5f, 1.0f, -2f);
        PeaceArray[11] = new Vector3(-3.0f, 1.0f, 3.5f);
        PeaceArray[12] = new Vector3(3.0f, 1.0f, 3.5f);
        int n = PeaceArray.Length;
        while (n > 1)
        {
            int k = Random.Range(0, n);
            n--;
            Vector3 temp = PeaceArray[n];
            PeaceArray[n] = PeaceArray[k];
            PeaceArray[k] = temp;
        }
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
        int n = HeartArray.Length;
        while (n > 1)
        {
            int k = Random.Range(0, n);
            n--;
            Vector3 temp = HeartArray[n];
            HeartArray[n] = HeartArray[k];
            HeartArray[k] = temp;
        }
    }

    public void SetUpHappy()
    {
        
        HappyArray = new Vector3[23];
        HappyArray[0] = new Vector3(-.5f, 1.0f, 1.0f);
        HappyArray[1] = new Vector3(.5f, 1.0f, 1.0f);
        HappyArray[2] = new Vector3(-.75f, 1.0f, 2.0f);
        HappyArray[3] = new Vector3(.75f, 1.0f, 2.0f);
        HappyArray[4] = new Vector3(-1.0f, 1.0f, 3.0f);
        HappyArray[5] = new Vector3(1.0f, 1.0f, 3.0f);
        HappyArray[6] = new Vector3(-1.5f, 1.0f, 3.5f);
        HappyArray[7] = new Vector3(1.5f, 1.0f, 3.5f);
        HappyArray[8] = new Vector3(-2.5f, 1.0f, 3.0f);
        HappyArray[9] = new Vector3(2.5f, 1.0f, 3.0f);
        HappyArray[10] = new Vector3(-3.0f, 1.0f, 2.0f);
        HappyArray[11] = new Vector3(3.0f, 1.0f, 2.0f);
        HappyArray[12] = new Vector3(-3.5f, 1.0f, 1.0f);
        HappyArray[13] = new Vector3(3.5f, 1.0f, 1.0f);
        HappyArray[14] = new Vector3(-4.0f, 1.0f, -2.5f);
        HappyArray[15] = new Vector3(4.0f, 1.0f, -2.5f);
        HappyArray[16] = new Vector3(-3.0f, 1.0f, -3.25f);
        HappyArray[17] = new Vector3(3.0f, 1.0f, -3.25f);
        HappyArray[18] = new Vector3(-2.0f, 1.0f, -3.75f);
        HappyArray[19] = new Vector3(2.0f, 1.0f, -3.75f);
        HappyArray[20] = new Vector3(-1.0f, 1.0f, -3.9f);
        HappyArray[21] = new Vector3(1.0f, 1.0f, -3.9f);
        HappyArray[22] = new Vector3(0.0f, 1.0f, -4.0f);
        int n = HappyArray.Length;
        while (n > 1)
        {
            int k = Random.Range(0,n);
            n--;
            Vector3 temp = HappyArray[n];
            HappyArray[n] = HappyArray[k];
            HappyArray[k] = temp;
        }
    }




    public void SwitchCandles()
    {
		candleNum++; //Number of times collision has called this 
		if (candleNum == maxCandleNum) {
			selection sel = FindObjectOfType<selection> ();
			if (sel == null)
				Instantiate (sel);
			DontDestroyOnLoad (sel);
			DontDestroyOnLoad (score);
			StartCoroutine (Finish ());
		} else if (spawnedCandleNum < maxCandleNum) {
			{
				int more = Random.Range (1, maxCandlesToSpawn);
			
				for (int x = 0; x < more; x++) {
					if (spawnedCandleNum < maxCandleNum) {

						if (isRedCandle) {
							if (symbol == 0)
								Instantiate (redCandle, PeaceArray [spawnedCandleNum], rot);
							if (symbol == 1)
								Instantiate (redCandle, HeartArray [spawnedCandleNum], rot);
							if (symbol == 2)
								Instantiate (redCandle, HappyArray [spawnedCandleNum], rot);
							isRedCandle = !isRedCandle;
							score.m_Score++;
							spawnedCandleNum++;
						} else {
							if (symbol == 0)
								Instantiate (blueCandle, PeaceArray [spawnedCandleNum], rot);
							if (symbol == 1)
								Instantiate (blueCandle, HeartArray [spawnedCandleNum], rot);
							if (symbol == 2)
								Instantiate (blueCandle, HappyArray [spawnedCandleNum], rot);
							isRedCandle = !isRedCandle;
							score.m_Score++;
							spawnedCandleNum++;
						}
					}
				}
			}
		}
    }
    IEnumerator Finish()
    {
        //canv.GetComponent<RawImage>().rectTransform.rect.Set(0, 0, 256.0f, 256.0f)
        //endImage.rectTransform.sizeDelta += new Vector2(256.0f, 51.0f);
        //endImage.


        endPicScale = true;
        if (symbol == 0)
            endImage = peaceCom.GetComponent<SpriteRenderer>();
        if (symbol == 1)
            endImage = loveCom.GetComponent<SpriteRenderer>();
        if (symbol == 2)
            endImage = happyCom.GetComponent<SpriteRenderer>();

        //sparks
		GameObject[] candles = GameObject.FindGameObjectsWithTag ("Candle");
		foreach (GameObject ob in candles) {


			ob.transform.FindChild("Flare").gameObject.SetActive (true);
		}
        //win sound
		AudioSource music= GameObject.Find (
			                   "CandleMusic").GetComponent<AudioSource> ();

		curAudioGoal = timeToNextDecreaseVol;
		timeToNextDecreaseVol=waitTimeToNextScreen/20;
		audioDecreaseAmount = music.volume/20;
		music.volume -= audioDecreaseAmount;

		yield return new WaitForSeconds( waitTimeToNextScreen );
        Debug.Log("Finish " + Time.time);
        endPicScale = false;
        Application.LoadLevel(2);
    }
}
