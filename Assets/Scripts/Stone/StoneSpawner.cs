using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawner : MonoBehaviour
{
    [SerializeField] private List<Stone> _stones = new List<Stone>();
    [SerializeField] private Collider _collider;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _radius;

    private float _maxDistance = 1000f;
    private float _fadeInStonesDalay = 0.1f;
    private bool _canInstantiate = true;
    private float _offsetY = 0.2f;
    private float _stonePositionY = 0.4f;
    private Vector3 _stonePosition;

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (_collider.Raycast(ray, out hit, _maxDistance))
            {
                Vector3 randomPart = Random.insideUnitCircle * _radius;
                _stonePosition = new Vector3(hit.point.x + randomPart.x, hit.point.y + randomPart.y + _offsetY, _stonePositionY);
                if (_canInstantiate)
                {
                    _canInstantiate = false;
                    StartCoroutine(FadeInStones());
                }
            }
        }
    }

    private IEnumerator FadeInStones()
    {
        for (int i = 0; i < _stones.Count; i++)
        {
            Instantiate(_stones[i], _stonePosition, Quaternion.identity);
            yield return new WaitForSeconds(_fadeInStonesDalay);
        }
        _canInstantiate = true;
    }
}
