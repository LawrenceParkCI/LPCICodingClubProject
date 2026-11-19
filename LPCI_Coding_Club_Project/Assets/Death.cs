using System.Collections;

using UnityEngine;

public class Death : MonoBehaviour
{
    bool dead = false;
    [SerializeField] private float deathTime = 2f;
    [SerializeField] private Transform respawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
           if (!dead)
           {
                StartCoroutine(deathCycle(collision));
           }
        }
    }

    private IEnumerator deathCycle(Collider2D collision)
    {
        dead = true;
        PlayerMovement movement = collision.gameObject.GetComponent<PlayerMovement>();
        Rigidbody2D playerRig = collision.gameObject.GetComponent<Rigidbody2D>();
        movement.enabled = false;
        playerRig.constraints = RigidbodyConstraints2D.None;
        yield return new WaitForSeconds(deathTime);
        dead = false;
        movement.enabled = true;
        playerRig.constraints = RigidbodyConstraints2D.FreezeRotation;
        collision.transform.rotation = Quaternion.identity;
        collision.transform.position = respawnPoint.position;
    }
}
