using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndButtonControl : MonoBehaviour
{

    public Button[] buttons;
    public int activeButton = 0;

    private ColorBlock cb;
    private float t = 0;
    private Color purple;
    private bool flicker = false;
    // Use this for initialization
    void Start()
    {
        cb = buttons[activeButton].colors;
        purple = new Color(0.0f, 1.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        float imp = Input.GetAxis("Horizontal");
        if (imp > 0.4f)
        {
            cb.normalColor = Color.white;
            buttons[activeButton].colors = cb;
            activeButton++;
            activeButton = Mathf.Clamp(activeButton, 0, 2);
            cb = buttons[activeButton].colors;
            flicker = false;
        }
        if (imp < -0.4f)
        {
            cb.normalColor = Color.white;
            buttons[activeButton].colors = cb;
            activeButton--;
            activeButton = Mathf.Clamp(activeButton, 0, 2);
            cb = buttons[activeButton].colors;
            flicker = false;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (activeButton == 0)
                GetComponent<endgame>().LoadPeace();
            if (activeButton == 1)
                GetComponent<endgame>().LoadLove();
            if (activeButton == 2)
                GetComponent<endgame>().LoadHappy();

        }

        if (cb.normalColor.g < 0.3f)
            flicker = true;
        if (cb.normalColor.g > 0.9f)
            flicker = false;
        if (flicker)
            cb.normalColor += purple * Time.deltaTime;
        else
            cb.normalColor -= purple * Time.deltaTime;

        buttons[activeButton].colors = cb;
    }
}
