using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distance;
    [SerializeField] private Transform _groundDetection;
    
    private bool _movingRight = true;

    private void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(_groundDetection.position, Vector2.down, _distance);

        if (groundInfo.collider == false)
        {
            int newY = _movingRight? 180 : 0;
            _movingRight = !_movingRight;
            transform.eulerAngles = new Vector3(0,newY,0);
        }
    }
}
