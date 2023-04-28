using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Vector2 _moveVector;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _jampForce = 15f;
    [SerializeField] private Transform GroundChek;
    [SerializeField] private LayerMask Ground;
    [SerializeField] private float _checkRadius = 0.5f;
    
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private bool _faceRight = false;
    private bool _onGround;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void Update()
    {
        Walk();
        Reflect();
        Jump();
        CheckingGround();
    }

    private void Walk()
    {
        const string constMoveX = "moveX";
        const string constHorizontal = "Horizontal";
        
        _moveVector.x = Input.GetAxis(constHorizontal);
        _animator.SetFloat(constMoveX, Mathf.Abs(_moveVector.x));
        _rigidbody.velocity = new Vector2(_moveVector.x * _speed, _rigidbody.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && _onGround)
        {
            _rigidbody.AddForce(Vector2.up * _jampForce);
        }
    }
    
    private void Reflect()
    {
        if ((_moveVector.x > 0 && !_faceRight) || (_moveVector.x < 0 && _faceRight))
        {
            transform.localScale *= new Vector2(-1, 1);
            _faceRight = !_faceRight;
        }
    }

    private void CheckingGround()
    {
        const string constOnGround = "onGround";
        
        _onGround = Physics2D.OverlapCircle(GroundChek.position, _checkRadius, Ground);
        _animator.SetBool(constOnGround,_onGround);
    }
}
