using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	Animation playerAnim;

	// Use this for initialization
	void Start () {
		playerAnim = GameObject.Find ("Player").GetComponent<Animation> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		playerAnim.Play ("Wait");	
		
	}

	public void PlayBtn(){
		SceneManager.LoadScene (1);
	}

	public void QuitBtn(){
		Application.Quit ();
	}
}
