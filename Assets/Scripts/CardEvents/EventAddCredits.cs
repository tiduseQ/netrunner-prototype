using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventAddCredits : CardEvent {

	int additionalCredits = 0;
	bool discardCard = false;

	public EventAddCredits(int newCoin, int newClick, costAdditionalDelegate newAdditional, int newAdditionalCredits, bool newDiscardCard, ) : base(newCoin,newClick,newAdditional) {
		additionalCredits = newAdditionalCredits;
	}

	protected override void EventActions(Board.BoardSide side) {
		if (discardCard) {
			if (side = Board.BoardSide.Runner) {
				
			} else if (side = Board.BoardSide.Corp) {

			} else {
				Debug.Log ("EventAddCredits.EventActions(Board.BoardSide side) : Unknown side: " + side);
			}
		}
		discardCard ? Board.Obj_Heap.PushCard(this.gameObject)
		Board.Obj_Grip.RemoveCard (this.gameObject);
		Board.Obj_Rig_Hardware.AddCard (this.gameObject);
	}
}