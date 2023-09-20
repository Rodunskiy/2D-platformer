using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private Transform _monster;
    [SerializeField] private List<Transform> _pathPoints = new();

    private Transform _target;
    private Transform _enemy;
    private float _speed = 2f;
    private int _currentPoint = 0;

    private void Start()
    {
        _target = _pathPoints[_currentPoint + 1];
        _enemy = Instantiate(_monster, _pathPoints[_currentPoint].position, Quaternion.identity);
    }

    private void Update()
    {
        _enemy.position = Vector2.MoveTowards(_enemy.position, _target.position, _speed * Time.deltaTime);

        if (_enemy.position == _target.position)
        {
            if (_currentPoint == 0)
            {
                _currentPoint = 1;
            }
            else
            {
                _currentPoint = 0;
            }

            _target = _pathPoints[_currentPoint];
        }
    }
}
