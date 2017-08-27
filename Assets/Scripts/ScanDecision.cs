using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Scan")]
public class ScanDecision : Decision {
	public override bool Decide(StateController controller) {
		bool noPlayerInSight = Scan(controller);
		return noPlayerInSight;
	}

	private bool Scan(StateController controller) {
		controller.navMeshAgent.isStopped = true;
		controller.character.Move(Vector3.zero, false, false);
		
		float yRotation = controller.enemyStats.searchingTurnSpeed * Time.deltaTime;
		controller.transform.Rotate(0, yRotation, 0);
		return controller.CheckIfCountdownElapsed(controller.enemyStats.searchDuration);
	}
}
