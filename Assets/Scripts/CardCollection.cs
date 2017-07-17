using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCollection : MonoBehaviour {

	public Board.BoardSide side;
	public Card.BoardAreas area = Card.BoardAreas.Void;

	public List<GameObject> cardsInCollection = new List<GameObject> ();
	// Bottom -- 1 -- 2 -- 3 -- x -- x+1 -- x+2 -- Top
	//  Left  -- 1 -- 2 -- 3 -- 4 -- x+1 -- x+2 -- Right

	private GameObject AddCard(string cardSet, string cardSubSet, string cardNumber) {
		return AddCard (Board.InstantiateCard (cardSet, cardSubSet, cardNumber));
	}

	public GameObject AddCard(GameObject cardToAdd) {
		cardsInCollection.Add (cardToAdd.gameObject);
		cardToAdd.GetComponent<Card>().currentPosition = area;
		SetParentToThisCollection (cardToAdd);
		return cardToAdd;
	}

	public GameObject AddCard(GameObject cardToAdd, int cardIndex) {
		if (cardIndex < 0) {
			Debug.Log ("CardCollection.AddCard(GameObject cardToAdd, int cardIndex) : Index is less than zero, adding to the end of list");
			return AddCard (cardToAdd);
		} else if (cardIndex <= cardsInCollection.Count) {
			cardsInCollection.Insert (cardIndex, cardToAdd);
			cardToAdd.GetComponent<Card>().currentPosition = area;
			SetParentToThisCollection (cardToAdd);
			return cardToAdd;
		} else {
			Debug.Log ("CardCollection.AddCard(GameObject cardToAdd, int cardIndex) : Index is greater than count of collection, adding to the end of list");
			return AddCard (cardToAdd);
		}
	}

	public GameObject AddCardToBottom(GameObject cardToAdd) {
		return AddCard (cardToAdd, 0);
	}

	public GameObject AddCardToTop(GameObject cardToAdd) {
		return AddCard (cardToAdd);
	}

	public GameObject RemoveCard(GameObject cardToRemove) {
		Debug.Log ("CardCollection.RemoveCard(GameObject cardToRemove)");
		if (cardToRemove != null) {
			cardsInCollection.Remove (cardToRemove);
			cardToRemove.GetComponent<Card>().currentPosition = Card.BoardAreas.Void;
			return cardToRemove;
		} else
			Debug.Log ("CardCollection.RemoveCard(GameObject cardToRemove) : Null arguement");
			return null;
	}

	public GameObject PeekBottomCard() {
		return cardsInCollection.Count > 0 ? cardsInCollection [0] : null;
	}

	public GameObject PeekTopCard() {
		return cardsInCollection.Count > 0 ? cardsInCollection [cardsInCollection.Count - 1] : null;
	}

	public GameObject PeekCardAtIndex(int newIndex) {
		if (newIndex < cardsInCollection.Count && newIndex >= 0) {
			return cardsInCollection.Count > 0 ? cardsInCollection [newIndex] : null;
		} else {
			return null;
		}
	}

	public GameObject DrawTopCard() {
		return RemoveCard (PeekTopCard ());
	}

	public GameObject GetSpecificCard(Card newSpecificCard) {
		foreach (GameObject cardInCollection in cardsInCollection) {
			if (newSpecificCard.id == cardInCollection.GetComponent<Card>().id) {
				return cardInCollection;
			}
		}
		return null;
	}

	public GameObject RemoveSpecificCard(Card newSpecificCard) {
		return RemoveCard (GetSpecificCard (newSpecificCard));
	}

	public void SetParentToThisCollection(GameObject newCard) {
		newCard.transform.SetParent (Board.ReturnProperCollection (area).transform);
	}
}
