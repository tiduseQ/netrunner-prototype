using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heap : Trash {

	void Start () {
		side = Board.BoardSide.Runner;
		area = Card.BoardAreas.Heap;
	}

}
