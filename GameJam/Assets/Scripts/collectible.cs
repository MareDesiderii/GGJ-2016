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
            if ((col.name == "RedPlayer" && name == "RedCube(Clone)")
             || (col.name == "BluePlayer" && name == "BlueCube(Clone)"))
            {
                begin beg = FindObjectOfType<begin>();
                beg.SendMessage("SwitchCandles");
                GetComponent<BoxCollider>().isTrigger = false;
            }

        }
    }
}
