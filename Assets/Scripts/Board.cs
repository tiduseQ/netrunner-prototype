using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Board {

	public enum BoardSide {Runner, Corp};
	public enum Currency {Click, Credit};

	public static BoardSide currentTurn;
	public static List<GameObject> allCards = new List<GameObject> ();

	public static int cardsNumber = 0;

	public static int runnerCredits = 0;
	public static int runnerClicks = 0;
	public static int corpCredits = 0;
	public static int corpClicks = 0;

	//runner
	public static Hand Obj_Grip {
		get{ return GameObject.Find ("Grip").GetComponent<Grip>();}
	}
	public static Deck Obj_Stack {
		get{ return GameObject.Find ("Stack").GetComponent<Stack>();}
	}
	public static Trash Obj_Heap {
		get{ return GameObject.Find ("Heap").GetComponent<Heap>();}
	}

	//rig
	public static Rig Obj_Rig {
		get{ return GameObject.Find ("Rig").GetComponent<Rig>();}
	}
	public static Rig_Programs Obj_Rig_Programs {
		get{ return GameObject.Find ("Rig_Programs").GetComponent<Rig_Programs>();}
	}
	public static Rig_Hardware Obj_Rig_Hardware {
		get{ return GameObject.Find ("Rig_Hardware").GetComponent<Rig_Hardware>();}
	}
	public static Rig_Resources Obj_Rig_Resources {
		get{ return GameObject.Find ("Rig_Resources").GetComponent<Rig_Resources>();}
	}

	//corp
	public static Hand Obj_HQ {
		get{ return GameObject.Find ("Grip").GetComponent<Grip>();}
	}
	public static Deck Obj_RND {
		get{ return GameObject.Find ("RND").GetComponent<RND>();}
	}
	public static Trash Obj_Archives {
		get{ return GameObject.Find ("Archives").GetComponent<Archives>();}
	}

	//servers still missing
	public static int AssignId() {
		return cardsNumber++;
	}
		
	public static CardCollection ReturnProperCollection(Card.BoardAreas newBoardArea) {
		switch (newBoardArea) {
		case Card.BoardAreas.Archives:
			//return Obj_Archives.RemoveCard (Obj_Archives.GetSpecificCard (newCard));
			return Obj_Archives;
		case Card.BoardAreas.Grip:
			return Obj_Grip;
		case Card.BoardAreas.Heap:
			return Obj_Heap;
		case Card.BoardAreas.HQ:
			return Obj_HQ;
		case Card.BoardAreas.ICE:
			//return Obj_Archives;
			break;
		case Card.BoardAreas.RemoteServer:
			//return Obj_Archives;
			break;
		case Card.BoardAreas.Rig_Hardware:
			return Obj_Rig_Hardware;
		case Card.BoardAreas.Rig_Programs:
			return Obj_Rig_Programs;
		case Card.BoardAreas.Rig_Resources:
			return Obj_Rig_Resources;
		case Card.BoardAreas.RND:
			return Obj_RND;
		case Card.BoardAreas.Stack:
			return Obj_Stack;
		default:
			Debug.Log ("Board.RemoveCardFromCollection() : Unknown board area <" + newBoardArea.ToString () + ">");
			break;
		}
		return null;
	}

	public static GameObject RemoveCardFromCollection(Card newCard, Card.BoardAreas newBoardArea) {
		newCard.currentPosition = Card.BoardAreas.Void;
		return ReturnProperCollection (newBoardArea).RemoveSpecificCard (newCard);
	}

	public static GameObject AddCardToCollection(Card newCard, Card.BoardAreas newBoardArea) {
		return AddCardToCollection(newCard.gameObject, newBoardArea);
	}

	public static GameObject AddCardToCollection(GameObject newCard, Card.BoardAreas newBoardArea) {
		newCard.GetComponent<Card> ().currentPosition = newBoardArea;
		return ReturnProperCollection (newBoardArea).AddCardToTop (newCard);
	}

	public static GameObject AddCardToCollection(GameObject newCard, Card.BoardAreas newBoardArea, int newIndex) {
		newCard.GetComponent<Card> ().currentPosition = newBoardArea;
		return ReturnProperCollection (newBoardArea).AddCard (newCard, newIndex);
	}

	public static GameObject AddCardToCollection(Card newCard, Card.BoardAreas newBoardArea, int newIndex) {
		return AddCardToCollection (newCard.gameObject, newBoardArea, newIndex);
	}

	public static GameObject DiscardCard(Card newCard) {
		GameObject cardDiscarded;
		if (newCard.side == Card.CardSide.Corp) {
			cardDiscarded = Obj_Archives.AddCardToTop (ReturnProperCollection (newCard.currentPosition).RemoveSpecificCard (newCard));
			newCard.currentPosition = Card.BoardAreas.Archives;
		} else {
			cardDiscarded = Obj_Heap.AddCardToTop (ReturnProperCollection (newCard.currentPosition).RemoveSpecificCard (newCard));
			newCard.currentPosition = Card.BoardAreas.Heap;
		}
		return cardDiscarded;
	}

	public static void ChangePlayerCurrency(BoardSide newSide,int newAmmount, Board.Currency newCurrency) {
		switch (newSide) {
		case BoardSide.Corp:
			switch (newCurrency) {
			case Currency.Click:
				runnerClicks = (runnerClicks + newAmmount) < 0 ? 0 : (runnerClicks + newAmmount);
				break;
			case Currency.Credit:
				runnerCredits = (runnerCredits + newAmmount) < 0 ? 0 : (runnerCredits + newAmmount);
				break;
			}
			break;
		case BoardSide.Runner:
			switch (newCurrency) {
			case Currency.Click:
				corpClicks = (corpClicks + newAmmount) < 0 ? 0 : (corpClicks + newAmmount);
				break;
			case Currency.Credit:
				corpCredits = (corpCredits + newAmmount) < 0 ? 0 : (corpCredits + newAmmount);
				break;
			}
			break;
		}
	}

	public static GameObject InstantiateCard(string newCardSet, string newCardSubSet, string newCardNumber) {
		GameObject cardToReturn = GameObject.Instantiate(GetCardFromStrings(newCardSet, newCardSubSet, newCardNumber));
		cardToReturn.GetComponent<Card> ().id = AssignId ();
		allCards.Add (cardToReturn);
		return cardToReturn;
	}

	private static GameObject GetCardFromStrings(string cardSet, string cardSubSet, string cardNumber) {
		GameObject CardToReturn = (GameObject)Resources.Load ("Cards/" + cardSet + "/" + cardSubSet + "/_" + cardSet + "_" + cardSubSet + "_" + cardNumber + "_Prefab");
		if (CardToReturn == null) {
			Debug.Log ("Board.GetCardFromStrings(string cardSet, string cardSubSet, string cardNumber) : Could not load card at: " + "Cards/" + cardSet + "/" + cardSubSet + "/_" + cardSet + "_" + cardSubSet + "_" + cardNumber + "_Prefab");
			return null;
		}
		return CardToReturn;
	}
}