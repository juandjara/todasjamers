using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour {

	public State currentState;
	public EnemyStats enemyStats;
	public Transform eyes;
	public State remainState;

	[HideInInspector] public NavMeshAgent navMeshAgent;
	// TODO Create PugAttack script and assign it here
	//[HideInInspector] public Complete.TankShooting tankShooting;
	[HideInInspector] public List<Transform> wayPointList;
	[HideInInspector] public int nextWayPoint;
	[HideInInspector] public Transform chaseTarget;
	[HideInInspector] public float stateTimeElapsed;

	private bool aiActive;

	void Awake() {
		// TODO get PugAttack instance from component
		//tankShooting = GetComponent<Complete.TankShooting> ();
		navMeshAgent = GetComponent<NavMeshAgent> ();
	}

	void Update() {
		if(!aiActive) {
			return;
		}
		currentState.UpdateState(this);
	}

	public void SetupAI(bool aiActivationFromTankManager, List<Transform> wayPointsFromTankManager) {
		wayPointList = wayPointsFromTankManager;
		aiActive = aiActivationFromTankManager;
		navMeshAgent.enabled = aiActive ? true : false;
	}

	void OnDrawGizmos() {
		if(currentState == null || eyes == null) {
			return;
		}
		Gizmos.color = currentState.sceneGizmoColor;
		Gizmos.DrawWireSphere(eyes.position, enemyStats.lookSphereCastRadius);
	}

	public void TransitionToState(State nextState) {
		if(nextState != remainState) {
			currentState = nextState;
		}
	}

	public bool CheckIfCountdownElapsed(float duration) {
		stateTimeElapsed += Time.deltaTime;
		return stateTimeElapsed > duration;
	}

	private void OnExitState() {
		stateTimeElapsed = 0;
	}
}
