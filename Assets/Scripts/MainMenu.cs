using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {




	public static MainMenu instance { get; private set; }

	public GameObject pug;

	void Awake() {
		if(instance == null) {
			instance = this;
		} else if(instance != this) {
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(this.gameObject);
	}
	// Use this for initialization
	void Start () {

		pug.GetComponent<Animation>().Play();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void IniciaJuego(){
		SceneManager.LoadScene(1);
		

	}


}
