﻿using UnityEngine;
using System.Collections;

public class Melt : MonoBehaviour {

	public float speed;


	
	// Update is called once per frame
	void Update (){

	

		if (transform.GetChild(0).GetChild(0).gameObject.active){
			
			Vector3 vt3 = new Vector3 (transform.localScale.x, transform.localScale.y,transform.localScale.z - (Time.deltaTime * speed));

			transform.localScale = vt3;

			if (vt3.z <= 0) {
				GameObject me = this.transform.parent.gameObject;
				Debug.Log ("Time to Destroy");
				Debug.Log ("THIS " + me);
				Destroy (me);
				AudioSource candle_out = GameObject.Find( "SoundCandleOut" ).GetComponent<AudioSource>();
				candle_out.Play();
                FindObjectOfType<Score>().m_Score--;
			}

		}

	
	}
}
