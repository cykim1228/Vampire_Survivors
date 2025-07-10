using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;
    public int prefabId;
    public float damage;
    public int count;
    public float speed;

    void Start()
    {
        Init();
    }

    void Update()
    {
        switch (id) {
            case 0:
                // 속도나 움직임 등은 델타타임을 꼭 넣어주자
                transform.Rotate(Vector3.back * speed * Time.deltaTime);
                break;

            default:
                break;
        }

        // 테스트 코드
        if (Input.GetButtonDown("Jump")) {
            LevelUp(20, 5);
        }
    }

    public void LevelUp(float damage, int count)
    {
        this.damage = damage;
        this.count += count;

        if (id == 0) {
            // 속성 변경과 동시에 근접무기의 경우 총알 배치 재배치
            Batch();
        }
    }

    public void Init()
    {
        // 무기 ID 에 따라 로직 분류
        switch (id) {
            case 0:
                speed = 150;
                Batch();
                break;

            default:
                break;
        }
    }

    void Batch()
    {
        for (int index = 0; index < count; index++) {
            Transform bullet;
            
            if (index < transform.childCount) {
                // index 가 아직 childCount 범위 내라면 GetChild 함수로 가져오기
                bullet = transform.GetChild(index);
            } else {
                // 기존 오브젝트를 먼저 활용하고 모자란 것을 풀링으로 가져오기
                bullet = GameManager.instance.pool.Get(prefabId).transform;
                bullet.parent = transform;
            }

            // 배치 초기화
            bullet.localPosition = Vector3.zero;
            bullet.localRotation = Quaternion.identity;

            Vector3 rotVec = Vector3.forward * 360 * index / count;
            bullet.Rotate(rotVec);
            bullet.Translate(bullet.up * 1.5f, Space.World);

            // 근접 무기는 관통이 당연히 되므로 per 값은 -1 로 설정 (무한 관통)
            bullet.GetComponent<Bullet>().Init(damage, -1);
        }
    }
}
