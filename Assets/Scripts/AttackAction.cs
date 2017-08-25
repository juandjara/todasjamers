using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Attack")]
public class AttackAction : Action {
	public override void Act(StateController controller) {
		Attack(controller);
	}
	private void Attack(StateController controller) {
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
			bool AICanShoot = controller.CheckIfCountdownElapsed(controller.enemyStats.attackRate);
			if(AICanShoot) {
				// TODO call enemy attack method on controller
			}
		}
	}
}
