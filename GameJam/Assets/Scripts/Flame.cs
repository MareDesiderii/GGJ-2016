using UnityEngine;
using System.Collections;

public class Flame : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {


		transform.Rotate (new Vector3 (90, 0, 0) * Time.deltaTime);
	}

}