using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventInstallProgram : CardEvent {

	public EventInstallProgram(int newCoin, int newClick, costAdditionalDelegate newAdditional) : base(newCoin,newClick,newAdditional) { }

	protected override void EventActions(Board.BoardSide side) {
		Board.Obj_Grip.RemoveCard (this.gameObject);
		Board.Obj_Rig_Programs.AddCard (this.gameObject);
	}
}