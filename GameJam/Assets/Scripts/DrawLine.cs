using UnityEngine;
using System.Collections;

public class DrawLine : MonoBehaviour {
	public Texture2D texture;
	public GameObject redPlayer;
	public GameObject bluePlayer;
	public Camera camera;
	
	// Use this for initialization
	void Start () {
		redPlayer = GameObject.Find("RedPlayer");
		bluePlayer = GameObject.Find("BluePlayer");
		camera = GameObject.Find("Main Camera").GetComponent<Camera>();
		//Vector3 bluePixelPos = camera.WorldToScreenPoint(bluePlayer.transform.position);
		//Vector3 redPixelPos = camera.WorldToScreenPoint(redPlayer.transform.position);
		//Debug.Log(redPixelPos);
		//Debug.Log(bluePixelPos);
		
	    texture = new Texture2D(256, 256);
        GetComponent<Renderer>().material.mainTexture = texture;

        for (int y = 0; y < texture.height; y++) {
            for (int x = 0; x < texture.width; x++) {
                Color color = ((x & y) != 0 ? Color.white : Color.gray);
				color = Color.black;
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 bluePixelPos = camera.WorldToScreenPoint(bluePlayer.transform.position);
		texture.SetPixel(System.Convert.ToInt32(bluePixelPos.x), System.Convert.ToInt32(bluePixelPos.y), Color.blue);
		texture.Apply();
	}
}