using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Vector3 startPosition;
    public Rigidbody2D rb;
    
    [SerializeField]
    private GameController _gameController;
    [SerializeField]
    private BallController _ballController;

    private float movement;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");

        // If the game has not started then move the ball with the paddle
        if (!_gameController.isStarted)
        {
            // When the user presses the space bar (jump), launch the ball
            if (Input.GetButtonDown("Jump"))
            {
                if (!_gameController.isStarted)
                {
                    _ballController.LaunchBall();
                    _gameController.isStarted = true;
                    _gameController.isPaused = false;
                }
            }
        }

        if (Input.GetButtonDown("Jump"))
        {
            _ballController.TestBrickHit();
        }
    }

    private void FixedUpdate()
    {
        var velocity = new Vector2(movement * speed, rb.velocity.y);
        rb.velocity = velocity;

        // If the game has not started then move the ball with the paddle
        if (!_gameController.isStarted)
        {
            _ballController.SetVelocity(velocity);
        }
    }

    public void ResetPlayer()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
    }
}
