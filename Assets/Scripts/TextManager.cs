using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

	public static TextManager instance {get; private set;}
	public Text pointText;
	public Text objectiveText;

	void Awake() {
		if(instance == null) {
			instance = this;
		} else if(instance != this) {
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(this.gameObject);
	}

	public void setPoints(int points) {
		pointText.text = "Puntos: "+points;
	}
	public void setObjective(string name) {
		objectiveText.text = "Objetivo: "+name;
	}

}
