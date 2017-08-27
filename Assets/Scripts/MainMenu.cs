using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {




	public static MainMenu instance { get; private set; }


	void Awake() {
		if(instance == null) {
			instance = this;
		} else if(instance != this) {
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(this.gameObject);
	}

	
	// Update is called once per frame
	void Update () {
		
	}

	public void IniciaJuego(){
		SceneManager.LoadScene(1);
		

	}


}
