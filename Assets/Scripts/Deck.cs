using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : CardCollection {
	
	public string backNumber = "001";
	protected int lastUpdateCardCount = -1;
	public Sprite emptyDeckSprite;
	public Sprite nonEmptyDeckSprite;

	public Deck() {
		Debug.Log ("Deck.Deck()");
	}

	void Start () {
		Debug.Log ("Deck.Start()");
		emptyDeckSprite = Resources.Load<Sprite>("CardBacks/" + backNumber + "/" + "_000_BackTexture");
		nonEmptyDeckSprite = Resources.Load<Sprite>("CardBacks/" + backNumber + "/" + "_001_BackTexture");
	}


	void Update () {
		if (cardsInCollection.Count != lastUpdateCardCount) {
			lastUpdateCardCount = cardsInCollection.Count;
			if (cardsInCollection.Count > 0) {
				this.GetComponent<Image> ().sprite = nonEmptyDeckSprite;
			} else {
				this.GetComponent<Image> ().sprite = emptyDeckSprite;
			}
		}
	}

	public void DrawCard() {
		Debug.Log ("Deck.DrawCard()");

		GameObject cardToReturn;

		if (cardsInCollection.Count == 0) {
			Debug.Log ("Deck is empty");
		} else {
			cardToReturn = DrawTopCard();
			if (side == Board.BoardSide.Runner) {
				Board.Obj_Grip.AddCardToTop (cardToReturn);
			} else if (side == Board.BoardSide.Corp) {
				Board.Obj_HQ.AddCardToTop (cardToReturn);
			} else {
				Debug.Log ("Deck.DrawCard() : side is not set properly: " + side);
			}
		}
	}
}