using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] float _speed = 5f;
    [SerializeField] float _jumpForce = 8f;
    [SerializeField] private int _playerNumber;
    private bool _isJumping = false;
    private Vector2 _startPosition;
    private int _jumpCount1 = 0;
    private int _jumpCount2 = 0;
    
    private float h;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _startPosition = _rb.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerNumber == 1)
        {
            if (Input.GetButtonDown("P1Jump"))
            {
                _isJumping = true;

            }
            Debug.Log(_jumpCount1);
        }
        if (_playerNumber == 2)
        {
            if (Input.GetButtonDown("P2Jump"))
            {
                _isJumping = true;

            }
            Debug.Log(_jumpCount2);
        }
        
        
    }

     void FixedUpdate()
    {
        string p1 = "P1Horizontal";
        string p2 = "P2Horizontal";
        h = 0f;
        
        if (_playerNumber == 1)
        {
             h = Input.GetAxis(p1);
        }
        if (_playerNumber == 2)
        {
             h = Input.GetAxis(p2);
        }
            


        // gestisco movimento per un platform
        Vector2 direction = new Vector2(h, 0);
        Vector2 velocity = _rb.velocity;
        velocity.x = direction.x * _speed;
        _rb.velocity = velocity;

        //creo una logica per il doppiosalto
        if (_isJumping && _playerNumber == 1)
        {
            if (_jumpCount1 < 2)
            {
                velocity = _rb.velocity;
                velocity.y = 0;
                _rb.velocity = velocity;
                _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                _jumpCount1++;
            }
            
            _isJumping=false;

        }
        if (_isJumping && _playerNumber == 2)
        {
            if (_jumpCount2 < 2)
            {
                velocity = _rb.velocity;
                velocity.y = 0;
                float debuffJump = _jumpForce - 1.2f;
                _rb.velocity = velocity;
                _rb.AddForce(Vector2.up * debuffJump, ForceMode2D.Impulse);
                _jumpCount2++;
            }

            _isJumping = false;
        }
        
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        // resetto la variabile che tiene conto del numero dei salti
        Debug.Log("onCollisionEnter2d");
        _jumpCount1 = 0;
        _jumpCount2 = 0;
    }
}
