using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventInstallResource : CardEvent {

	public EventInstallResource(int newCoin, int newClick, costAdditionalDelegate newAdditional, string newEventName) : base(newCoin,newClick,newAdditional,newEventName) { }

	protected override void EventActions(Board.BoardSide side) {
		Board.Obj_Grip.RemoveCard (source.gameObject);
		Board.Obj_Rig_Resources.AddCard (source.gameObject);
	}
}