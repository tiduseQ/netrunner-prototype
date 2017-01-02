using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _002_Script : CardEvent {

	public GameObject Obj_Runner;

	protected override void PlayEvent() {
		if (AssessCost ()) {

		}
	}

	protected override bool AssessCost() {
		return true;
	}

}
