using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameoverGUI : MonoBehaviour {

	public Text croqueText;

	// Use this for initialization
	void Start () {
		croqueText = GetComponent<Text>();
		float puntos = PlayerPrefs.GetFloat("puntos", 0);
		croqueText.text = "Has rescatado a "+puntos+" croquetas";
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.anyKey) {
			SceneManager.LoadScene("casa - gabo");
		}
	}
}
