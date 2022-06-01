using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaturalOilStorage : OilStorage
{
    [SerializeField] private Transform _bezierPoint2;
    [SerializeField] private Transform _bezierPoint3;

    public Transform BezierPoint2 => _bezierPoint2;
    public Transform BezierPoint3 => _bezierPoint3;
}
