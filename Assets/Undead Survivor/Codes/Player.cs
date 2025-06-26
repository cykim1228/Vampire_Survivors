using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;

    public float speed;

    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // inputVec.x = Input.GetAxis("Horizontal");
        // inputVec.y = Input.GetAxis("Vertical");

        // 부드럽게 이동 (GetAxis 는 보정이 들어감)
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");

    }

    void FixedUpdate()
    {
        // // 1. 힘을 준다
        // rigid.AddForce(inputVec);
        
        // // 2. 속도 제어
        // rigid.linearVelocity = inputVec;

        // normalized 는 대각선 이동 시 피타고라스 정의 에 의해 루트 2 가 되도록 해줌
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;

        // 3. 위치 이동
        rigid.MovePosition(rigid.position + nextVec);

    }
    
}
