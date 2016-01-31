﻿using UnityEngine;
using System.Collections;


public class collectible : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log(col.name);
            Debug.Log(name);
            //Destroy(gameObject);
            if ((col.name == "RedPlayer" && name == "Candle Red")
             || (col.name == "BluePlayer" && name == "Candle Blue"))
            {
                begin beg = FindObjectOfType<begin>();
                beg.SendMessage("SwitchCandles");
                GetComponent<CapsuleCollider>().enabled = false;
				AudioSource lit_sound;
				if ( col.name == "RedPlayer" )
				{
					lit_sound = GameObject.Find( 
						"SoundSuccess1" ).GetComponent<AudioSource>();
				}
				else
				{
					lit_sound = GameObject.Find( 
						"SoundSuccess2" ).GetComponent<AudioSource>();
				}

				lit_sound.Play( );
								
				//AudioSource candle_out = GameObject.Find( "CandleOut" ).GetComponent<AudioSource>();
				//candle_out.Play();

				GameObject cube = transform.FindChild ("Cube").gameObject;
			

				Debug.Log ("CUBE " + cube);
				cube.GetComponent<MeshRenderer> ().enabled = true;

            }

        }
    }
}
