using UnityEngine;
using System.Collections;

public class PulseLight : MonoBehaviour {

	public float PULSE_RANGE = 1.4f;
	public float PULSE_SPEED = 0.4f;
	public float PULSE_MINIMUM = 0.75f;
 
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
