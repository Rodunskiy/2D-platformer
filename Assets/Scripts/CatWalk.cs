using UnityEngine;

public class CatWalk : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    private float _jumpForce = 9;
    private float inputHorizontal;
    private float _speed = 2;

    private Animator _animator;

    private bool _facingRight = true;
    private bool _isGrounded;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        _animator.SetBool("isWalking", false);

        if (inputHorizontal != 0)
        {
            _animator.SetBool("isWalking", true);
            transform.Translate(inputHorizontal * _speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rb.AddForce(new Vector2(_rb.velocity.x, _jumpForce), ForceMode2D.Impulse);
        }

        if (inputHorizontal > 0 && !_facingRight)
        {
            Flip();
        }
        else if (inputHorizontal < 0 && _facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        Vector2 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;

        _facingRight = !_facingRight;
    }
}

