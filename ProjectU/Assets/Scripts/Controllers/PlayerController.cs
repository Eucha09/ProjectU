using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    [SerializeField]
    float _moveSpeed = 1.5f;

    public Vector3 Move { get; set; }

    public override void Init()
    {

    }

    protected override void UpdateIdle()
    {
        if (Move != Vector3.zero)
            State = Define.State.Moving;
    }

    protected override void UpdateMoving()
    {
        if (Move == Vector3.zero)
            State = Define.State.Idle;

        if (Move.x < 0.0f)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else if (Move.x > 0.0f)
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        transform.Translate(Move * _moveSpeed * Time.deltaTime);
    }
}
