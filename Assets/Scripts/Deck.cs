using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

	public Stack<Transform> cardsInDeck = new Stack<Transform>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Transform DrawCard() {
		return cardsInDeck.Pop();
	}

	public void AddToTop(Transform cardToAdd) {
		cardsInDeck.Push (cardToAdd);
	}
}
