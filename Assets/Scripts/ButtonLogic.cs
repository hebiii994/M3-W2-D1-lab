using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLogic : MonoBehaviour
{
    private bool _player1Inside = false;
    private bool _player2Inside = false;
    private bool _unlockBoxs = false;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] List<Rigidbody2D>  _listaRbBox = new List<Rigidbody2D>();


    // Start is called before the first frame update
    void Start()
    {
        if (_listaRbBox == null)
        {
            {
                Debug.Log("Associare un RigidBody al componente script");
            }

        }
        foreach (Rigidbody2D rbBox in _listaRbBox)
        {

            if (rbBox != null)
            {
                rbBox.gravityScale = 0;
            }
            else
            {
                Debug.LogWarning("ButtonLogic: Trovato un elemento null nella lista _listaRbBoxes.", this.gameObject);
            }

        }
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

        // Update is called once per frame
        void Update()
        {
            winConditionCheck(_player1Inside, _player2Inside);

            if (_unlockBoxs)
            {
                foreach (Rigidbody2D rbBox in _listaRbBox)
                {

                    if (rbBox != null)
                    {
                        rbBox.gravityScale = 1;
                    }
                    else
                    {
                        Debug.LogWarning("ButtonLogic: Trovato un elemento null nella lista _listaRbBoxes.", this.gameObject);
                    }

                }
            _spriteRenderer.color = Color.green;
        }
        }
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {

                _player1Inside = true;
                Debug.Log("Player 1 ha attivato il pulsante");

            }
            else if (collision.CompareTag("Player2"))
            {

                _player2Inside = true;
                Debug.Log("Player 2 ha attivato il pulsante");
            }




        }
    void winConditionCheck(bool player1, bool player2)
    {
        if (player1 || player2)
        {
            _unlockBoxs = true;

            
        }
    }
}

    

