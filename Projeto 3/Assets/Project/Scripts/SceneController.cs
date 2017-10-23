using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour {

	public GameObject pauseTxt;
	public GameObject pausePanel;
	public GameObject gameoverPanel;
	public GameObject instructions;
	public GameObject inventoryPanel;

	public Text timer;
	public Text finalTimer;

	public Light directionalLight;

	float timePast = 00f;
	float minutes;
	float seconds;

	void Start () {
		pausePanel.SetActive (false);
		gameoverPanel.SetActive (false);

		directionalLight.enabled = false;
	}

	void Update () {
		timePast += Time.deltaTime;

		if (timePast > 0) {
			minutes = Mathf.Floor (timePast / 60);
			seconds = Mathf.Floor (timePast % 60);
			timer.text = minutes.ToString ("00") + ":" + seconds.ToString ("00");
		}
		if (Input.GetKeyDown (KeyCode.P)) {
			Time.timeScale = 0;
			pauseTxt.SetActive (false);
			pausePanel.SetActive (true);
		}

		if (Input.GetKeyDown (KeyCode.Q)) {
			if (!directionalLight.enabled) {
				directionalLight.enabled = true;
			} else if (directionalLight.enabled) {
				directionalLight.enabled = false;
			}
		}
	}

	public void ResumeGame() {
		pausePanel.SetActive (false);
		pauseTxt.SetActive (true);
		Time.timeScale = 1;
	}

	public void GameOver(){
		Time.timeScale = 0;
		timer.gameObject.SetActive (false);
		instructions.gameObject.SetActive (false);
		gameoverPanel.SetActive (true);
		inventoryPanel.SetActive (false);
		finalTimer.text = timer.text;
	}

	public void QuitGame(){
		Application.Quit ();
	}
}
