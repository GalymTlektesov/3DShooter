using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;

    [SerializeField]
    private float lookSpeed = 3.0f;
    private PlayerMotor motor;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 movHor = transform.right * xMov;
        Vector3 movVer = transform.forward * zMov;

        Vector3 velocity = (movHor + movVer).normalized * speed;

        motor.Move(velocity);

        float yRow = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3(0.0f, yRow, 0.0f) * lookSpeed;

        motor.Rotate(rotation);

        float xRow = Input.GetAxisRaw("Mouse Y");
        Vector3 camRotation = new Vector3(xRow, 0.0f, 0.0f) * lookSpeed;

        motor.RotateCam(camRotation);
    }
}
