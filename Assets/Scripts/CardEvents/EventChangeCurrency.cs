using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventChangeCurrency : CardEvent {

	int changeCurrency = 0;
	Board.Currency currency;
	bool discardCard = false;

	public EventChangeCurrency(int newCoin, int newClick, costAdditionalDelegate newAdditional, int newChangeCurrency, Board.Currency newCurrency, bool newDiscardCard, string newEventName) : base(newCoin,newClick,newAdditional,newEventName) {
		changeCurrency = newChangeCurrency;
		currency = newCurrency;
		discardCard = newDiscardCard;
	}

	protected override void EventActions(Board.BoardSide side) {
		if (discardCard) {
			Board.DiscardCard (source);
		}
		Board.ChangePlayerCurrency (side, changeCurrency, currency);
	}
}