using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour {

	public Stack<GameObject> cardsInDeck = new Stack<GameObject>();
	
	public string backNumber = "001";
	public Board.BoardSide side; //most important - is it "runner" or "corp"
	Sprite emptyDeckSprite;
	Sprite nonEmptyDeckSprite;

	// Use this for initialization
	void Start () {
		emptyDeckSprite = Resources.Load<Sprite>("CardBacks/" + backNumber + "/" + "_000_BackTexture");
		nonEmptyDeckSprite = Resources.Load<Sprite>("CardBacks/" + backNumber + "/" + "_001_BackTexture");
	}
	
	// Update is called once per frame
	void Update () {
		if (cardsInDeck.Count > 0) {
			this.GetComponent<Image> ().sprite = nonEmptyDeckSprite;
		} else {
			this.GetComponent<Image> ().sprite = emptyDeckSprite;
		}
	}

	public void DrawCard(string dull) {
		Debug.Log ("Deck.DrawCard()");

		GameObject cardToReturn;

		if (cardsInDeck.Count == 0) {
			Debug.Log ("Deck is empty");
		} else {
			cardToReturn = cardsInDeck.Pop ();
			if (side == Board.BoardSide.Runner) {
				Board.Obj_Grip.AddCard (cardToReturn);
			} else if (side == Board.BoardSide.Corp) {
				Board.Obj_HQ.AddCard (cardToReturn);
			} else
				Debug.Log ("Deck.DrawCard() : side is not set properly: " + side);
			
			Debug.Log ("Deck.DrawCard() : Drawing " + cardToReturn.name);
		}
	}
	
	public GameObject PopCard() {
		Debug.Log ("Deck.PopCard() " + cardsInDeck.Peek ().name);
		return cardsInDeck.Pop();
	}
	
	public GameObject PeekCard() {
		Debug.Log ("Deck.PeekCard() " + cardsInDeck.Peek ().name);
		return cardsInDeck.Peek();
	}
	
	public void PushCard(GameObject cardToAdd) {
		Debug.Log ("Deck.PushCard() " + cardToAdd.name);
		cardsInDeck.Push (cardToAdd);
	}

	public void AddRandomCardToTop(string dull) {
		Debug.Log ("Deck.AddRandomCardToTop()");
	}


}