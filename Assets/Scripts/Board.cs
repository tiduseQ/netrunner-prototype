using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Board {

	public enum BoardSide {Runner, Corp};

	public static BoardSide currentTurn;
	public static List<Card> allCards = new List<Card> ();

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
		cardsNumber++;
		return cardsNumber;
	}

	public static Card FetchCard(int newId) {

		return 
	}
}