using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : Deck {

	void Start () {
		Debug.Log ("Stack.Start()");
		side = Board.BoardSide.Runner;	
	}

	public Stack() : base() {
		Debug.Log ("Stack.Stack()");
	}
}
