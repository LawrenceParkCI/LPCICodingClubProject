using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rig;
    [SerializeField] private float walkSpeed = 2f;
    [SerializeField] private float jumpHeight = 5f;
    private bool canJump = true;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float speedX = Input.GetAxisRaw("Horizontal");
        rig.linearVelocityX = speedX * walkSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canJump)
            {
                canJump = false;
                rig.linearVelocityY = jumpHeight;
                StartCoroutine(jumpCD(2));
            }
        }
    }

    private IEnumerator jumpCD(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        canJump = true;
    }
}
