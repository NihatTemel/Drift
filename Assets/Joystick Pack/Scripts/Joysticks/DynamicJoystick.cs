using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DynamicJoystick : Joystick
{
    public float MoveThreshold { get { return moveThreshold; } set { moveThreshold = Mathf.Abs(value); } }

    Vector3 Startpos;

    [SerializeField] private float moveThreshold = 1;

    protected override void Start()
    {
        Startpos =transform.GetChild(0).GetComponent<RectTransform>().position;
        MoveThreshold = moveThreshold;
        base.Start();
        //background.gameObject.SetActive(false);
       
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        background.gameObject.SetActive(true);
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        // background.gameObject.SetActive(false);
        Debug.Log("çek2");
        transform.GetChild(0).GetComponent<RectTransform>().position = Startpos;
        base.OnPointerUp(eventData);
    }

    protected override void HandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera cam)
    {
        if (magnitude > moveThreshold)
        {
            Vector2 difference = normalised * (magnitude - moveThreshold) * radius;
            //background.anchoredPosition += difference;

        }
        base.HandleInput(magnitude, normalised, radius, cam);
    }
}