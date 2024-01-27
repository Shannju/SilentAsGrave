using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class massageWhite : MonoBehaviour
{
    public Transform spTrans01; // 生成位置1
    public Transform spTrans02; // 生成位置2
    public Transform spTrans03;
    public Transform spTrans04;
    public Transform spTrans05;
    private Transform[] MovePositions;
    public GameObject WxmassageGreen_Short;
    public float GenerateInterval = 10.0f;
    
    public int healthMassageWhite = 9;
    private bool KeyDown = false;
    private Animator animator;

    public float moveDuration = 1.0f; // 协程中，平滑移动的距离。值越小，移动越快。
    [SerializeField] private Collider2D col;
    void Start()
    {
        animator = GetComponent<Animator>();
        MovePositions = new Transform[] { spTrans01, spTrans02, spTrans03, spTrans04, spTrans05 };
    }
    void Update()
    {
        animator.SetInteger("massageWhiteChange", healthMassageWhite);
        if (Input.GetKeyUp(KeyCode.Q))
        {
            ReduceBoxLevel();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && !KeyDown)
            {
            StartCoroutine(MoveAndDestroyItem(WxmassageGreen_Short, MovePositions));
            KeyDown = true;
            Debug.Log("检测到按下2");
            }
            else if(Input.GetKeyUp(KeyCode.Alpha2))
            {
                KeyDown = false;
            }
        
    }
    public GameObject SpawnPrefab(GameObject prefabToSpawn, Transform spawnPosition) // 生成预制体
        {
            Debug.Log("spawnPosition = " + spawnPosition.position);
            GameObject spawnedPrefab = Instantiate(prefabToSpawn, spawnPosition);
            return spawnedPrefab;
        }
        private IEnumerator MoveAndDestroyItem(GameObject prefab, Transform[] positions) {
            // 首先，在初始位置实例化物品
            GameObject item = SpawnPrefab(prefab, positions[0]);

            // 遍历所有位置
            for (int i = 1; i < positions.Length; i++) 
            {
                Vector3 startPosition = item.transform.position;
                Vector3 endPosition = positions[i].position;
                float elapsedTime = 0;

                while (elapsedTime < moveDuration) 
                    {
                    float t = Mathf.SmoothStep(0.0f, 1.0f, elapsedTime / moveDuration);
                    item.transform.position = Vector3.Lerp(startPosition, endPosition, t);
                    elapsedTime += Time.deltaTime;
                    yield return null;
                    }
                // 确保物品完全移动到目标位置
                item.transform.position = endPosition;

                // 在每个位置停留指定时间
                yield return new WaitForSeconds(GenerateInterval);
            }
            // 最后一个位置的等待
            yield return new WaitForSeconds(GenerateInterval);

            // 销毁物品
            Destroy(item);
        }
    public void ReduceBoxLevel()
    {
        healthMassageWhite -= 1;
        if (healthMassageWhite <= 0)
        {
            col.enabled = false;
        }
    }
}
