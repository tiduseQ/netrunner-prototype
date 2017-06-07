﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rig_Resources : MonoBehaviour {

	GameObject cardInstantiated;
	public float cardHeight = 0f;
	public float cardWidth = 0f;
	public float resHeight = 0f;
	public float resWidth = 0f;
	public float cardScale = 1f;
	float cardDistance = 0f;

	public List<GameObject> cardsInResources = new List<GameObject> ();

	public void AddCard(GameObject cardToAdd) {
		cardsInResources.Add (cardToAdd);
		OrganizeResources ();
	}

	public void OrganizeResources() {
		resWidth = ((RectTransform)this.transform).rect.width;
		resHeight = ((RectTransform)this.transform).rect.height;
		cardHeight = resHeight - 5f;
		cardWidth = 0.717f * cardHeight;

		cardDistance = Mathf.Min ((resWidth - (cardWidth * (cardsInResources.Count+1))) / cardsInResources.Count, 5f);
		int i = 0;
		foreach (GameObject singleCard in cardsInResources) {
			cardScale = cardHeight / ((RectTransform)singleCard.transform).rect.height;
			singleCard.transform.localScale = new Vector3 (cardScale, cardScale, cardScale);
			singleCard.transform.position = new Vector3 (cardWidth/2 + i*(cardDistance + cardWidth), resHeight/2, 0f);
			i++;
		}
	}
}