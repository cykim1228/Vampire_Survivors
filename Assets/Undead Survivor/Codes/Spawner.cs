using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public SpawnData[] spawnData;

    int level;
    float timer;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        // 한 프레임이 소모한 시간을 계속 더하기
        timer += Time.deltaTime;
        // FloorToInt : 소수점 아래는 버리고 정수로 변환
        // CellToInt : 소수점 아래는 올리고 정수로 변환
        level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / 10f), spawnData.Length - 1);

        if(timer > spawnData[level].spawnTime) {
            timer = 0;
            Spawn();
        }

        void Spawn() {
            // 풀 함수에 랜덤 인자값을 넣어서 변수에 담기   
            GameObject enemy = GameManager.instance.pool.Get(0);
            // 랜덤 인덱스 값을 통해 랜덤 스폰 포인트 위치에 생성 (자기 자신은 제외하므로 1부터 시작)
            enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
            enemy.GetComponent<Enemy>().Init(spawnData[level]);
        }

        // if(Input.GetButtonDown("Jump")) {
        //     // 게임매니저의 인스턴스까지 접근하여 풀링의 함수 호출
        //     GameManager.instance.pool.Get(1);
        // }
    }
}

// 직렬화
[System.Serializable]
public class SpawnData
{
    public float spawnTime;
    public int spriteType;
    public int health;
    public float speed;
}