using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    public event UnityAction<NaturalOilDeposit> NaturalOilDepositCollised;
    public event UnityAction GroungCollised;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out NaturalOilDeposit _naturaloilStorage))
        {
            NaturalOilDepositCollised?.Invoke(_naturaloilStorage);
            //Debug.Log("PlayerCollision NaturalOilDeposit");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.TryGetComponent(out DestructibleBlock destructibleBlock))|| (collision.gameObject.TryGetComponent(out Road road)))
        {
            GroungCollised?.Invoke();

            //Debug.Log("PlayerCollision DestructibleBlock");
        }
    }
}
