using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class Stick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	private int touchId = -1;
	private Vector3 defaultPos;
	public RectTransform img = null;
	private float offset = 30f;

	[HideInInspector]
	public Vector2 padPos;

	private bool moving = false;

	public bool enableAxisX = true;
	public bool enableAxisY = true;


	private void Awake () {
		defaultPos = img.position;
		padPos = Vector2.zero;
	}


    public void OnBeginDrag(PointerEventData eventData) {
		touchId = eventData.pointerId;
		moving = true;
		UpdatePosition (eventData.position);
	}

	public void OnDrag(PointerEventData data) {
		if (data.pointerId != touchId)
			return;

		UpdatePosition (data.position);
	}


	public void OnEndDrag(PointerEventData eventData) {
		img.position = defaultPos;
		touchId = -1;
		moving = false;
		padPos = Vector2.zero;
	}


	private void UpdatePosition (Vector2 pos) {
        Vector3 worldPoint = GUICamera.ScreenToWorldPoint (pos);
		if (enableAxisX) padPos.x = worldPoint.x;
		if (enableAxisY) padPos.y = worldPoint.y;
        img.position = defaultPos + Vector3.ClampMagnitude(padPos - (Vector2)defaultPos, offset);

        if (moving) {
            padPos = padPos - (Vector2)defaultPos;
            padPos = Vector3.ClampMagnitude(padPos, offset) * 0.03f;
        }
	}
}
