using UnityEngine;
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

				//GameObject glow = transform.parent.FindChild("Portal Surface").gameObject;
			//	glow.transform.Rotate(-20, 0, 0);

				GameObject flame = transform.FindChild ("Flame").gameObject;
				flame.SetActive(true);//GetComponent<ParticleSystem>().enableEmission = true;
				Debug.Log ("FLAME " + flame);

			}

		}
	}
}
