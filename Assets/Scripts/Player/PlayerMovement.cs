using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody rb;
    private Animator anim;
    public Animator backpackAnim;
    public DynamicJoystick joystick;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Movement();
    }
    private void Movement()
    {
        Vector3 directionVector = new Vector3(joystick.Horizontal , rb.velocity.y, joystick.Vertical);
        if(directionVector.magnitude > Mathf.Abs(0.1f))
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(directionVector), Time.deltaTime * 10);

        rb.velocity = directionVector * (speed * Time.deltaTime);
        if(rb.velocity.x != 0 || rb.velocity.z != 0)
            backpackAnim.SetBool("Running", true);
        else
            backpackAnim.SetBool("Running", false);
        anim.SetFloat("Speed", Vector3.ClampMagnitude(directionVector, 1).magnitude);
    }
    
    public void Chop(string action)
    {
        anim.SetBool(action, true);
    }
    public void ExitChop(string action)
    {
        anim.SetBool(action, false);
    }
}
