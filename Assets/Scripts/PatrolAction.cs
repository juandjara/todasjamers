using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/Patrol")]
public class PatrolAction : Action {
	public override void Act(StateController controller) {
		Patrol(controller);
	}
	private void Patrol(StateController controller) {
		controller.navMeshAgent.destination = controller.wayPointList[controller.nextWayPoint].position;
		bool distanceThreshold = controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance;

		if(distanceThreshold && !controller.navMeshAgent.pathPending) {
			int nextWaypoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
			controller.nextWayPoint = nextWaypoint;
		} else {
			controller.navMeshAgent.isStopped = false;
			Vector3 velocity = controller.navMeshAgent.desiredVelocity;
			controller.character.Move(velocity, false, false);
		}
	}
}
