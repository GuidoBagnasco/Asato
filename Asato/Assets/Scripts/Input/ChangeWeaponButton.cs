using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeWeaponButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {

    public bool clicked = false;


    public void OnPointerUp (PointerEventData eventData) {
        clicked = false;
    }


    public void OnPointerDown (PointerEventData eventData) {
        clicked = true;
    }


    public float IsClicked () {
        return clicked ? 1f : 0f;
    }
}
