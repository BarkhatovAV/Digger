using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilAnimation : MonoBehaviour
{
    [SerializeField] private GameObject _oilTemplate;

    private float _timeBetweenOilsCreating = 0.15f;
    private List<Vector3> _points = new List<Vector3>();
    private List<GameObject> _oilTemplates = new List<GameObject>();
    private float _timeBetweenPoints = 0.014f;
    private bool _isCreating = true;

    public void StartOilAnimation(List<Vector3> points)
    {
        if(_points.Count > 0)
        {
            _points = points;
        }
        else
        {
            for (int i = points.Count - 1; i > 0; i--)
            {
                _points.Add(points[i]);
            }
        }
        _isCreating = true;
        StartCoroutine(CreateOilTemlaits());
    }

    private IEnumerator CreateOilTemlaits()
    {
        while(_isCreating)
        {
            GameObject oil = Instantiate(_oilTemplate, transform.position, Quaternion.identity);
            _oilTemplates.Add(oil);
            StartCoroutine(MoveOil(oil));
            yield return new WaitForSeconds(_timeBetweenOilsCreating);
        }
    }

    private IEnumerator MoveOil(GameObject oil)
    {
        for (int i = 0; i < _points.Count - 1; i++)
        {
            oil.transform.position = _points[i];
            yield return new WaitForSeconds(_timeBetweenPoints);
        }
        Destroy(oil);
    }

    public void StopOilAnimation()
    {
        _isCreating = false;
    }
}
