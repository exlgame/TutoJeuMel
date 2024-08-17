using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    private bool isJumping = false;
    private bool isGrounded = false;

    void Update()
    {
        // D�tection de l'entr�e de saut dans Update pour garantir que chaque pression de touche est d�tect�e
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }
    }

    void FixedUpdate()
    {
        // Mouvement horizontal
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed;

        // D�tection du sol (ici, on utilise une version simplifi�e, mais vous pouvez utiliser un raycast pour plus de pr�cision)
        if (Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        // D�placement du joueur
        MovePlayer(horizontalMovement);
    }

    void MovePlayer(float _horizontalMovement)
    {
        // Appliquer le mouvement horizontal
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.05f);

        // Gestion du saut
        if (isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);  // R�initialiser la v�locit� verticale
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = false;
        }
    }
}
