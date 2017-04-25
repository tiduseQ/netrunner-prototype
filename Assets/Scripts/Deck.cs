using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour {

	public Stack<GameObject> cardsInDeck = new Stack<GameObject>();
	public GameObject Obj_Rig;
	public GameObject Obj_Hand;
	public GameObject Obj_Deck;
	
	public string backNumber = "001";
	Sprite emptyDeckSprite;
	Sprite nonEmptyDeckSprite;

	// Use this for initialization
	void Start () {
		Obj_Rig = GameObject.Find ("Rig");
		Obj_Hand = GameObject.Find ("Hand");
		Obj_Deck = GameObject.Find ("Deck");
		
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
			Obj_Hand.GetComponent<Hand> ().AddCardToHand (cardToReturn);
			Debug.Log ("Drawing " + cardToReturn.name);
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
		//Vector3 cardReturned = Obj_Deck.GetComponent<SetsInformation> ().ReturnRandomCard ();
	}


}