using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    [SerializeField] private float _jumpForce = 20;
    [SerializeField] Transform _ground;
    [SerializeField] LayerMask _collisionMask;

    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");

        _rb.velocity = new Vector2(h * _speed, _rb.velocity.y);
        if (Input.GetButton("Jump") && IsGrounded())
            _rb.AddForce(new Vector2(0, _jumpForce));
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_ground.position, 0.1f, _collisionMask);
    }
}
