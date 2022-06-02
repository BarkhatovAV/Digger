using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    public event UnityAction<FinalOilStorage> FinalOilStorageCollised;
    public event UnityAction<NaturalOilStorage> NaturalOilDepositCollised;
    public event UnityAction GroundCollised;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out NaturalOilStorage naturaloilStorage))
        {
            NaturalOilDepositCollised?.Invoke(naturaloilStorage);
        }

        if (collision.TryGetComponent(out FinalOilStorage finalOilStorage))
        {
            FinalOilStorageCollised?.Invoke(finalOilStorage);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.TryGetComponent(out DestructibleBlock destructibleBlock)) || (collision.gameObject.TryGetComponent(out Road road)))
        {
            GroundCollised?.Invoke();
        }
    }
}
