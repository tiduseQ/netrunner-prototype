using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventInstallHardware : CardEvent {

	public EventInstallHardware(int newCoin, int newClick, costAdditionalDelegate newAdditional) : base(newCoin,newClick,newAdditional) {
		activeCondition.Add(EventCondition.NotInstalled);
	}

	protected override void EventActions(Board.BoardSide side) {
		Board.Obj_Grip.RemoveCard (this.gameObject);
		Board.Obj_Rig_Hardware.AddCard (this.gameObject);
	}
}