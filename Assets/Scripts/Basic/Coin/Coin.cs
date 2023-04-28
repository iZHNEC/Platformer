using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioClip))]

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            Destroy(gameObject);
        }
    }
}