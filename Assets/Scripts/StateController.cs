using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ThirdPersonCharacter))]
[RequireComponent(typeof(NavMeshAgent))]
public class StateController : MonoBehaviour {

	public State currentState;
	public EnemyStats enemyStats;
	public Transform eyes;
	public State remainState;

		//[HideInInspector] public PugAttack pugAttack;
	[HideInInspector] public List<Transform> wayPointList;
	[HideInInspector] public int nextWayPoint;
	[HideInInspector] public Transform chaseTarget;
	[HideInInspector] public float stateTimeElapsed;

	// the navmesh agent required for the path finding
  [HideInInspector] public NavMeshAgent navMeshAgent { get; private set; }
  // the character we are controlling, responsible for movement
  [HideInInspector] public ThirdPersonCharacter character { get; private set; }
  
	private bool aiActive;

	void Awake() {
		// TODO get PugAttack instance from component
		//tankShooting = GetComponent<PugAttack> ();
		navMeshAgent = GetComponent<NavMeshAgent> ();
		navMeshAgent.updateRotation = false;
    navMeshAgent.updatePosition = true;
		character = GetComponent<ThirdPersonCharacter>();
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

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.CompareTag("Player")) {
			SceneManager.LoadScene("gameover");
		}
	}
}
