using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [Header("Stats")]
    [Range(1,20)]public float movementSpeed = 5f;
    [Range(1,20)]public float jumpForce = 5f;
    [Space(50)]
    private Rigidbody rb;
    private Transform cameraTransform;
    [Header("NewTest")]
    [SerializeField] private bool isGrounded = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform;
    }
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0f;
        Vector3 movement = (cameraForward.normalized * moveVertical + cameraTransform.right.normalized * moveHorizontal).normalized;
        rb.velocity = new Vector3(movement.x * movementSpeed, rb.velocity.y, movement.z * movementSpeed);
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Untagged"))
        {
            isGrounded = true;
        }
    }
}