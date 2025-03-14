using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f; //Vitesse de déplacement en float
    public float moveDirectionX = 0f; 
    public float jumpForce = 7f; //Puissance du saut

    public Transform groundCheck; 

    public float groundCheckRadius = 0.2f; 

    public bool isGrounded = false; 
    public LayerMask listGroundLayers;
    public int maxAllowedJumps = 2;
    public int currentNumberJumps= 0;

    private bool isFacingRight = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDirectionX = Input.GetAxis("Horizontal"); //Récupère un float de la direction dans laquel le jouer essaie de diriger (bouton Q et D, fleche gauche et droite et Joystick)
        /*if (Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }*/
        if(Input.GetButtonDown("Jump") && currentNumberJumps < maxAllowedJumps) {           //Si le joueur clique sur le bouton de saut il saute
            Jump();
            currentNumberJumps +=1;
        }

        if (isGrounded && !Input.GetButton("Jump")) {
            currentNumberJumps = 0;
        }
        Flip();
    }

    private void Jump() {
        rb.linearVelocity = new Vector2 (
            rb.linearVelocity.x,
            jumpForce
        );
    }
    private void FixedUpdate() {
        rb.linearVelocity = new Vector2 (
            moveDirectionX * moveSpeed,
            rb.linearVelocity.y
        );
        isGrounded =IsGrounded();
    }

    private bool IsGrounded () {
        return Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            listGroundLayers
        );
    }
    private void OnDrawGizmos() {
        if(groundCheck != null) {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(
                groundCheck.position,
                groundCheckRadius
            );
        }
    }

    private void Flip() {
        if ((moveDirectionX > 0 && !isFacingRight) || (moveDirectionX < 0 && isFacingRight)) {
            transform.Rotate(0,180,0);
            isFacingRight = !isFacingRight;
        } 
    }
}
