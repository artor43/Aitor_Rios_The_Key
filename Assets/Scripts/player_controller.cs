using JetBrains.Annotations;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public float velocidad = 10f;
    float horizontalMove;
    float verticalMove;
    CharacterController cc;
    public float gravedad = -9.81f;
    public float velocidadVertical = 0f;
    float moneda;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        if (cc.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocidadVertical = 2.5f;
            }
        }
        velocidadVertical += gravedad * Time.deltaTime;
        

        Vector3 direction = new Vector3(horizontalMove, velocidadVertical, verticalMove);
        cc.Move(direction * velocidad * Time.deltaTime);
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("coin"))
        {
            //sumar 1 a la moneda
            moneda += 1;
            //mostrar en consola texto de cuantas monedas tienes
            Debug.Log("moneda" + moneda);
            //destruir moneda
            Destroy(hit.gameObject);
        }
        
        Debug.Log("Collided with: " + hit.gameObject.name);
    }
}
