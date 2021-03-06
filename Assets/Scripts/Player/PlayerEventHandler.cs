using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BezierCurveBuilder))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerCollision))]
[RequireComponent(typeof(OilStorage))]
public class PlayerEventHandler : MonoBehaviour
{
    [SerializeField] private CameraMovementEffects _cameraMover;

    private PlayerCollision _playerCollision;
    private PlayerMover _playerMover;
    private BezierCurveBuilder _playerBezier;
    private OilStorage _playerOilStorage;
    private bool _isFinalOilStorage = false;

    public event UnityAction PlayerFinished;

    private void Awake()
    {
        _playerBezier = GetComponent<BezierCurveBuilder>();
        _playerOilStorage = GetComponent<OilStorage>();
        _playerCollision = GetComponent<PlayerCollision>();
        _playerMover = GetComponent<PlayerMover>();
    }

    private void OnEnable()
    {
        _playerCollision.FinalOilStorageCollised += OnFinalOilStorageCollised;
        _playerOilStorage.FuelFilled += OnFuelFilled;
        _playerCollision.NaturalOilDepositCollised += OnNaturalOilDepositCollised;
        _playerCollision.GroundCollised += OnPlayerGrounded;
    }


    private void OnDisable()
    {
        _playerCollision.FinalOilStorageCollised -= OnFinalOilStorageCollised;
        _playerOilStorage.FuelFilled -= OnFuelFilled;
        _playerCollision.NaturalOilDepositCollised -= OnNaturalOilDepositCollised;
        _playerCollision.GroundCollised -= OnPlayerGrounded;
    }

    private void OnFinalOilStorageCollised(FinalOilStorage finalOilStorage)
    {
        _playerBezier.DrowLine(finalOilStorage.BezierPoint2, finalOilStorage.BezierPoint3);
        _playerMover.StopMoving();
        _cameraMover.Move();
        _isFinalOilStorage = true;
    }

    private void OnFuelFilled()
    {
        _playerBezier.DeleteLine();
        if (_isFinalOilStorage == true)
        {
            PlayerFinished?.Invoke();
            _playerMover.Rotate();
        }
        else
        {
            _playerMover.Run();
        }
    }

    private void OnPlayerGrounded()
    {
        _playerMover.Land();
    }

    private void OnNaturalOilDepositCollised(NaturalOilStorage naturalOilStorage)
    {
        _playerBezier.DrowLine(naturalOilStorage.BezierPoint2, naturalOilStorage.BezierPoint3);
        _playerMover.StopMoving();
    }
}
