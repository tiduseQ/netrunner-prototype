using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rig_Programs : MonoBehaviour {

	GameObject cardInstantiated;
	public float cardHeight = 0f;
	public float cardWidth = 0f;
	public float progHeight = 0f;
	public float progWidth = 0f;
	public float cardScale = 1f;
	float cardDistance = 0f;

	public List<GameObject> cardsInPrograms = new List<GameObject> ();

	public void AddCard(GameObject cardToAdd) {
		cardsInPrograms.Add (cardToAdd);
		OrganizePrograms ();
	}

	public void OrganizePrograms() {
		progWidth = ((RectTransform)this.transform).rect.width;
		progHeight = ((RectTransform)this.transform).rect.height;
		cardHeight = progHeight - 5f;
		cardWidth = 0.717f * cardHeight;

		cardDistance = Mathf.Min ((progWidth - (cardWidth * (cardsInPrograms.Count+1))) / cardsInPrograms.Count, 5f);
		int i = 0;
		foreach (GameObject singleCard in cardsInPrograms) {
			cardScale = cardHeight / ((RectTransform)singleCard.transform).rect.height;
			singleCard.transform.localScale = new Vector3 (cardScale, cardScale, cardScale);
			singleCard.transform.position = new Vector3 (cardWidth/2 + i*(cardDistance + cardWidth), progHeight/2, 0f);
			i++;
		}
	}
}