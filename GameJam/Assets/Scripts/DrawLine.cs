using UnityEngine;
using System.Collections;

public class DrawLine : MonoBehaviour {
	public Texture2D texture;
	public GameObject redPlayer;
	public GameObject bluePlayer;
	public Camera camera;
	public Color blue;
	public Color red;
	
	// Use this for initialization
	void Start () {
		redPlayer = GameObject.Find("Red Trail");
		bluePlayer = GameObject.Find("Blue Trail");
		camera = GameObject.Find("Main Camera").GetComponent<Camera>();
		//Vector3 bluePixelPos = camera.WorldToScreenPoint(bluePlayer.transform.position);
		//Vector3 redPixelPos = camera.WorldToScreenPoint(redPlayer.transform.position);
		//Debug.Log(redPixelPos);
		//Debug.Log(bluePixelPos);
		
	    texture = new Texture2D(camera.pixelWidth, camera.pixelHeight);
        GetComponent<Renderer>().material.mainTexture = texture;

		Color c = Color.black;
		c.a = 0;
        for (int y = 0; y < texture.height; y++) {
            for (int x = 0; x < texture.width; x++) {
                //Color color = ((x & y) != 0 ? Color.white : Color.gray);
                texture.SetPixel(x, y, c);
            }
        }
        texture.Apply();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 bluePixelPos = camera.WorldToScreenPoint(bluePlayer.transform.position);
		Vector3 redPixelPos = camera.WorldToScreenPoint(redPlayer.transform.position);
		//Debug.Log(bluePixelPos.x);
		//Debug.Log(bluePixelPos.y);
		texture.SetPixel(System.Convert.ToInt32(bluePixelPos.x), System.Convert.ToInt32(bluePixelPos.y), Color.blue);
		texture.SetPixel(System.Convert.ToInt32(redPixelPos.x), System.Convert.ToInt32(redPixelPos.y), Color.red);
		texture.Apply();
	}
}