using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    public Image hurtImage;
    public LayerMask groundLayer;
    public Transform feet;
    public float speed = 7;
    public float gravity = -9.81f;
    public float jumpHeight = 2;
    
    private CharacterController controller;
    private float y;
    private bool isGrounded;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(feet.position, 0.4f, groundLayer);

        if (isGrounded) y = 0;
        
        var x = Input.GetAxisRaw("Horizontal");
        var z = Input.GetAxisRaw("Vertical");
        
        var move = (transform.right * x + transform.forward * z) * speed * Time.deltaTime;
        
        //jump
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            y = Mathf.Sqrt(jumpHeight * -2f * gravity) * Time.deltaTime;
        }
        
        //gravity
        y += gravity * Time.deltaTime * Time.deltaTime;
        move.y = y;
        
        controller.Move(move);
    }

    private void OnDrawGizmos()
    {
        if (feet != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(feet.position, 0.4f);
        }
    }

    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GetHurt()
    {
        hurtImage.color = new Color(1, 1, 1, hurtImage.color.a + 0.1f);
    }
}
