using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _001_001_005_Script : Card {

	void Start() {
		CardEvent newEvent;

		newEvent = new EventInstallHardware (2,1,null,"Install this card.");
		AddCardAction (newEvent);

		newEvent = new EventAddTokenToCard (CardToken.Credit, 2, true, this, this, "Add 2 Credit tokens");
		AddCardAction (newEvent);

		newEvent = null;
	}
}
