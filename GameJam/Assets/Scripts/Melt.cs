﻿using UnityEngine;
using System.Collections;

public class Melt : MonoBehaviour {

	public float speed;


	
	// Update is called once per frame
	void Update (){

		//If the Candle's cubes mesh renderer is enabled, melt the candle
	/*	GameObject cube = transform.GetChild(0).FindChild("Cube").gameObject;
		if (cube.GetComponent<MeshRenderer> ().enabled == true) {*/
		Debug.Log ("Child "+transform.GetChild (0).gameObject);
		Debug.Log ("Grand Child "+transform.GetChild (0).GetChild(0).gameObject.name);

		if (transform.GetChild(0).GetChild(0).gameObject.active){
			Debug.Log ("MELTING!!!");
			Vector3 vt3 = new Vector3 (transform.localScale.x, (transform.localScale.y - (Time.deltaTime * speed)), transform.localScale.z);

			transform.localScale = vt3;

			if (vt3.y <= 0) {
				Debug.Log ("Time to Destroy");
				Debug.Log ("THIS " + this);
				Destroy (this.gameObject);
				AudioSource candle_out = GameObject.Find( "SoundCandleOut" ).GetComponent<AudioSource>();
				candle_out.Play();
                FindObjectOfType<Score>().m_Score--;
			}

		}

	
	}
}
