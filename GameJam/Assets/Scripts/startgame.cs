using UnityEngine;
using System.Collections;

public class startgame : MonoBehaviour {

    public selection sel;

    public void LoadPeace()
    {
		FadeBlack screen = GameObject.FindWithTag("StartScreenCanvas").GetComponent<FadeBlack>();
        sel.symbol = 0;
		screen.setSel(sel);
    }
    public void LoadLove()
    {
		FadeBlack screen = GameObject.FindWithTag("StartScreenCanvas").GetComponent<FadeBlack>();
        sel.symbol = 1;
        screen.setSel(sel);
    }
    public void LoadHappy()
    {
		FadeBlack screen = GameObject.FindWithTag("StartScreenCanvas").GetComponent<FadeBlack>();
        sel.symbol = 2;
        screen.setSel(sel);
    }
}
