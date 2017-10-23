using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInventoryController : MonoBehaviour {

	public Image[] imgKeys = new Image[5];

	// Use this for initialization
	void Start () {
		for (int i = 0; i <= imgKeys.Length; i++) {
			imgKeys [i].gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DisplayOnInventory (int index){
		if (index == 0 || index == 4 || index == 6 || index == 3) {
			imgKeys [1].gameObject.SetActive (true);
		} else if (index == 1) {
			imgKeys [0].gameObject.SetActive (true);
		} else if (index == 2) {
			imgKeys [2].gameObject.SetActive (true);
		} else if (index == 5) {
			imgKeys [3].gameObject.SetActive (true);
		} else if (index == 7) {
			imgKeys [4].gameObject.SetActive (true);
		}
	}

	public void DeleteOnInventory(int index){
		if (index == 0 || index == 4 || index == 6 || index == 3) {
			imgKeys [1].gameObject.SetActive (false);
		} else if (index == 1) {
			imgKeys [0].gameObject.SetActive (false);
		} else if (index == 2) {
			imgKeys [2].gameObject.SetActive (false);
		} else if (index == 5) {
			imgKeys [3].gameObject.SetActive (false);
		} else if (index == 7) {
			imgKeys [4].gameObject.SetActive (false);
		}
	}
}
