//Not used!  Probably!

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndButtonControl : MonoBehaviour
{
    public Button[] buttons;
    public int selectedButton = 0;

    private ColorBlock cb;
    private float t = 0;
    private Color purple;
    private bool flicker = false;

    private float elapsedTime = 0.0f;
    private float preventSelectUntil = 1.0f;
    bool slowInput = false;

    // Use this for initialization
    void Start()
    {
        cb = buttons[selectedButton].colors;
        purple = new Color(0.0f, 1.0f, 0.0f);

        elapsedTime += Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {

        elapsedTime += Time.deltaTime;

        float imp = Input.GetAxis("Horizontal");

        if (imp < -0.4f || imp > 0.4f)
        {

            if (!slowInput || elapsedTime > preventSelectUntil)
            {
                Debug.Log("not preventing select ");

                cb.normalColor = Color.white;
                buttons[selectedButton].colors = cb;

                if (imp > 0.4f)
                {
                    selectedButton++;
                }
                else
                {
                    selectedButton--;
                }

                selectedButton = Mathf.Clamp(selectedButton, 0, 2);
                cb = buttons[selectedButton].colors;
                flicker = false;

                preventSelectUntil = elapsedTime + 0.4f;
                slowInput = true;
            }


        }
        else
        {
            slowInput = false;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (selectedButton == 0)
                GetComponent<endgame>().LoadPeace();
            if (selectedButton == 1)
                GetComponent<endgame>().LoadLove();
            if (selectedButton == 2)
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

        buttons[selectedButton].colors = cb;
    }
}
