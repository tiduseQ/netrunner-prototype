using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetsInformation : MonoBehaviour {

	public int[] subsetsForSet = new int[12];
	public int[,] cardsInSubsets = new int[12,7];

	// Use this for initialization
	void Start () {
		subsetsForSet [0] = 1;
		subsetsForSet [1] = 1;
		subsetsForSet [2] = 6;
		subsetsForSet [3] = 1;
		subsetsForSet [4] = 6;
		subsetsForSet [5] = 1;
		subsetsForSet [6] = 6;
		subsetsForSet [7] = 1;
		subsetsForSet [8] = 6;
		subsetsForSet [9] = 1;
		subsetsForSet [10] = 6;
		subsetsForSet [11] = 6;

		for (int i = 0; i < cardsInSubsets.GetUpperBound (0); i++) {
			for (int j = 0; j < cardsInSubsets.GetUpperBound (1); j++) {
				cardsInSubsets [i, j] = 0;
			}
		}

		cardsInSubsets [0, 1] = 9;
		cardsInSubsets [1, 1] = 113;
		cardsInSubsets [2, 1] = 20;
		cardsInSubsets [2, 2] = 20;
		cardsInSubsets [2, 3] = 20;
		cardsInSubsets [2, 4] = 20;
		cardsInSubsets [2, 5] = 20;
		cardsInSubsets [2, 6] = 20;
		cardsInSubsets [3, 1] = 55;
		cardsInSubsets [4, 1] = 20;
		cardsInSubsets [4, 2] = 20;
		cardsInSubsets [4, 3] = 20;
		cardsInSubsets [4, 4] = 20;
		cardsInSubsets [4, 5] = 20;
		cardsInSubsets [4, 6] = 20;
		cardsInSubsets [5, 1] = 55;
		cardsInSubsets [6, 1] = 20;
		cardsInSubsets [6, 2] = 20;
		cardsInSubsets [6, 3] = 20;
		cardsInSubsets [6, 4] = 20;
		cardsInSubsets [6, 5] = 20;
		cardsInSubsets [6, 6] = 20;
		cardsInSubsets [7, 1] = 55;
		cardsInSubsets [8, 1] = 20;
		cardsInSubsets [8, 2] = 20;
		cardsInSubsets [8, 3] = 20;
		cardsInSubsets [8, 4] = 20;
		cardsInSubsets [8, 5] = 20;
		cardsInSubsets [8, 6] = 20;
		cardsInSubsets [9, 1] = 55;
		cardsInSubsets [10, 1] = 20;
		cardsInSubsets [10, 2] = 20;
		cardsInSubsets [10, 3] = 20;
		cardsInSubsets [10, 4] = 20;
		cardsInSubsets [10, 5] = 20;
		cardsInSubsets [10, 6] = 20;
		cardsInSubsets [11, 1] = 20;
		cardsInSubsets [11, 2] = 20;
		cardsInSubsets [11, 3] = 20;
		cardsInSubsets [11, 4] = 20;
		cardsInSubsets [11, 5] = 20;
		cardsInSubsets [11, 6] = 20;
	}

	// Update is called once per frame
	void Update () {

	}

	public Vector3 ReturnRandomCard() {
		int cardSet = UnityEngine.Random.Range (1,subsetsForSet.GetUpperBound(0));
		int cardSubset = UnityEngine.Random.Range (1,subsetsForSet[cardSet]+1);
		int cardNumber = UnityEngine.Random.Range(1, cardsInSubsets[cardSet,cardSubset]+1);
		Vector3 cardToReturn = new Vector3 (cardSet, cardSubset, cardNumber);
		return cardToReturn;
	}
}
