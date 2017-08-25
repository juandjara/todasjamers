using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/State")]
public class State : ScriptableObject {
	
	public Action[] actions;
	public Transition[] transitions;
	public Color sceneGizmoColor = Color.grey;

	public void UpdateState(StateController controller) {
		DoActions(controller);
		CheckTransitions(controller);
	}
	private void DoActions(StateController controller) {
		foreach(Action action in actions) {
			action.Act(controller);
		}
	}
	private void CheckTransitions(StateController controller) {
		foreach(Transition transition in transitions) {
			bool decisionSuccess = transition.decision.Decide(controller);
			if(decisionSuccess) {
				controller.TransitionToState(transition.trueState);
			} else {
				controller.TransitionToState(transition.falseState);
			}
		}
	}
}
