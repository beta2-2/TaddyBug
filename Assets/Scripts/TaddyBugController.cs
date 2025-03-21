using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaddyBugController : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private Animator _animator;
    private float _angle;

    [SerializeField] private float _maxHeight;
    [SerializeField] private float _flapVelocity;
    [SerializeField] private float _relativeVelocityX;
    [SerializeField] private GameObject _sprite;

    private bool _isDead;
    public bool IsDead()
    {
        return _isDead;
    }

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _animator = _sprite.GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && transform.position.y < _maxHeight)
        {
            Flap();
        }

        ApplyAngle();
        _animator.SetBool("flapUp", _angle >= 0.0f);
        _animator.SetBool("flapDown", _angle < 0.0f);
        _animator.SetBool("hurt", _isDead);
    }

    public void Flap()
    {
        if (_isDead)
        {
            return;
        }

        if(_rb2d?.bodyType == RigidbodyType2D.Kinematic)
        {
            return;
        }

        if(_rb2d != null)
        {
            _rb2d.linearVelocity = new Vector2(0.0f, _flapVelocity);
        }

    }

    private void ApplyAngle()
    {
        var targetAngle = 0f;

        if (_isDead)
        {
            targetAngle = -90.0f;
        }
        else
        {
            targetAngle = Mathf.Atan2(_rb2d.linearVelocity.y * 0.1f, _relativeVelocityX) * Mathf.Rad2Deg;
        }
        _angle = Mathf.Lerp(_angle, targetAngle, Time.deltaTime * 10.0f);

        _sprite.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, _angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isDead)
        {
            return;
        }
        _isDead = true;
    }

    public void SetSteerActive(bool active)
    {
        if (_rb2d != null)
        {
            _rb2d.bodyType = active ? RigidbodyType2D.Dynamic : RigidbodyType2D.Kinematic;
        }
    }
}
