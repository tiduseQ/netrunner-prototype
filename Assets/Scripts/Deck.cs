using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

	public Stack<GameObject> cardsInDeck = new Stack<GameObject>();
	public GameObject Obj_Rig;
	public GameObject Obj_Hand;
	public GameObject Obj_Deck;

	// Use this for initialization
	void Start () {
		Obj_Rig = GameObject.Find ("Rig");
		Obj_Hand = GameObject.Find ("Hand");
		Obj_Deck = GameObject.Find ("Deck");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public GameObject DrawCard() {
		return cardsInDeck.Pop();
	}

	public void AddToTop(GameObject cardToAdd) {
		cardsInDeck.Push (cardToAdd);
	}

	public void AddRandomCardToTop(string dull) {
		Debug.Log ("Deck.AddRandomCardToTop()");
		Vector3 cardReturned = Obj_Deck.GetComponent<SetsInformation> ().ReturnRandomCard ();
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
}