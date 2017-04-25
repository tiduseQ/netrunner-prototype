using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

	public enum CardSide {Runner, Corp};
	public enum CardFaction {Anarch, Criminal, Shaper, Adam, Apex, SunnyLebeau, RunnerNeutral, HaasBioroid, Jinteki, NBN, WeylandConsortium, CorpNeutral};
	public enum CardTypes {Agenda, Asset, Event, Hardware, ICE, Identity, Operation, Program, Resource, Upgrade};
	public enum CardSubtypes {AI, AP, Advertisement, Alliance, Ambush, Barrier, Beanstalk, Bioroid, BlackOps, Bomb, Cast, Caissa, Character, Chip, Clan, Clone, Cloud, CodeGate, Condition, Connection, Console, ConsumerGrade, Corp, Corporation, Current, Cybernetic, Cyborg, Daemon, Decoder, Deflector, Destroyer, Deva, Digital, Directive, Division, Double, Executive, Expansion, Facility, Fracter, GMod, Gear, Genetics, Government, Grail, GrayOps, Hostile, Icebreaker, Illicit, Initiative, Job, Killer, Link, Location, Megacorp, Mod, Morph, Mythic, NEXT, Natural, Observer, Political, Priority, Psi, Public, Region, Remote, Research, Ritzy, Run, Sabotage, Security, Seedy, Sensie, Sentry, Source, Stealth, Sysop, Terminal, Tracer, Transactrion, Trap, Unorthodox, Vehicle, Virtual, Virus, Weapon};

	public enum TargetTypes { All, None, InstalledAll, This };
	public enum BoardAreas { HQ, RND, Archives, RemoteServer, ICE, Grip, Stack, Heap, Rig };
	
	public List<CardEvent> CardActions = new List<CardEvent>();

	public CardSide side;
	public CardFaction faction;
	public CardTypes type;
	public CardSubtypes[] subtype;
	public string title;
	public string text;
	public string flavorText;
}
