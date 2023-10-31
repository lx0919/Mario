using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public enum Type
    {
        Coin,
        ExtraLife,
        MagicMushroom,
        Starpower,
    }

    public Type type;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Collect(other.gameObject);
        }
    }

    private void Collect(GameObject player)
    {
        switch (type)
        {
            case Type.Coin:
                GameManager.Instance.AddCoin();
                break;
            
            case Type.ExtraLife:
                GameManager.Instance.AddLife();
                break;
            
            case Type.MagicMushroom:
                player.GetComponent<MarioPlayer>().Grow();
                break;
            
            case Type.Starpower:
                player.GetComponent<MarioPlayer>().StarPower();
                break;
        }

        Destroy(gameObject);
    }
}