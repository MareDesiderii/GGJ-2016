using UnityEngine;
using System.Collections;

public class LightInvert : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject parent = this.transform.parent.gameObject;
		Vector3 tr = new Vector3 (parent.transform.position.x*-1,1.0f, parent.transform.position.z*-1);
		transform.position = tr;
	}
}
