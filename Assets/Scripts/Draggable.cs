using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public enum TargetTypes { All, InstalledAll, This };
	public enum BoardAreas { HQ, RND, Archives, RemoteServer, ICE, Grip, Stack, Heap, Rig };

	public Transform targetAreaPrefab;
	public TargetTypes[] viableTargets;

	public List<Transform> targetZones = null; //change to not public later

	public void OnBeginDrag(PointerEventData eventData) {
		Debug.Log ("OnBeginDrag");

		targetZones = SpawnTargetZones ();
	}

	public void OnDrag(PointerEventData eventData) {
		this.transform.position = eventData.position;
	}

	public void OnEndDrag(PointerEventData eventData) {
		Debug.Log ("OnEndDrag");

		DestroyTargetZones ();
	}

	public List<Transform> SpawnTargetZones() {
		List<Transform> returnList = new List<Transform> ();
		Transform instantiatedTargetZone = null;

		//stuff
		foreach (TargetTypes target in viableTargets) {
			switch (target) {
			case TargetTypes.All:
				{
					break;
				}

			case TargetTypes.InstalledAll:
				{
					break;
				}
			case TargetTypes.This:
				{
					instantiatedTargetZone = Instantiate (targetAreaPrefab, this.transform.position, this.transform.rotation, this.transform.parent);
					instantiatedTargetZone.SetSiblingIndex (0);
					returnList.Add (instantiatedTargetZone);
					break;
				}
			default:
				{
					break;
				}
			}
		}
			
		return returnList;
	}

	public void DestroyTargetZones() {
		foreach (Transform targetZone in targetZones) {
			Destroy(targetZone.gameObject);
		}
	}
}