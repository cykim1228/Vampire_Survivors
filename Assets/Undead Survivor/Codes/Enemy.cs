using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    public float maxHealth;
    public RuntimeAnimatorController[] animCon;
    public Rigidbody2D target;

    bool isLive;

    Rigidbody2D rigid;
    Collider2D coll;
    Animator anim;
    SpriteRenderer spriter;
    WaitForFixedUpdate wait;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
        wait = new WaitForFixedUpdate();
    }

    void FixedUpdate()
    {
        // 죽으면 움직이지 않도록 아래 코드 실행 안함
        // GetCurrentAnimatorStateInfo = 현재 상태를 가져오는 함수
        if (!isLive || anim.GetCurrentAnimatorStateInfo(0).IsName("Hit")) {
            return;
        }

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
        if (!isLive) {
            return;
        }

        // 목표의 X축 값과 자신의 X축 값을 비교하여 작으면 true 가 되도록 설정
        spriter.flipX = target.position.x < rigid.position.x;
    }

    void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        isLive = true;
        coll.enabled = true;
        rigid.simulated = true;
        spriter.sortingOrder = 2;
        anim.SetBool("Dead", false);
        health = maxHealth;
    }

    public void Init(SpawnData data)
    {
        anim.runtimeAnimatorController = animCon[data.spriteType];
        speed = data.speed;
        maxHealth = data.health;
        health = data.health;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // 총알이 아니면 리턴
        // 사망 로직이 연달아 실행되는 것을 방지하기 위해 조건 추가
        if (!collision.CompareTag("Bullet") || !isLive) {
            return;
        }

        // 총알 데미지 가져오기
        health -= collision.GetComponent<Bullet>().damage;
        StartCoroutine(KnockBack());

        if (health > 0) {
            anim.SetTrigger("Hit");
        }
        else {
            isLive = false;
            coll.enabled = false;
            // 리지드바디2D 의 물리 연산 비활성화
            rigid.simulated = false;
            spriter.sortingOrder = 1;
            anim.SetBool("Dead", true);
            // 몬스터 사망 시 킬수 증가와 함께 경험치 함수 호출
            GameManager.instance.kill++;
            GameManager.instance.GetExp();
        }
    }

    // 코루틴 = 생명 주기와 비동기처럼 실행되는 함수
    IEnumerator KnockBack()
    {
        // 1프레임 대기
        // yield return null;

        // 2초 쉬기
        // yield return new WaitForSeconds(2f);

        // 다음 하나의 물리 프레임 딜레이이
        yield return wait;

        // 플레이어 위치 가져오기
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 dirVec = transform.position - playerPos;
        
        // 리지드바디2D 의 AddForce 함수로 힘 가하기 / 순간적인 힘을 주기 위해 Impulse 사용
        rigid.AddForce(dirVec.normalized * 3, ForceMode2D.Impulse);
    }

    void Dead()
    {
        gameObject.SetActive(false);
    }

}
