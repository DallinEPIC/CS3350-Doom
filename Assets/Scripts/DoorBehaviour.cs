using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using static UnityEngine.ParticleSystem;

public class DoorBehaviour : MonoBehaviour
{
    [SerializeField] private float _timeToOpen, _timeToStayOpen, _openHeight;
    private bool _doorMoving;
    private float _timeElapsed;
    private readonly float FPS = 30; //Num of jumps door makes in a second
    public void Open()
    {
        if (_doorMoving) return;
        _doorMoving = true;
        StartCoroutine(OpenDoor());
    }
    private IEnumerator OpenDoor()
    {
        while(_timeElapsed < _timeToOpen)
        {
            yield return new WaitForSeconds(1/FPS);
            _timeElapsed += 1/FPS;
            transform.position += new Vector3(0, (_openHeight / (FPS * _timeToOpen)), 0);
        }
        yield return new WaitForSeconds(_timeToStayOpen);
        _timeElapsed = 0;
        StartCoroutine(CloseDoor());
    }

    private IEnumerator CloseDoor()
    {
        while (_timeElapsed < _timeToOpen)
        {
            yield return new WaitForSeconds(1/FPS);
            _timeElapsed += 1/FPS;
            transform.position -= new Vector3(0, _openHeight / (FPS * _timeToOpen), 0);
        }
        _timeElapsed = 0;
        _doorMoving = false;
    }
}
