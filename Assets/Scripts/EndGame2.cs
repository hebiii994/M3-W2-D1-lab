using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame2 : MonoBehaviour
{
    private bool _player1Inside = false;
    private bool _player2Inside = false;
    private bool winCondition = false;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log($"il {collision.name} ha raggiunto la posizione");
            _player1Inside=true;

        }
        else if (collision.CompareTag("Player2"))
        {
            Debug.Log($"il {collision.name} ha raggiunto la posizione");
            _player2Inside = true;
        }

        winConditionCheck(_player1Inside,_player2Inside);

        if (winCondition)
        {
            Debug.Log("Avete Vinto!");
        }
    }


    void winConditionCheck(bool player1, bool player2)
    {
        if (player1 && player2)
        {
            winCondition = true;
        }
    }
}
