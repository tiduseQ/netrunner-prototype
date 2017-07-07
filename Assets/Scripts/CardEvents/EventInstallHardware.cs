using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventInstallHardware : CardEvent {

	public EventInstallHardware(int newCoin, int newClick, costAdditionalDelegate newAdditional, string newEventName) : base(newCoin,newClick,newAdditional,newEventName) {
		activeCondition.Add (EventCondition.NotInstalled);
	}

	protected override void EventActions(Board.BoardSide side) {
		Board.Obj_Grip.RemoveCard(source.gameObject);
		Board.Obj_Rig_Hardware.AddCard (source.gameObject);
	}
}