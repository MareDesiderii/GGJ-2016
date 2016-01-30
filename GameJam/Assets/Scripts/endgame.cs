using UnityEngine;
using System.Collections;

public class endgame : MonoBehaviour {
    private selection sel;

    public void LoadPeace()
    {
        sel = FindObjectOfType<selection>();
        sel.symbol = 1;
        DontDestroyOnLoad(sel);
        Application.LoadLevel(1);
    }
    public void LoadLove()
    {
        sel = FindObjectOfType<selection>();
        sel.symbol = 2;
        DontDestroyOnLoad(sel);
        Application.LoadLevel(1);
    }
}
