using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;

    void Update()
    {
        inputVec.x = Input.GetAxis("Horizontal");
        inputVec.y = Input.GetAxis("Vertical");
    }
    
}
