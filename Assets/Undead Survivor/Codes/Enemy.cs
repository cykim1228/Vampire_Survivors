using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Rigidbody2D target;

    bool isLive = true;

    Rigidbody2D rigid;
    SpriteRenderer spriter;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        // 죽으면 움직이지 않도록 아래 코드 실행 안함
        if (!isLive)
            return;

        // 목표 위치와 현재 위치의 차이
        Vector2 dirVec = target.position - rigid.position;
        // 방향 벡터 정규화
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        // 현재 위치 + 다음 위치 = 이동할 위치
        rigid.MovePosition(rigid.position + nextVec);
        // 물리 속도가 이동에 영향을 주지 않도록 속도 제거
        rigid.linearVelocity = Vector2.zero;
    }

    void LateUpdate()
    {
        if (!isLive)
            return;

        // 목표의 X축 값과 자신의 X축 값을 비교하여 작으면 true 가 되도록 설정
        spriter.flipX = target.position.x < rigid.position.x;
    }

    void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
    }

}
