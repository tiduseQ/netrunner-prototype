using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hand : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	public string side;

	GameObject cardInstantiated;
	public float cardHeight = 0f;
	public float cardWidth = 0f;
	public float handHeight = 0f;
	public float handWidth = 0f;
	public float cardScale = 1f;
	float cardDistance = 0f;

	public List<GameObject> cardsInHand = new List<GameObject> ();

	public GameObject GetCardFromStrings(string cardSet, string cardSubSet, string cardNumber) {
		GameObject CardToReturn = (GameObject)Resources.Load ("Cards/" + cardSet + "/" + cardSubSet + "/_" + cardNumber + "_Prefab");
		if (CardToReturn == null) {
			Debug.Log ("Hand.GetCardFromStrings() : Could not load texture at: " + "Cards/" + cardSet + "/" + cardSubSet + "/_" + cardNumber + "_Prefab");
			return null;
		}
		return CardToReturn;
	}

	public void AddCard(string cardSet, string cardSubSet, string cardNumber) {
		Debug.Log ("Hand.AddCardToHand(string cardSet, string cardSubSet, string cardNumber)");
		GameObject cardToInstantiate = GetCardFromStrings(cardSet, cardSubSet, cardNumber);
		if (cardToInstantiate != null) {
			cardInstantiated = Instantiate (cardToInstantiate, this.transform);
			cardsInHand.Add (cardInstantiated.gameObject);
			OrganizeHand ();
		} else {
			Debug.Log ("Hand.AddCardToHand() : Null prefab returned, card not added");
		}
	}

	public void AddCard(GameObject cardToAdd) {
		Debug.Log ("Hand.AddCard(GameObject cardToAdd)");
		cardsInHand.Add (cardToAdd.gameObject);
		OrganizeHand ();
	}
	
	private GameObject InstantiateCard(string resourceString) {
		GameObject returnResource = (GameObject)Resources.Load (resourceString);
		if (returnResource == null) {
			Debug.Log ("Could not load at: " + resourceString);
			return null;
		} else {
			Debug.Log ("Success in load at: " + resourceString);
		}
		return Instantiate(returnResource, this.transform);
	}

	public void RemoveCard(GameObject cardToRemove) {
		Debug.Log ("HandRemoveCard(GameObject cardToRemove)");
		cardsInHand.Remove (cardToRemove);
		OrganizeHand ();
	}

	public void OrganizeHand() {
		handWidth = ((RectTransform)this.transform).rect.width;
		handHeight = ((RectTransform)this.transform).rect.height;
		cardHeight = handHeight - 5f;
		cardWidth = 0.717f * cardHeight;

		cardDistance = Mathf.Min ((handWidth - (cardWidth * (cardsInHand.Count+1))) / cardsInHand.Count, 5f);
		int i = 0;
		foreach (GameObject singleCard in cardsInHand) {
			cardScale = cardHeight / ((RectTransform)singleCard.transform).rect.height;
			singleCard.transform.localScale = new Vector3 (cardScale, cardScale, cardScale);
			singleCard.transform.position = new Vector3 (cardWidth/2 + i*(cardDistance + cardWidth), handHeight/2, 0f);
			i++;
		}
	}
		
	public void OnPointerEnter(PointerEventData eventData) {
		Debug.Log ("OnPointerEnter");
		AddCard ("001", "001", "002");
		OrganizeHand ();
		//this.transform.position = whenHovered;
	}
	public void OnPointerExit(PointerEventData eventData) {
		//this.transform.position = whenNotHovered;
	}
	public void OnDrop(PointerEventData eventData) {
	}
}
