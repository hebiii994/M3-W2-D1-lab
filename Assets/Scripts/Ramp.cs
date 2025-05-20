using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramp : MonoBehaviour
{
    [SerializeField] private float minRange = 10f;
    [SerializeField] public bool isActive = false;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Vector2 _attachPosition;
    [SerializeField] private Vector2 _playerPosition;
    [SerializeField] private Vector2 _newPosition;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] float _jumpForce = 5f;
    private bool _isPressed = false;
    private float _rampSpeed = 15f;
    private float _distance;

    
    // Start is called before the first frame update
    void Start()
    {
        if (_gameObject == null)
        {
            Debug.Log("Inserire il gameobject nel component");

        }
        if (_rb == null)
        {
            Debug.Log("Manca il RigidBody");
        }
        _attachPosition = transform.position;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        _playerPosition = _rb.position;
        _distance = Vector2.Distance(_playerPosition, _attachPosition);

        if (_distance < minRange)
        {
            _spriteRenderer.color = Color.green;
            Debug.Log("Premi [F] per utilizzare il rampino");
        }
        else if (_distance > minRange)
        {
            _spriteRenderer.color = Color.red;
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            _isPressed = true;
        }


    }

    private void FixedUpdate()
    {
        if (_isPressed && _spriteRenderer.enabled)
        {
            _rb.velocity = Vector2.zero;
            _playerPosition = _rb.position;
            _distance = Vector2.Distance(_playerPosition, _attachPosition);

            if(_distance > 1f)
            {
                Vector2 direction = (_attachPosition - _playerPosition).normalized;
                _newPosition = Vector2.MoveTowards(_playerPosition, _attachPosition, _rampSpeed * Time.fixedDeltaTime);
                _rb.MovePosition(_newPosition);
            }
            else
            {
                _rb.velocity = Vector2.zero;
                _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                _isPressed = false;
                Debug.Log("Salto Eseguito!");
            }

            
        }
    }
}
