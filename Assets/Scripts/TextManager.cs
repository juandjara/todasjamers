using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

	public static TextManager instance {get; private set;}
	public Text pointText;
	public Text objectiveText;
	public Text warningText;

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
	public void setWarning(string warning) {
		warningText.text = warning;
	}

	public void waitAndClearWarning(float seconds) {
		StartCoroutine(_waitAndClearWarning(seconds));
	}

	private IEnumerator _waitAndClearWarning(float seconds) {
		yield return new WaitForSeconds(seconds);
		warningText.text = "";
	}

}
