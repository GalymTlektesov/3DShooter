using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : NetworkBehaviour
{
    public Weapon weapon;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    public Text text;
    private LayerMask mask;

    void Start()
    {
        if(cam == null)
        {
            Debug.LogError("No camera");
            this.enabled = false;
        }
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    [Client]
    private void Shoot()
    {
        RaycastHit _hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, weapon.range, mask))
        {
            if(_hit.collider.CompareTag("Player"))
            {
                CmdPlayerShoot(_hit.collider.name, weapon.damage);
            }
        }
    }

    [Command]
    void CmdPlayerShoot(string _ID, float damage)
    {
        text.text = gameObject.name + " выстрелил в " + _ID;
        Player player = GameManager.GetPlayer(_ID);
        player.TakeDamage(damage);
        Invoke("TextClear", 3.0f);
    }

    void TextClear()
    {
        text.text = "";
    }
}
