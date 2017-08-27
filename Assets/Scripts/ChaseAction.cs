using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Chase")]
public class ChaseAction : Action {
	public override void Act(StateController controller) {
		Chase(controller);
	}
	private void Chase(StateController controller) {
		controller.navMeshAgent.destination = controller.chaseTarget.position;
		Vector3 velocity = controller.navMeshAgent.desiredVelocity;
		controller.character.Move(velocity, false, false);
	}
}
