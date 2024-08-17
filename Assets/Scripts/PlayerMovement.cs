using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public bool isJumping = false;
    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    public float jumpforce;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        if(Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }

        MovePlayer(horizontalMovement);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targerVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targerVelocity, ref velocity, 0.05f);

        if (isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpforce));
            isJumping = false;
        }
    }
}