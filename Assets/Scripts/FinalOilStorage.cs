using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalOilStorage : OilStorage
{

    [SerializeField] private Transform _bezierPoint2;
    [SerializeField] private Transform _bezierPoint3;

    public Transform BezierPoint2 => _bezierPoint2;
    public Transform BezierPoint3 => _bezierPoint3;

    private CircleCollider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<CircleCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerCollision player))
        {
            _collider.isTrigger = false;
        }
    }
}
