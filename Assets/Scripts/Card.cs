using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

	public enum CardSide {Runner, Corp};
	public enum CardFaction {Anarch, Criminal, Shaper, Adam, Apex, SunnyLebeau, RunnerNeutral, HaasBioroid, Jinteki, NBN, WeylandConsortium, CorpNeutral};
	public enum CardTypes {Agenda, Asset, Event, Hardware, ICE, Identity, Operation, Program, Resource, Upgrade};
	public enum CardSubtypes {AI, AP, Advertisement, Alliance, Ambush, Barrier, Beanstalk, Bioroid, BlackOps, Bomb, Cast, Caissa, Character, Chip, Clan, Clone, Cloud, CodeGate, Condition, Connection, Console, ConsumerGrade, Corp, Corporation, Current, Cybernetic, Cyborg, Daemon, Decoder, Deflector, Destroyer, Deva, Digital, Directive, Division, Double, Executive, Expansion, Facility, Fracter, GMod, Gear, Genetics, Government, Grail, GrayOps, Hostile, Icebreaker, Illicit, Initiative, Job, Killer, Link, Location, Megacorp, Mod, Morph, Mythic, NEXT, Natural, Observer, Political, Priority, Psi, Public, Region, Remote, Research, Ritzy, Run, Sabotage, Security, Seedy, Sensie, Sentry, Source, Stealth, Sysop, Terminal, Tracer, Transactrion, Trap, Unorthodox, Vehicle, Virtual, Virus, Weapon};

	public enum TargetTypes { All, None, InstalledAll, This };
	public enum BoardAreas { HQ, RND, Archives, RemoteServer, ICE, Grip, Stack, Heap, Rig_Hardware, Rig_Programs, Rig_Resources, Void };
	public enum CardStates { Installed, NotInstalled };
	public enum CardToken { Credit, Advancement, Power, Virus, BadPublicity, BrainDamage, Tag };
	
	public List<CardEvent> CardActions = new List<CardEvent>();

	public CardSide side;
	public CardFaction faction;
	public CardTypes type;
	public CardSubtypes[] subtype;
	public string title;
	public string text;
	public string flavorText;
	public CardStates state = CardStates.NotInstalled;
	public BoardAreas currentPosition = BoardAreas.Void;
	public int id;
	public int numCredit = 0;
	public int numAdvancement = 0;
	public int numPower = 0;
	public int numVirus = 0;
	public int numBadPublicity = 0;
	public int numBrainDamage = 0;
	public int numTag = 0;
	public bool canHostCredit = false;
	public bool canHostAdvancement = false;
	public bool canHostPower = false;
	public bool canHostVirus = false;
	public bool canHostBadPublicity = false;
	public bool canHostBrainDamage = false;
	public bool canHostTag = false;

	public Card() {}

	public void AddCardAction(CardEvent newAction) {
		CardActions.Add (newAction);
	}

	public void RemoveCardAction(CardEvent oldAction) {
		CardActions.Remove (oldAction);
	}

	public void AddToken(CardToken newToken, int newNumber, bool newTrueSetFalseAdd) {
		if (!CanThisHost (newToken)) {
			Debug.Log ("Card.AddToken() : Cannot add token <" + newToken.ToString () + ">");
		} else {
			switch (newToken) {
			case CardToken.Advancement:
				numAdvancement = newTrueSetFalseAdd ? newNumber : ((numAdvancement + newNumber) < 0 ? 0 : numAdvancement + newNumber);
				break;
			case CardToken.BadPublicity:
				numBadPublicity = newTrueSetFalseAdd ? newNumber : ((numBadPublicity + newNumber) < 0 ? 0 : numBadPublicity + newNumber);
				break;
			case CardToken.BrainDamage:
				numBrainDamage = newTrueSetFalseAdd ? newNumber : ((numBrainDamage + newNumber) < 0 ? 0 : numBrainDamage + newNumber);
				break;
			case CardToken.Credit:
				numCredit = newTrueSetFalseAdd ? newNumber : ((numCredit + newNumber) < 0 ? 0 : numCredit + newNumber);
				break;
			case CardToken.Power:
				numPower = newTrueSetFalseAdd ? newNumber : ((numPower + newNumber) < 0 ? 0 : numPower + newNumber);
				break;
			case CardToken.Tag:
				numTag = newTrueSetFalseAdd ? newNumber : ((numTag + newNumber) < 0 ? 0 : numTag + newNumber);
				break;
			case CardToken.Virus:
				numVirus = newTrueSetFalseAdd ? newNumber : ((numVirus + newNumber) < 0 ? 0 : numVirus + newNumber);
				break;
			default:
				Debug.Log ("Card.AddToken() : Unknown token <" + newToken.ToString () + ">");
				break;
			}
		}
	}

	public bool CanThisHost(CardToken newToken) {
		switch (newToken) {
		case CardToken.Advancement:
			return canHostAdvancement;
		case CardToken.BadPublicity:
			return canHostBadPublicity;
		case CardToken.BrainDamage:
			return canHostBrainDamage;
		case CardToken.Credit:
			return canHostCredit;
		case CardToken.Power:
			return canHostPower;
		case CardToken.Tag:
			return canHostTag;
		case CardToken.Virus:
			return canHostVirus;
		default:
			Debug.Log ("Card.AddToken() : Unknown token <" + newToken.ToString () + ">");
			return false;
		}
	}
}
