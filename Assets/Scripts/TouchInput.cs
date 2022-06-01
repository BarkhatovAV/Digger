using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    [SerializeField] private List<Stone> _stones = new List<Stone>();
    [SerializeField] private Collider _collider;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _radius;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(_collider.Raycast(ray, out hit, 1000f))
            {

                Vector3 randomPart = Random.insideUnitCircle * _radius;
                Vector3 stonePosition = new Vector3(hit.point.x + randomPart.x, hit.point.y + randomPart.y, 0.4f);
                Instantiate(_stones[1], stonePosition, Quaternion.identity);
            }

        }
    }
}
