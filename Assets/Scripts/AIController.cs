using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateController))]
public class AIController : MonoBehaviour {
  // the character we are followings
  [HideInInspector] public Transform target;
  // the handler for the AI States
  [HideInInspector] public StateController stateController;
  // the list of positions that AI goes when patrolling
  [HideInInspector] public List<Transform> waypointLists;
  // the tag used for finding the points this AI can patrol
  public string waypointListTag;

  private void Start() {
    stateController = GetComponent<StateController>();
    GameObject[] pointsWithTag = GameObject.FindGameObjectsWithTag(waypointListTag);
    foreach(GameObject point in pointsWithTag) {
      waypointLists.Add(point.transform);
    }
    stateController.SetupAI(true, waypointLists);
  }
}