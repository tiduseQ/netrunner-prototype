using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hand : CardCollection, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	GameObject cardInstantiated;
	public float cardHeight = 0f;
	public float cardWidth = 0f;
	public float handHeight = 0f;
	public float handWidth = 0f;
	public float cardScale = 1f;
	float cardDistance = 0f;
	protected int lastUpdateCardCount = -1;

	// Update is called once per frame
	void Update () {
		if (cardsInCollection.Count != lastUpdateCardCount) {
			lastUpdateCardCount = cardsInCollection.Count;
			OrganizeHand ();
		}
	}

	public void OrganizeHand() {
		handWidth = ((RectTransform)this.transform).rect.width;
		handHeight = ((RectTransform)this.transform).rect.height;
		cardHeight = handHeight - 5f;
		cardWidth = 0.717f * cardHeight;

		cardDistance = Mathf.Min ((handWidth - (cardWidth * (cardsInCollection.Count+1))) / cardsInCollection.Count, 5f);
		int i = 0;
		foreach (GameObject singleCard in cardsInCollection) {
			cardScale = cardHeight / ((RectTransform)singleCard.transform).rect.height;
			singleCard.transform.localScale = new Vector3 (cardScale, cardScale, cardScale);
			singleCard.transform.position = new Vector3 (cardWidth/2 + i*(cardDistance + cardWidth), handHeight/2, 0f);
			i++;
		}
	}
		
	public void OnPointerEnter(PointerEventData eventData) {
	//	Debug.Log ("OnPointerEnter");
	//	AddCard ("001", "001", "002");
	//	OrganizeHand ();
	//	//this.transform.position = whenHovered;
	}
	public void OnPointerExit(PointerEventData eventData) {
		//this.transform.position = whenNotHovered;
	}
	public void OnDrop(PointerEventData eventData) {
	}
}
