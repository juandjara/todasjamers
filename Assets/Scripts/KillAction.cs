using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Kill")]
public class KillAction : Action {
	public override void Act(StateController controller) {
		Kill(controller);
	}
	void Kill(StateController controller) {
		
	}
}
