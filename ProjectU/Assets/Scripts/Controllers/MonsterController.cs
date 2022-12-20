using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : BaseController
{
    [SerializeField]
    float _moveSpeed = 1.0f;

    [SerializeField]
    float _attackRange = 0.5f;

    public override void Init()
    {
        _lockTarget = GameObject.Find("Player");
    }

    protected override void UpdateIdle()
    {
        if (_lockTarget != null)
            State = Define.State.Moving;
    }

    protected override void UpdateMoving()
    {
        if (_lockTarget != null)
        {
            _destPos = _lockTarget.transform.position;
            float distance = (_destPos - transform.position).magnitude;
            if (distance <= _attackRange)
            {
                State = Define.State.Attack;
                return;
            }
        }

        // 이동
        Vector3 dir = _destPos - transform.position;

        if (dir.x < 0.0f)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else if (dir.x > 0.0f)
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        transform.Translate(dir.normalized * _moveSpeed * Time.deltaTime);
    }

    protected override void UpdateAttack()
    {
        if (_lockTarget != null)
        {
            Vector3 dir = _lockTarget.transform.position - transform.position;
            if (dir.x < 0.0f)
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            else if (dir.x > 0.0f)
                transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
    }
}
