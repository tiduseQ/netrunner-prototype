using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEvent : Card {

	new public CardTypes type = CardTypes.Event;
	
	public string eventName = "";

	protected virtual void PlayEvent() {}

	protected virtual bool AssessCost() {
		return true;
	}
}
