using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float jumpSpeed = 20;
    public float walkSpeed = 5;
    public float gravityPull = 100;
    public int HP = 10000;

    public Rigidbody2D rb;
    public ConstantForce2D simulatedGravity;
    public GameObject leftFallDetector;
    public GameObject rightFallDetector;
    public GameObject rightDetector;
    public GameObject leftDetector;

    public Vector2 gravityDirection;
    public int orientation = 0;             // 0 - horizontal; 1/-1 - vertical
    public bool isJumping = true;

    public float xSize;
    public float ySize;

    void Start()
    {
        // search GameObjects
        leftFallDetector = GameObject.Find("leftFallDetector");
        rightFallDetector = GameObject.Find("rightFallDetector");
        rightDetector = GameObject.Find("rightDetector");
        leftDetector = GameObject.Find("leftDetector");

        // get components
        rb = gameObject.GetComponent<Rigidbody2D>();
        simulatedGravity = gameObject.GetComponent<ConstantForce2D>();

        // turn off default rb gravity
        rb.gravityScale = 0;

        // setup custom graviy
        gravityDirection = new Vector2(0, -gravityPull);
        simulatedGravity.force = gravityDirection;

        positionDetectors();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            moveLeft();

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            moveRight();

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
            jump();


        checkFallDetectors();
        checkCollisionDetectors();
    }


    // movement functions
    void moveLeft()
    {
        // normal walking
        if (orientation == 0)
        {
            rb.velocity = new Vector2(-walkSpeed, rb.velocity.y);
        }
        // wall climbing
        else
        {
            if (orientation == -1)
                rb.velocity = new Vector2(rb.velocity.x, walkSpeed);
            else
                rb.velocity = new Vector2(rb.velocity.x, -walkSpeed);
        }
    }
    void moveRight()
    {
        // normal walking
        if (orientation == 0)
        {
            rb.velocity = new Vector2(walkSpeed, rb.velocity.y);
        }
        // wall climbing
        else
        {
            if (orientation == -1)
                rb.velocity = new Vector2(rb.velocity.x, -walkSpeed);
            else
                rb.velocity = new Vector2(rb.velocity.x, walkSpeed);
        }
    }
    void jump()
    {
        // already jumping
        if (isJumping)
            return;

        isJumping = true;
        // normal walking
        if (orientation == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
        // wall climbing
        else
        {
            if (orientation == -1)
                rb.velocity = new Vector2(jumpSpeed, rb.velocity.y);
            else
                rb.velocity = new Vector2(-jumpSpeed, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;

        // ground hit
        if (tag == "Ground" || tag == "Wall")
        {
            isJumping = false;
        }
    }

    void rotateHorizontally(int dir)
    {
        orientation = dir;

        if (dir == 1)
        {
            Debug.Log("rotateHorizontally(1)");
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            gravityDirection = new Vector2(gravityPull, 0);
        }
        else
        {
            Debug.Log("rotateHorizontally(-1)");
            gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
            gravityDirection = new Vector2(-gravityPull, 0);
        }

        simulatedGravity.force = gravityDirection;
    }
    void rotateVertically()
    {
        if (orientation == -1 || orientation == 1)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            Vector3 zAxis = new Vector3(0, 0, 1);
            Vector3 rightCorner = rightFallDetector.transform.position;
            gameObject.transform.RotateAround(rightCorner, zAxis, -90);
            gameObject.transform.position += new Vector3(xSize, 0, 0);
            isJumping = true;
        }

        orientation = 0;
        gravityDirection = new Vector2(0, -gravityPull);
        simulatedGravity.force = gravityDirection;
    }
    void rotateOnLeftFoot()
    {
        Debug.Log("rotateOnLeftFoot");

        Vector2 leftCorner = leftFallDetector.transform.position;
        Vector3 zAxis = new Vector3(0, 0, 1);
        gameObject.transform.RotateAround(leftCorner, zAxis, 90);

        if (orientation == 0)
            orientation = 1;
        else
            orientation = 0;


        gravityDirection = calculateDownVector();
        simulatedGravity.force = gravityDirection * gravityPull;

        Vector3 relativeLeft = calculateRightVector() * -1;
        gameObject.transform.position += relativeLeft * xSize;
        isJumping = true;
    }
    void rotateOnRightFoot()
    {
        Debug.Log("rotateOnRightFoot");

        Vector2 rightCorner = rightFallDetector.transform.position;
        Vector3 zAxis = new Vector3(0, 0, 1);
        gameObject.transform.RotateAround(rightCorner, zAxis, -90);

        if (orientation == 0)
            orientation = -1;
        else
            orientation = 0;

        gravityDirection = calculateDownVector();
        simulatedGravity.force = gravityDirection * gravityPull;

        Vector3 relativeRight = calculateRightVector();
        gameObject.transform.position += relativeRight * xSize;
        isJumping = true;
    }


    void positionDetectors()
    {
        BoxCollider2D b = gameObject.GetComponent<BoxCollider2D>();
        Vector3 center = b.bounds.center;
        Vector3 scaleFactor = gameObject.transform.localScale;
        xSize = b.size.x * scaleFactor.x;
        ySize = b.size.y * scaleFactor.y;

        Vector3 bottomLeftPosition = new Vector3(center.x - xSize / 2, center.y - ySize / 2 - 0.1f, 0);
        Vector3 bottomRightPosition = new Vector3(center.x + xSize / 2, center.y - ySize / 2 - 0.1f, 0);
        Vector3 centerLeftPosition = new Vector3(center.x - xSize / 2 - 0.1f, center.y, 0);
        Vector3 centerRightPosition = new Vector3(center.x + xSize / 2 + 0.1f, center.y, 0);

        leftFallDetector.transform.position = bottomLeftPosition;
        rightFallDetector.transform.position = bottomRightPosition;
        leftDetector.transform.position = centerLeftPosition;
        rightDetector.transform.position = centerRightPosition;
    }
    void checkFallDetectors()
    {
        if (checkFallDetector(leftFallDetector))
        {
            Debug.Log("left fall detector triggered");
            if (orientation == 0 || orientation == -1)
                rotateOnLeftFoot();
            else
                rotateHorizontally(1);
        }
        else if (checkFallDetector(rightFallDetector))
        {
            Debug.Log("right fall detector triggered");
            if (orientation == 0 || orientation == 1)
                rotateOnRightFoot(); // rotate on right foot down
            else
                rotateVertically();
        }
    }
    bool checkFallDetector(GameObject detector)
    {
        if (isJumping)
            return false;

        Vector2 relativeDown = calculateDownVector();
        Vector2 position = detector.transform.position;

        return Physics2D.Raycast(position, relativeDown, 0.5f).collider == null;
    }
    void checkCollisionDetectors()
    {
        Vector2 right = calculateRightVector();
        Vector2 left = right * -1;
        Vector2 leftDetectorPosition = leftDetector.transform.position;
        Vector2 rightDetectorPosition = rightDetector.transform.position;

        // left collision
        if (Physics2D.Raycast(leftDetectorPosition, left, 0.1f).collider != null && Physics2D.Raycast(leftDetectorPosition, left, 0.1f).collider.gameObject.tag != "Interactable")
        {
            Debug.Log("left collision");
            if (orientation == 0)
                rotateHorizontally(-1);
            else
                rotateVertically();
        }

        // right collision
        else if (Physics2D.Raycast(rightDetectorPosition, right, 0.1f).collider != null && Physics2D.Raycast(rightDetectorPosition, right, 0.1f).collider.gameObject.tag != "Interactable")
        {
            Debug.Log("right collision");
            if (orientation == 0)
                rotateHorizontally(1);
            else
                rotateVertically();
        }
    }



    Vector3 calculateDownVector()
    {
        Vector2 down;

        if (orientation == 0)
            down = new Vector3(0, -1);
        else if (orientation == 1)
            down = new Vector3(1, 0);
        else
            down = new Vector3(-1, 0);

        return down;
    }
    Vector3 calculateRightVector()
    {
        Vector2 right;

        if (orientation == 0)
            right = new Vector3(1, 0);
        else if (orientation == 1)
            right = new Vector3(0, 1);
        else
            right = new Vector3(0, -1);

        return right;
    }


    public void getDamage( int i)
    {
        HP-=i;
        Debug.Log(HP);
        if(HP <= 0)
        {
            Debug.Log("AI MURIT");
            Destroy(this.gameObject);

        }
    }

    public int getHP() { return HP; }
}