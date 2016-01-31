using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndScript : MonoBehaviour {



	// Use this for initialization
	void Start () {
        Score sco = FindObjectOfType<Score>();
        selection sel = FindObjectOfType<selection>();

        int div = 0;
        if (sel.symbol == 0)
            div = 5;
        if (sel.symbol == 1)
            div = 20;
        if (sel.symbol == 2)
            div = 23;

        int score = sco.m_Score;
        GetComponent<Text>().text = "Score: " + score.ToString() + "\\" + div.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
