using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventAddTokenToCard : CardEvent {

	public Card.CardToken tokenType;
	public int tokenNumber;
	public bool trueSetFalseAdd;

	public EventAddTokenToCard(Card.CardToken newTokenType, int newNumber, bool newTrueSetFalseAdd, Card newSource, Card newTarget, string newEventName) : base() {
		activeCondition.Add (EventCondition.EndOfRound);
		activeCondition.Add (EventCondition.Mandatory);
		source = newSource;
		target.Add(newTarget);
		tokenType = newTokenType;
		tokenNumber = newNumber;
		trueSetFalseAdd = newTrueSetFalseAdd;
	}

	public EventAddTokenToCard(Card.CardToken newTokenType, int newNumber, bool trueSetFalseAdd, Card newSource, List<Card> newTarget, string newEventName) : base() {
		activeCondition.Add (EventCondition.EndOfRound);
		activeCondition.Add (EventCondition.Mandatory);
		source = newSource;
		target = newTarget;
	}

	protected override void EventActions(Board.BoardSide side) {
		foreach (Card singleCard in target) {
			singleCard.AddToken (tokenType, tokenNumber, trueSetFalseAdd);
		}
	}
}