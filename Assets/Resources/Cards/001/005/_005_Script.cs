using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _005_Script : Card {

	void Start () {
		side = CardSide.Runner;
		faction = CardFaction.Anarch;
		type = CardTypes.Hardware;
		subtype = new CardSubtypes[1];
		subtype [0] = CardSubtypes.Chip;
		title = "Cyberfeeder";
		text = "";
		flavorText = "";
		state = CardStates.NotInstalled;
		currentPosition = BoardAreas.Stack;
		id = Board.AssignId ();

		CardEvent newEvent;

		newEvent = new EventInstallHardware (2,1,null);
		AddCardAction (newEvent);

		newEvent = new EventAddCredit
	}


}
