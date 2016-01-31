using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartButtonControl : MonoBehaviour {

    public Button[] buttons;
    public int selectedButton = 0;

    private ColorBlock cb;
    private float t = 0;
    private Color purple;
    private bool flicker = false;
	// Use this for initialization
	void Start () {
        cb = buttons[selectedButton].colors;
        purple = new Color(0.0f, 1.0f, 0.0f);
	}
	
	// Update is called once per frame
    void Update()
    {
        float imp = Input.GetAxis("Horizontal");
        if (imp > 0.4f)
        {
            cb.normalColor = Color.white;
            buttons[selectedButton].colors = cb;
            selectedButton++;
            selectedButton = Mathf.Clamp(selectedButton, 0, 2);
            cb = buttons[selectedButton].colors;
            flicker = false;
        }
        if (imp < -0.4f)
        {
            cb.normalColor = Color.white;
            buttons[selectedButton].colors = cb;
            selectedButton--;
            selectedButton = Mathf.Clamp(selectedButton, 0, 2);
            cb = buttons[selectedButton].colors;
            flicker = false;
        }
        if(Input.GetButtonDown("Fire1"))
        {
            if(selectedButton == 0)
                GetComponent<startgame>().LoadPeace();
            if (selectedButton == 1)
                GetComponent<startgame>().LoadLove();
            if (selectedButton == 2)
                GetComponent<startgame>().LoadHappy();
            
        }

        if (cb.normalColor.g < 0.3f)
            flicker = true;
        if (cb.normalColor.g > 0.9f)
            flicker = false;
        if (flicker)
            cb.normalColor += purple * Time.deltaTime;
        else
            cb.normalColor -= purple * Time.deltaTime;

        buttons[selectedButton].colors = cb;
    }
}
