using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndScript : MonoBehaviour {



	// Use this for initialization
	void Start () {
        Score sco = FindObjectOfType<Score>();
        int sel = FindObjectOfType<selection>().symbol;

        int div = 0;
        if (sel == 0)
            div = 13;
        if (sel == 1)
            div = 20;
        if (sel == 2)
            div = 23;

        int score = sco.m_Score;
        GetComponent<Text>().text = "Score: " + score.ToString() + "\\" + div.ToString();
        sco.m_Score = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
