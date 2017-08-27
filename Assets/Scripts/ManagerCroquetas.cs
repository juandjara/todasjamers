using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerCroquetas : MonoBehaviour {

	public static ManagerCroquetas instance { get; private set; }
	public int puntos;
	public List<Transform> zonasSpawnCroquetas;
	public List<Transform> zonaObjetivos;
	public GameObject croquetaPrefab;
	public GameObject objetivoPrefab;

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
		//Iniciamos spawns de croquetas
		foreach(GameObject item in GameObject.FindGameObjectsWithTag("spawnPoint")){
			zonasSpawnCroquetas.Add(item.transform);
		}

		//Iniciamos objetivos de entrega
		foreach(GameObject item in GameObject.FindGameObjectsWithTag("objetivo")){
			zonaObjetivos.Add(item.transform);
		}

		spawnCroqueta();
	}
	
	public void spawnCroqueta(){
		//spawneamos croqueta en sitio al azar de la lista:
		Instantiate(croquetaPrefab, zonasSpawnCroquetas[ Random.Range(0,zonasSpawnCroquetas.Count)]);
		TextManager.instance.setPoints(puntos);
		TextManager.instance.setObjective("conseguir croqueta");
	}

	public void spawnObjetivo(){
		int obj=  Random.Range(0,zonaObjetivos.Count);
		Instantiate(objetivoPrefab, zonaObjetivos[obj]);
		
		TextManager.instance.setPoints(puntos);
		TextManager.instance.setObjective(zonaObjetivos[obj].name);
	}

	public void getObjetivo(){
		Instantiate(croquetaPrefab, zonaObjetivos[ Random.Range(0,zonaObjetivos.Count)]);		
	}
}