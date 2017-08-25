using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Look")]
public class LookDecision : Decision {
	public override bool Decide(StateController controller) {
		bool targetIsVisible = Look(controller);
		return targetIsVisible;
	}
	private bool Look(StateController controller) {
		RaycastHit hit;
		Vector3 lookRayDirection = controller.eyes.forward.normalized * controller.enemyStats.lookRange;
		Debug.DrawRay(controller.eyes.position, lookRayDirection, Color.green);
		bool AISeesPlayer = Physics.SphereCast(
			controller.eyes.position,
			controller.enemyStats.lookSphereCastRadius,
			controller.eyes.forward,
			out hit,
			controller.enemyStats.lookRange  
		) && hit.collider.CompareTag("Player");
		
		if(AISeesPlayer) {
			controller.chaseTarget = hit.transform;
		}
		return AISeesPlayer;
	}
}
