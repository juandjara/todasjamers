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
		RaycastHit hit;
		Vector3 lookRayDirection = controller.eyes.forward.normalized * controller.enemyStats.attackRange;
		Debug.DrawRay(controller.eyes.position, lookRayDirection, Color.red);
		bool AISeesPlayer = Physics.SphereCast(
			controller.eyes.position,
			controller.enemyStats.lookSphereCastRadius,
			controller.eyes.forward,
			out hit,
			controller.enemyStats.attackRange
		) && hit.collider.CompareTag("Player");
		
		if(AISeesPlayer) {
			bool AICanKill = controller.CheckIfCountdownElapsed(controller.enemyStats.attackRate);
			if(AICanKill) {
				// kill player if it has no extra points
			}
		}
	}
}
