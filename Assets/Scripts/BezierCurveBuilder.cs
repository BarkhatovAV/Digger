using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurveBuilder : MonoBehaviour
{
    [SerializeField] private Transform _bezierPoint0;
    [SerializeField] private Transform _bezierPoint1;
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private int _segmentsNumber = 40;
    [SerializeField] private OilAnimation _oilAnimation;

    private float _timeBetweenNewLinePosition = 0.01f;
    private float _removeDalay = 0.6f;
    private float _width = 0.33f;
    private int _currentSegmtntsNumber = 12;
    private int _startSegmtntsNumber;
    private Transform _bezierPoint2;
    private Transform _bezierPoint3 ;
    private List<Vector3> _bezierPoints = new List<Vector3>();

    private void Start()
    {
        _startSegmtntsNumber = _currentSegmtntsNumber;
    }

    public void DrowLine(Transform bezierPoint2, Transform bezierPoint3)
    {
        _bezierPoint2 = bezierPoint2;
        _bezierPoint3 = bezierPoint3;

        for (int i = 0; i < _segmentsNumber; i++)
        {
            float lerpParemeter = (float)i / _segmentsNumber;
            Vector3 point = Bezier.GetPoint(_bezierPoint0.position, _bezierPoint1.position, _bezierPoint2.position, _bezierPoint3.position, lerpParemeter);
            _bezierPoints.Add(point);
        }
        _oilAnimation.StartOilAnimation(_bezierPoints);
        StartCoroutine(StartDrow());
    }

    private IEnumerator RemoveSmoothly()
    {
        yield return new WaitForSeconds(_removeDalay);
        while (_lineRenderer.positionCount > 0)
        {
            _lineRenderer.positionCount--;
            yield return new WaitForSeconds(_timeBetweenNewLinePosition);
        }
        _bezierPoints.Clear();
    }

    public void DeleteLine()
    {
        _oilAnimation.StopOilAnimation();
        StartCoroutine(RemoveSmoothly());
    }

    private IEnumerator StartDrow()
    {
        while (_currentSegmtntsNumber < _segmentsNumber)
        {
            _currentSegmtntsNumber++;
            _lineRenderer.positionCount = _currentSegmtntsNumber;
            _lineRenderer.widthMultiplier = _width;
            for (int i = 0; i < _currentSegmtntsNumber; i++)
            {
                _lineRenderer.SetPosition(i, _bezierPoints[i]);
            }
            yield return new WaitForSeconds(_timeBetweenNewLinePosition);
        }
        _currentSegmtntsNumber = _startSegmtntsNumber;
    }
}
