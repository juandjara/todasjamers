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
		Vector3 lookRayOrigin = controller.eyes.position;
		lookRayOrigin.y -= 1;
		Debug.DrawRay(lookRayOrigin, lookRayDirection, Color.red);
		bool AISeesPlayer = Physics.SphereCast(
			controller.eyes.position,
			controller.enemyStats.lookSphereCastRadius,
			controller.eyes.forward,
			out hit,
			controller.enemyStats.attackRange
		) && hit.collider.CompareTag("Player");
		
		if(AISeesPlayer) {
			bool AICanKill = controller.CheckIfCountdownElapsed(controller.enemyStats.attackRate);
			TextManager.instance.setWarning("Te han dao");			
			if(AICanKill) {
				// kill player if it has no extra points
				//TextManager.instance.waitAndClearWarning(3f);
			}
		}
	}
}
