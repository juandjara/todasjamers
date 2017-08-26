using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ManagerCroquetas : MonoBehaviour {


	public static ManagerCroquetas instance { get; private set; }
	public int puntos;
	public List<Transform> zonasSpawnCroquetas;
	public List<Transform> zonaObjetivos;

	public GameObject croquetaPrefab;

	private Random rand;



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
		rand = new Random();

		//Iniciamos spawns de croquetas
		foreach(GameObject item in GameObject.FindGameObjectsWithTag("spawnPoint")){
			zonasSpawnCroquetas.Add(item.transform);

		}

		spawnCroqueta();



	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void spawnCroqueta(){
		//spawneamos croqueta en sitio al azar de la lista:

		Instantiate(croquetaPrefab, zonasSpawnCroquetas[ Random.Range(0,zonasSpawnCroquetas.Count)]);		

	}
}
