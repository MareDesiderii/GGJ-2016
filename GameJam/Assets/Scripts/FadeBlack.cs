using UnityEngine;
using System.Collections;

public class FadeBlack : MonoBehaviour {
	private CanvasGroup panel;
	private bool beenClicked = false;
	private selection sel;
	private CanvasGroup tutPanel;
	private float hacktime = 0f;
	private bool beenShown = false;
	private bool doneBeingShown = false;
	
	// Use this for initialization
	void Start () {
		panel = GetComponent<CanvasGroup>();
		tutPanel = panel.transform.parent.FindChild("TutorialText").GetComponent<CanvasGroup>();
	}
	
	// Update is called once per frame
	void Update () {
		if (beenClicked) {
			if (panel.alpha > 0) {
				panel.alpha -= Time.deltaTime/1;
			}
			else {
				if (beenShown == false) {
					if (tutPanel.alpha < 1) {
						tutPanel.alpha += Time.deltaTime/1;
					}
					else {
						beenShown = true;
						StartCoroutine(LoadThing());
					}
				}
				else if (doneBeingShown == true) {
					if (tutPanel.alpha > 0) {
						tutPanel.alpha -= Time.deltaTime/1;
					}
					else {
						DontDestroyOnLoad(sel);
						Application.LoadLevel(1);
					}
				}
			}
		}
	}
    
    IEnumerator LoadThing() {
        yield return new WaitForSeconds(15);
		doneBeingShown = true;
    }
	
	public void setSel(selection insel) {
		sel = insel;
		beenClicked = true;
	}
}
