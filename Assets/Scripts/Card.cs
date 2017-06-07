using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

	public enum CardSide {Runner, Corp};
	public enum CardFaction {Anarch, Criminal, Shaper, Adam, Apex, SunnyLebeau, RunnerNeutral, HaasBioroid, Jinteki, NBN, WeylandConsortium, CorpNeutral};
	public enum CardTypes {Agenda, Asset, Event, Hardware, ICE, Identity, Operation, Program, Resource, Upgrade};
	public enum CardSubtypes {AI, AP, Advertisement, Alliance, Ambush, Barrier, Beanstalk, Bioroid, BlackOps, Bomb, Cast, Caissa, Character, Chip, Clan, Clone, Cloud, CodeGate, Condition, Connection, Console, ConsumerGrade, Corp, Corporation, Current, Cybernetic, Cyborg, Daemon, Decoder, Deflector, Destroyer, Deva, Digital, Directive, Division, Double, Executive, Expansion, Facility, Fracter, GMod, Gear, Genetics, Government, Grail, GrayOps, Hostile, Icebreaker, Illicit, Initiative, Job, Killer, Link, Location, Megacorp, Mod, Morph, Mythic, NEXT, Natural, Observer, Political, Priority, Psi, Public, Region, Remote, Research, Ritzy, Run, Sabotage, Security, Seedy, Sensie, Sentry, Source, Stealth, Sysop, Terminal, Tracer, Transactrion, Trap, Unorthodox, Vehicle, Virtual, Virus, Weapon};

	public enum TargetTypes { All, None, InstalledAll, This };
	public enum BoardAreas { HQ, RND, Archives, RemoteServer, ICE, Grip, Stack, Heap, Rig_Hardware, Rig_Programs, Rig_Resources };
	public enum CardStates { Installed, NotInstalled };
	
	public List<CardEvent> CardActions = new List<CardEvent>();

	public CardSide side;
	public CardFaction faction;
	public CardTypes type;
	public CardSubtypes[] subtype;
	public string title;
	public string text;
	public string flavorText;
	public CardStates state;
	public BoardAreas currentPosition;
	public int id;

	public Card() {
		Debug.Log ("Card.Card() : Creating new NULL card");
	}

	public Card(CardSide newSide, CardFaction newFaction, CardTypes newType, CardSubtypes[] newSubtype, string newTitle, string newText, string newFlavorText, CardStates newState) {
		Debug.Log ("Card.Card() : Creating new card (title=" + newTitle + ")");
		side = newSide;
		faction = newFaction;
		type = newType;
		subtype = newSubtype;
		title = newTitle;
		text = newText;
		flavorText = newFlavorText;
		state = newState;
	}

	public void AddCardAction(CardEvent newAction) {
		Debug.Log("Card.AddCardAction(CardEvent newAction)");
		CardActions.Add (newAction);
	}

	public void RemoveCardAction(CardEvent oldAction) {
		Debug.Log("Card.RemoveCardAction(CardEvent oldAction)");
		CardActions.Remove (oldAction);
	}
}
