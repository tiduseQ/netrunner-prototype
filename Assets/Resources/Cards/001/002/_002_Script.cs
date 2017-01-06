using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _002_Script : CardEvent {

	public GameObject Obj_Rig;
	public GameObject Obj_Hand;
	public GameObject Obj_Deck;

	void Start () {
		Obj_Rig = GameObject.Find ("Rig");
		Obj_Hand = GameObject.Find ("Hand");
		Obj_Deck = GameObject.Find ("Deck");
	}

	protected override void PlayEvent() {
		if (AssessCost ()) {

		}
	}

	protected override bool AssessCost() {
		return true;
	}

}
