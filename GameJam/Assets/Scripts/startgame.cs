using UnityEngine;
using System.Collections;

public class startgame : MonoBehaviour {

    public selection sel;

    public void LoadPeace()
    {
        sel.symbol = 0;
        DontDestroyOnLoad(sel);
        Application.LoadLevel(1);
    }
    public void LoadLove()
    {
        sel.symbol = 1;
        DontDestroyOnLoad(sel);
        Application.LoadLevel(1);
    }
    public void LoadHappy()
    {
        sel.symbol = 2;
        DontDestroyOnLoad(sel);
        Application.LoadLevel(1);
    }
}
