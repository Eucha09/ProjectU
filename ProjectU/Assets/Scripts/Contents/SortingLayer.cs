using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SortingLayer : MonoBehaviour
{
    SortingGroup _sortingLayer;

    void Start()
    {
        _sortingLayer = GetComponent<SortingGroup>();
    }

    void Update()
    {
        _sortingLayer.sortingOrder = -(int)(transform.position.y * 10.0f);
    }
}
