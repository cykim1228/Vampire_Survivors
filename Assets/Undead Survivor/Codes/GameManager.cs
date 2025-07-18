using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // 인스펙터의 속성들을 이쁘게 구분시켜주는 타이틀
    [Header("# Game Control")]
    public float gameTime;
    public float maxGameTime = 2 * 10f;

    [Header("# Player Info")]
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = {10, 30, 60, 100, 150, 210, 280, 360, 450, 600};

    [Header("# Game Object")]
    public PoolManager pool;
    public Player player;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        gameTime += Time.deltaTime;

        if(gameTime > maxGameTime) {
            gameTime = maxGameTime;
        }
    }

    public void GetExp()
    {
        exp++;

        if(exp == nextExp[level]) {
            level++;
            exp = 0;
        }
    }

}
