using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float arrowMinX;
    public float arrowMaxX;
    public float playerMovementSpeed;
    public float throwForce;

    [SerializeField]
    private Transform throwingArrow;
    [SerializeField]
    private Animator arrowAnimator;
    [SerializeField]
    private Rigidbody[] bowlingBallPrefabs;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private SoundManager soundManager;

    private Vector3 bowlingBallOffset;
    private bool wasBallThrown;
    private Rigidbody selectedBowlingBall;
    private float horizontalAxis;

    void Start()
    {
        wasBallThrown = false;

        bowlingBallOffset = spawnPoint.position - throwingArrow.position;

    }

    
    void Update()
    {
        TryMoveArrow();
        TryThrowBall();
    }

    /// <summary>
    /// Try to move the throwing arrow horizontally on the X axis
    /// </summary>
    public void TryMoveArrow()
    {
        if (!wasBallThrown)
        {
            // moving the arrow
#if UNITY_STANDALONE || UNITY_EDITOR
            float movePosition = Input.GetAxis("Horizontal") * Time.deltaTime * playerMovementSpeed;
#elif UNITY_ANDROID || UNITY_IOS
            float movePosition = horizontalAxis * playerMovementSpeed * Time.deltaTime;
#endif
            
            float horizontalValue = Mathf.Clamp(throwingArrow.position.x + movePosition, arrowMinX, arrowMaxX);
            throwingArrow.position = new Vector3(horizontalValue, throwingArrow.position.y, throwingArrow.position.z);   // theres a little movement you can correct in the z direction

            // moving the bowling ball
            selectedBowlingBall.transform.position = throwingArrow.position + bowlingBallOffset;
        }
    }

    /// <summary>
    /// Method called when we begin to throw the bowling ball
    /// </summary>
    public void StartThrow()
    {
        arrowAnimator.SetBool("Aiming", true);
        wasBallThrown = false;

        // pick a random ball and create it
        selectedBowlingBall = Instantiate(bowlingBallPrefabs[Random.Range(0, bowlingBallPrefabs.Length)], spawnPoint.position, Quaternion.identity );

    }

    /// <summary>
    /// If the space bar was pressed, try to throw the bowling ball
    /// </summary>
    public void TryThrowBall()
    {
        // throw the ball

        if (Input.GetKeyDown(KeyCode.Space))
        {
            wasBallThrown = true;

            selectedBowlingBall.AddForce(throwingArrow.forward * throwForce, ForceMode.Impulse);
            arrowAnimator.SetBool("Aiming", false);
            soundManager.PlaySound("throw");
            soundManager.PlaySound("roll");
        }

    }

    public void ThrowBall()
    {
        wasBallThrown = true;
        selectedBowlingBall.AddForce(throwingArrow.forward * throwForce, ForceMode.Impulse);
        arrowAnimator.SetBool("Aiming", false);
        soundManager.PlaySound("throw");
        soundManager.PlaySound("roll");
    }

    public void SetHorizontal(bool isleft)
    {
        if (isleft)
        {
            horizontalAxis = -1;
        }
        else
        {
            horizontalAxis = 1;
        }
    }

    public void ResetHorizontal()
    {
        horizontalAxis = 0;
    }
}
