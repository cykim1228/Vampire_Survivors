using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // 프리팹들을 보관할 변수
    public GameObject[] prefabs;

    // 풀 담당을 하는 리스트들
    List<GameObject>[] pools;

    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length]; 

        // 반복문을 통해 모든 오브젝트 풀 리스트를 초기화
        for(int index = 0; index < pools.Length; index++) {
            pools[index] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        // 선택한 풀의 놀고 있는 (비활성화 된) 게임 오브젝트 접근
        foreach(GameObject item in pools[index]) {
            // 비활성화 된 오브젝트 탐색
            if(!item.activeSelf) {
                // 발견하면 select 변수에 할당
                select = item;
                select.SetActive(true);
                break;
            }
        }

        // 못 찾았으면?
        if(!select) {
            // 새롭게 생성하고 select 변수에 할당
            // Instantiate : 새로운 오브젝트를 생성하는 함수
            // 첫 번째 인자 : 생성할 프리팹
            // 두 번째 인자 : 생성할 위치
            // 세 번째 인자 : 생성할 오브젝트의 부모
            select = Instantiate(prefabs[index], transform);
            // 생성된 오브젝트는 해당 오브젝트 풀 리스트에 Add 함수로 추가
            pools[index].Add(select);
        }

        return select;
    }
}
