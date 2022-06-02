using UnityEngine;
using UnityEngine.Playables;

public class CameraMovementEffects : MonoBehaviour
{
    [SerializeField] private PlayableDirector _playableDirector;
    
    public void Move()
    {
        _playableDirector.Play();
    }
}
