using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCroquetas : MonoBehaviour {


	public static ManagerCroquetas instance { get; private set; }
	public int puntos;
	public List<Transform> zonasSpawnCroquetas;
	public List<Transform> zonaObjetivos;



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
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
