using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rig_Hardware : MonoBehaviour {

	GameObject cardInstantiated;
	public float cardHeight = 0f;
	public float cardWidth = 0f;
	public float hardHeight = 0f;
	public float hardWidth = 0f;
	public float cardScale = 1f;
	float cardDistance = 0f;

	public List<GameObject> cardsInHardware = new List<GameObject> ();

	public void AddCard(GameObject cardToAdd) {
		cardsInHardware.Add (cardToAdd);
		OrganizeHardware ();
	}

	public void OrganizeHardware() {
		hardWidth = ((RectTransform)this.transform).rect.width;
		hardHeight = ((RectTransform)this.transform).rect.height;
		cardHeight = hardHeight - 5f;
		cardWidth = 0.717f * cardHeight;

		cardDistance = Mathf.Min ((hardWidth - (cardWidth * (cardsInHardware.Count+1))) / cardsInHardware.Count, 5f);
		int i = 0;
		foreach (GameObject singleCard in cardsInHardware) {
			cardScale = cardHeight / ((RectTransform)singleCard.transform).rect.height;
			singleCard.transform.localScale = new Vector3 (cardScale, cardScale, cardScale);
			singleCard.transform.position = new Vector3 (cardWidth/2 + i*(cardDistance + cardWidth), hardHeight/2, 0f);
			i++;
		}
	}
}