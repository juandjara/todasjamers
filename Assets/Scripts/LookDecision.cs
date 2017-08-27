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
		bool AISeesPlayer = Physics.BoxCast(
			controller.eyes.position,
			new Vector3(controller.enemyStats.lookSphereCastRadius, controller.enemyStats.lookSphereCastRadius, controller.enemyStats.lookSphereCastRadius),
			controller.eyes.forward,
			out hit,
			Quaternion.identity,
			controller.enemyStats.lookRange  
		) && hit.collider.CompareTag("Player");
		
		if(AISeesPlayer) {
			TextManager.instance.setWarning("UN PUG TE HA VISTO");
			controller.chaseTarget = hit.transform;
		} else {
			TextManager.instance.setWarning("");
		}
		return AISeesPlayer;
	}
}
