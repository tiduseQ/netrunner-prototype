using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hand : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	GameObject cardInstantiated;
	public float cardHeight = 0f;
	public float cardWidth = 0f;
	public float handHeight = 0f;
	public float handWidth = 0f;
	float cardDistance = 0f;

	public List<GameObject> cardsInHand = new List<GameObject> ();

	public GameObject GetCardFromStrings(string cardSet, string cardSubSet, string cardNumber) {
		GameObject CardToReturn = (GameObject)Resources.Load ("Cards/" + cardSet + "/" + cardSubSet + "/_" + cardNumber + "_Prefab");
		if (CardToReturn == null) {
			Debug.Log ("Could not load texture at: " + "Cards/" + cardSet + "/" + cardSubSet + "/_" + cardNumber + "_Prefab");
			return null;
		}
		return CardToReturn;
	}

	public void AddCardToHand(string cardSet, string cardSubSet, string cardNumber) {
		GameObject cardToInstantiate = GetCardFromStrings(cardSet, cardSubSet, cardNumber); var  
		cardInstantiated = Instantiate(cardToInstantiate, this.transform);
		cardsInHand.Add (cardInstantiated.gameObject);
	}

	public void AddCardToHand(GameObject cardToAdd) {
		cardsInHand.Add (cardToAdd.gameObject);
	}

	public void OrganizeHand() {
		Debug.Log ("OrganizeHand");

		int i = 0;
		RectTransform rt = (RectTransform)this.transform;

		handWidth = rt.rect.width;
		handHeight = rt.rect.height;
		cardHeight = handHeight - 5f;
		cardWidth = 0.717f * cardHeight;

		cardDistance = Mathf.Min ((handWidth - (cardWidth * (cardsInHand.Count+1))) / cardsInHand.Count, 5f);
		foreach (GameObject singleCard in cardsInHand) {
			rt = (RectTransform)singleCard.transform;
			singleCard.transform.localScale = new Vector3 (cardHeight / rt.rect.height, cardHeight / rt.rect.height, cardHeight / rt.rect.height);
			singleCard.transform.position = new Vector3 (cardWidth/2 + i*(cardDistance + cardWidth), handHeight/2, 0f);
			i++;
		}

		//RectTransform rt = (RectTransform)cardsInHand [0].transform;
		//cardWidth = rt.rect.width;
		//cardHeight = rt.rect.height;

		//cardDistance = 
		//cardsInHand.Count
	}


	//Vector3 whenNotHovered = new Vector3(283.5f,-25f,0f);
	//Vector3 whenHovered = new Vector3(283.5f,40f,0f);
	public void OnPointerEnter(PointerEventData eventData) {
		Debug.Log ("OnPointerEnter");
		AddCardToHand ("001", "001", "002");
		OrganizeHand ();
		//this.transform.position = whenHovered;
	}
	public void OnPointerExit(PointerEventData eventData) {
		//this.transform.position = whenNotHovered;
	}
	public void OnDrop(PointerEventData eventData) {
	}
}
