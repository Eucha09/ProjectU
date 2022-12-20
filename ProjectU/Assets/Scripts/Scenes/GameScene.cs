using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    GameObject _player;
    CameraController _camera;

    public override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;

        _player = Managers.Resource.Instantiate("Player");
        Managers.UI.ShowSceneUI<UI_GameController>();

        _camera = Camera.main.GetComponent<CameraController>();
        _camera.SetPlayer(_player);
        _camera.SetQuarterView(new Vector3(0.0f, 0.0f, -10.0f));

        GameObject monster = Managers.Resource.Instantiate("Monster1");
        monster.transform.position = new Vector3(-1.5f, -1.5f, 0.0f);
    }

    public override void Clear()
    {

    }
}
