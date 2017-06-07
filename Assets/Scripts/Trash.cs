using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour {

	public string side;

	public Stack<GameObject> cardsInTrash = new Stack<GameObject>();

	public void PushCard(GameObject cardToAdd) {
		Debug.Log ("Trash.PushCard() " + cardToAdd.name);
		cardsInTrash.Push (cardToAdd);
	}

	public GameObject PopCard() {
		Debug.Log ("Trash.PopCard() " + cardsInTrash.Peek ().name);
		return cardsInTrash.Pop();
	}

	public GameObject PeekCard() {
		Debug.Log ("Trash.PeekCard() " + cardsInTrash.Peek ().name);
		return cardsInTrash.Peek();
	}
}
