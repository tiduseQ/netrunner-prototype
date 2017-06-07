using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEvent : MonoBehaviour {

	public enum EventCondition {Installed, NotInstalled};
	
	public string eventName = "";
	public int costCoin = 0;
	public int costClick = 0;
	public delegate bool costAdditionalDelegate();
	public costAdditionalDelegate costAdditional;
	public List<EventCondition> activeCondition = new List<EventCondition>();

	public CardEvent (int newCoin, int newClick, costAdditionalDelegate newAdditional) {
		costCoin = newCoin;
		costClick = newClick;
		costAdditional = newAdditional;
	}

	protected virtual void PlayEvent(Board.BoardSide side) {
		Debug.Log ("CardEvent.PlayEvent()");
		if (PayCost (side)) {
			EventActions (side);
		}
	}

	protected virtual void EventActions(Board.BoardSide side) {	}

	protected virtual bool PayCost(Board.BoardSide side) {
		if (side == Board.BoardSide.Runner) {
			Board.runnerCredits -= costCoin;
			Board.runnerClicks -= costClick;
			if (costAdditional != null) {
				if (costAdditional () == false) {
					Board.runnerCredits += costCoin;
					Board.runnerClicks += costClick;
					return false;
				}
			}
		} else if (side == Board.BoardSide.Corp) {
			Board.corpCredits -= costCoin;
			Board.corpClicks -= costClick;
			if (costAdditional != null) {
				if (costAdditional () == false) {
					Board.corpCredits += costCoin;
					Board.corpClicks += costClick;
					return false;
				}
			}
		} else {
			Debug.Log("CardEvent.PayCost(string side) : Unknown side: " + side);
		}
		return true;
	}

	protected virtual bool AssessCost(Board.BoardSide side) {
		//not accounting for additional costs
		if (side == Board.BoardSide.Runner) {
			return (Board.runnerCredits >= costCoin && Board.runnerClicks >= costClick ? true : false);
		} else if (side == Board.BoardSide.Corp) {
			return (Board.corpCredits >= costCoin && Board.corpClicks >= costClick ? true : false);
		} else {
			Debug.Log ("InstallHardware.AssessCost(Board.BoardSide side) : Unknown side: " + side);
			return false;
		}

		//assess conditions
		if (side == Board.BoardSide.Runner) {
			return (Board.runnerCredits >= costCoin && Board.runnerClicks >= costClick ? true : false);
		} else if (side == Board.BoardSide.Corp) {
			return (Board.corpCredits >= costCoin && Board.corpClicks >= costClick ? true : false);
		} else {
			Debug.Log ("InstallHardware.AssessCost(Board.BoardSide side) : Unknown side: " + side);
			return false;
		}
	}

	public CardEvent(string newEventName) {
		eventName = newEventName;
	}
}
