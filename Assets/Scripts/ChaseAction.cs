﻿using System.Collections;
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
		bool distanceThreshold = controller.navMeshAgent.remainingDistance > controller.navMeshAgent.stoppingDistance;
		if(distanceThreshold) {
			controller.character.Move(velocity, false, false);
		} else {
			controller.character.Move(Vector3.zero, false, false);			
			controller.navMeshAgent.isStopped = true;
		}
	}
}
