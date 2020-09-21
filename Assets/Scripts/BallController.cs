using UnityEngine;
using UnityEngine.Tilemaps;

public class BallController : MonoBehaviour
{
    public float ballSpeed;


    public GameObject tilemapGameObject;


    //public TileBase tileBase;

    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private GameController _gameController;

    private Vector3 startPosition;
    private Tilemap tilemap;

    void Start()
    {
        startPosition = transform.position;


        if (tilemapGameObject != null)
        {
            tilemap = tilemapGameObject.GetComponent<Tilemap>();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 hitPosition = Vector3.zero;

        if (tilemap != null && tilemapGameObject == collision.gameObject)
        {
            foreach (ContactPoint2D hit in collision.contacts)
            {
                hitPosition.x = hit.point.x + 0.01f * hit.normal.x;
                hitPosition.y = hit.point.y - 0.01f * hit.normal.y;


                //Debug.Log($"What is blah? = {hit.point.x}, {hit.point.y}");

                var position = tilemap.WorldToCell(hitPosition);


                Debug.Log($"World cell - x: {position.x} | y: {position.y} | z: {position.z}");


                var brick = tilemap.GetTile(position);

                tilemap.SetTile(position, null);



                //tilemap.SetTile(tilemap.WorldToCell(hitPosition), tileBase);
                //tilemap.SetTileFlags(position, TileFlags.None);
                //tilemap.RefreshAllTiles();
                //tilemap.SetColor(position, new Color(0.9820799f, 0.6273585f, 1));
                //var bsd = tilemap.GetTile(tilemap.WorldToCell(hitPosition));
                //Destroy(bsd);
                //var blah = collision.gameObject.GetComponent<Tile>();
                //Destroy(blah);
            }
        }



        /*



        if (collision.gameObject.name.ToLower() == "tilemapbricks")
        {
            //var x = collision.gameObject.transform.position.x;
            //var y = collision.gameObject.transform.position.y;
            //Debug.Log($"What is blah? = {x}, {y}");
            
            var blah = collision.gameObject.GetComponent<Tile>();

            Destroy(blah);
        }

        if (collision.gameObject.name.ToLower() == "scorevoid")
        {
            //Debug.Log("Lost life!");
            _gameController.PlayerLostBall();
        }*/

        if (collision.gameObject.name.ToLower() == "player")
        {
            float x = hitFactor(transform.position,
                         collision.transform.position,
                         collision.collider.bounds.size.x);

            // Calculate direction, set length to 1
            Vector2 dir = new Vector2(x, 1).normalized;

            // Set Velocity with dir * speed
            rb.velocity = dir * ballSpeed;
        }

        float hitFactor(Vector2 ballPos, Vector2 paddlePos, float paddleWidth)
        {
            // ascii art:
            //
            // 1  -0.5  0  0.5   1  <- x value
            // ===================  <- racket
            //
            return (ballPos.x - paddlePos.x) / paddleWidth * 2;
        }
    }

    public void TestBrickHit()
    {

    }


    public void ResetBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = new Vector3(0, startPosition.y);
    }

    public void LaunchBall()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(ballSpeed * x, -ballSpeed);
    }

    public void SetVelocity(Vector2 velocity)
    {
        rb.velocity = velocity;
    }
}
