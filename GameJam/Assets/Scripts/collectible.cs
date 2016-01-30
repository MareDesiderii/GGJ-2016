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
                GetComponent<CapsuleCollider>().isTrigger = false;

					GameObject cube = transform.FindChild ("Cube").gameObject;
			

					Debug.Log ("CUBE " + cube);
				cube.GetComponent<MeshRenderer> ().enabled = true;

            }

        }
    }
}
