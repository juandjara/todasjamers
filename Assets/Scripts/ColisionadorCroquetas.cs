using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ColisionadorCroquetas : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// OnTriggerEnter is called when the Collider other enters the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("croquetas")){
			//Eliminamos croqueta
			Destroy(other.gameObject);
			//Sumamos puntos
			ManagerCroquetas.instance.puntos ++;
			//creamos otra croqueta
			ManagerCroquetas.instance.spawnCroqueta();

		}
		
	}


}
