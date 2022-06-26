using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilAnimation : MonoBehaviour
{
    [SerializeField] private GameObject _oilTemplate;

    private float _timeBetweenOilsCreating = 0.08f;
    private float _speed = 5.5f;
    private float _localScaleMultiplier = 0.965f;
    private List<Vector3> _points = new List<Vector3>();
    private List<GameObject> _oilTemplates = new List<GameObject>();
    private bool _isCreating = true;

    public void StartOilAnimation(List<Vector3> points)
    {
        if (_points.Count > 0)
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
        while (_isCreating)
        {
            GameObject oil = Instantiate(_oilTemplate, transform.position, Quaternion.identity);
            _oilTemplates.Add(oil);
            StartCoroutine(AnimateOil(oil));
            yield return new WaitForSeconds(_timeBetweenOilsCreating);
        }
    }

    private IEnumerator AnimateOil(GameObject oil)
    {
        int currantPoint = 1;
        while (currantPoint < _points.Count)
        {

            Vector3 target = _points[currantPoint];
            oil.transform.position = Vector3.MoveTowards(oil.transform.position, target, _speed);
            if (oil.transform.position == target)
            {
                oil.transform.localScale *= _localScaleMultiplier;
                currantPoint++;
                if(currantPoint >= _points.Count)
                {
                    
                }
            }
            yield return null;
        }
        Destroy(oil);

    }

    public void StopOilAnimation()
    {
        _isCreating = false;
    }
}