using UnityEngine;
using System.Collections;

public class Melt : MonoBehaviour {

	public float speed;


	
	// Update is called once per frame
	void Update (){





		Vector3 vt3 = new Vector3 (transform.localScale.x,(transform.localScale.y- (Time.deltaTime * speed)), transform.localScale.z);

		transform.localScale = vt3;



	
	}
}
