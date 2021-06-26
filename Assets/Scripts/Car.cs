using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] const string FinishLineTag = "FinishLine";

    public CarType carType;

    [SerializeField] float acceleration;
    [SerializeField] float velocity;

    [SerializeField] int movementModifier = 0;

    [SerializeField] Vector2 initialPosition;

    private float currentVelocity;

    private Rigidbody2D carBody;
    private PlayPause playPauseManager;

    private void Start()
    {
        carBody = GetComponent<Rigidbody2D>();
        playPauseManager = PlayPause.instance;

        initialPosition = transform.position;
        currentVelocity = velocity;

        PlayPause.ERestart += Reset;
        PlayPause.EPlayStateChanged += SetMovement;
    }

    private void OnDisable()
    {
        PlayPause.ERestart -= Reset;
        PlayPause.EPlayStateChanged -= SetMovement;
    }

    private void FixedUpdate()
    {

        currentVelocity += acceleration * Time.fixedDeltaTime * movementModifier;

        carBody.velocity = Vector2.up * currentVelocity * movementModifier;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(FinishLineTag))
        {
            Finished();
        }
    }

    private void Finished()
    {
        movementModifier = 0;
    }

    private void SetMovement(PlayState current)
    {
        if (current == PlayState.PLAY)
        {
            movementModifier = 1;
        }
        else
        {
            movementModifier = 0;
        }
    }

    private void Reset()
    {
        transform.position = initialPosition;
        currentVelocity = velocity;
    }
}
