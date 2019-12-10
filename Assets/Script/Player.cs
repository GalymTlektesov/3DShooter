using UnityEngine.Networking;
using UnityEngine;

public class Player : NetworkBehaviour
{
    [SerializeField]
    private float maxHealth = 100.0f;

    [SyncVar]
    private float currtHealth;

    void Awake()
    {
        currtHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currtHealth -= damage;
    }
}
