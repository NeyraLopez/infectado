using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 10f;

    private CharacterController controller;
    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, 0, v);

        Vector2 input = new Vector2(h, v);
        float movementAmount = input.magnitude;
        movementAmount = Mathf.Clamp01(movementAmount);

        // ANIMACIONES

        animator.SetFloat("Speed", movementAmount);
        animator.SetFloat("MotionSpeed", 1f);

        // MOVIMIENTO
        if (movementAmount > 0.1f)
        {
            move = move.normalized;

            controller.Move(move * speed * Time.deltaTime);

            Quaternion rotation = Quaternion.LookRotation(move);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                rotation,
                rotationSpeed * Time.deltaTime
            );
        }
        //Debug.Log("Speed: " + movementAmount);
        //Debug.Log($"H: {h} V: {v} Magnitude: {movementAmount}");
        animator.SetFloat("MotionSpeed", 1f);
    }
}