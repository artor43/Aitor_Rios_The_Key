using JetBrains.Annotations;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    
    public float velocidad = 10f;
    float horizontalMove;
    float verticalMove;
    CharacterController cc;
    
    
    
    void Start()
    {
       cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        Vector3 direction =new Vector3(horizontalMove, 0, verticalMove);
        cc.Move(direction* velocidad * Time.deltaTime);
    }
}
