using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class collectible : MonoBehaviour {

	// Use this for initialization
	void Start () {

		StartCoroutine (Flicker ());
	}
	
	// Update is called once per frame
	void Update () {


	}



	IEnumerator Flicker()
	{
		for (int x=1;x<5;x++) {
			gameObject.GetComponent<Renderer> ().enabled = true;
			yield return new WaitForSeconds (.01f*x);
			gameObject.GetComponent<Renderer> ().enabled = false;
			yield return new WaitForSeconds (.01f);
		}
		gameObject.GetComponent<Renderer> ().enabled = true;

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

				GameObject glow = transform.parent.parent.FindChild("Portal Surface").gameObject;
				glow.transform.Rotate(-20, 0, 0);

				GameObject flame = transform.FindChild ("Flame").gameObject;
				flame.SetActive(true);
	
			}
            //msg palyer for winks
            if (col.name == "BluePlayer")
                col.GetComponent<Player>().SendMessage("WinkFlip");
            if (col.name == "RedPlayer")
                col.GetComponent<Player>().SendMessage("WinkFlip");

        }
	}
}
