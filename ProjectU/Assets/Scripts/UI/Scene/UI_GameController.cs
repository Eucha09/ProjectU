using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_GameController : UI_Scene
{
    enum Images
    {
        Joystickback,
        Joystick
    }

    RectTransform _rectBack;
    RectTransform _rectJoystick;

    PlayerController _player;

    float _radius;
    float _sqr = 0f;

    public override void Init()
    {
        base.Init();

        Bind<Image>(typeof(Images));

        _rectBack = GetImage((int)Images.Joystickback).gameObject.GetComponent<RectTransform>();
        _rectJoystick = GetImage((int)Images.Joystick).gameObject.GetComponent<RectTransform>();

        BindEvent(gameObject, OnDrag, Define.UIEvent.Drag);
        BindEvent(gameObject, OnPointerUp, Define.UIEvent.PointerUp);

        _player = GameObject.Find("Player").GetComponent<PlayerController>();

        _radius = _rectBack.rect.width * 0.5f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 v = new Vector2(eventData.position.x - _rectBack.position.x, eventData.position.y - _rectBack.position.y);

        v = Vector2.ClampMagnitude(v, _radius);
        _rectJoystick.localPosition = v;

        // 비율
        float sqr = (_rectBack.position - _rectJoystick.position).sqrMagnitude / (_radius * _radius);

        Vector2 normal = v.normalized;

        _player.Move = new Vector3(normal.x * sqr, normal.y * sqr, 0.0f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // 원래 위치로 되돌립니다.
        _rectJoystick.localPosition = Vector2.zero;
        _player.Move = Vector3.zero;
    }
}
