using UnityEngine;
using System.Collections;

public class PulseLight : MonoBehaviour {

 private const float PULSE_RANGE = 1.4f;
 private const float PULSE_SPEED = 0.4f;
  
 private const float PULSE_MINIMUM = 0.75f;
 
 private Light light;
  

	// Use this for initialization
	void Start () {
		light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		light.intensity = PULSE_MINIMUM +
                           Mathf.PingPong(Time.time * PULSE_SPEED, 
                                          PULSE_RANGE - PULSE_MINIMUM);
	}
}
