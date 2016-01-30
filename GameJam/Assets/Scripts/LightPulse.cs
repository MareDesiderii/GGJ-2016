using UnityEngine;
using System.Collections;

public class LightPulse : MonoBehaviour {
    int variance = 0;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Light light = gameObject.GetComponent<Light>();
        light.range = 10;
	}
}
