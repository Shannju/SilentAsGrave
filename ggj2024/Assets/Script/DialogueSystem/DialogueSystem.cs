using UnityEngine;
using System.Collections;
using Script.Mapping;

namespace Script.DialogueSystem
{
   
    public class DialogueSystem : MonoBehaviour
    {
        public float GenerateInterval = 10.0f;
        // 数值越大，停留时间越长；数值越小，停留时间越短。例如，如果您想让物品在每个位置停留10秒，可以将GenerateInterval设为10秒（10f）。
        public Transform spTrans01L; // 生成位置1
        public Transform spTrans02L; // 生成位置2
        public Transform spTrans03L;
        public Transform spTrans04L;
        public Transform spTrans05L;
        private Transform[] MovePositionsL;

        public Transform spTrans01LM; // 生成位置1
        public Transform spTrans02LM; // 生成位置2
        public Transform spTrans03LM;
        public Transform spTrans04LM;
        public Transform spTrans05LM;
        private Transform[] MovePositionsLM;

        public Transform spTrans01R; // 生成位置1
        public Transform spTrans02R; // 生成位置2
        public Transform spTrans03R;
        public Transform spTrans04R;
        public Transform spTrans05R;
        private Transform[] MovePositionsR;

        public Transform spTrans01RM; // 生成位置1
        public Transform spTrans02RM; // 生成位置2
        public Transform spTrans03RM;
        public Transform spTrans04RM;
        public Transform spTrans05RM;
        private Transform[] MovePositionsRM;

        public int healthG = 9;//绿条
        public int healthW = 9;
        public int healthGS = 6;//绿短条
        public int healthWS = 6;

        public GameObject WxMessageBoxPrefab;
        public GameObject WxMessageBoxPrefabShort;
        public GameObject WxWhiteBoxPrefab;
        public GameObject WxWhiteBoxPrefabShort;
        private bool KeyDown1 = false;
        private bool KeyDown2 = false;
        private bool KeyDown3 = false;
        private bool KeyDown4 = false;
        private bool isSpawning = false;
        private Vector3 currentTargetPosition;
        private GameObject item;
        private bool started = false;
        
        public float maxForce = 3.0f; // 设定力的上限值

        public float ForceTimes = 1f;
        public float moveDuration = 1.0f; // 协程中，平滑移动的距离。值越小，移动越快。
        void Awake()
        {
            EventManager.AddListener(GameEventType.GameStart, OnGameStart);
            EventManager.AddListener(GameEventType.GameOver, OnGameOver);
        }
        void Start()
        {
            MovePositionsL = new Transform[] { spTrans01L, spTrans02L, spTrans03L, spTrans04L, spTrans05L };
            MovePositionsLM = new Transform[] { spTrans01LM, spTrans02LM, spTrans03LM, spTrans04LM, spTrans05LM };
            MovePositionsR = new Transform[] { spTrans01R, spTrans02R, spTrans03R, spTrans04R, spTrans05R };
            MovePositionsRM = new Transform[] { spTrans01RM, spTrans02RM, spTrans03RM, spTrans04RM, spTrans05RM };
            if (WxMessageBoxPrefab != null)
            {
                // 获取Prefab的Transform组件，可以用来访问位置信息
                // WxMessageBoxPrefab = massageGreenObject.transform;
            }
            else
            {
                Debug.LogError("未找到WxMessageBoxPrefab GameObject");
            }
        }
        
        void Update()
        {
            if (started && !isSpawning) {
                StartCoroutine(SpawnRandomPrefabAfterRandomInterval());
                isSpawning = true; // 确保协程只启动一次
            }
            if (Input.GetKeyUp(KeyCode.Alpha0))
            {
                started = false;
            }
            else if (Input.GetKeyUp(KeyCode.Alpha9))
            {
                started = true;
            }
            if (started)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1) && !KeyDown1)// GREEN LONG
                {
                StartCoroutine(MoveAndDestroyItem(WxMessageBoxPrefab, MovePositionsR, healthG));
                KeyDown1 = true;
                Debug.Log("检测到按下1");
                }
                else if(Input.GetKeyUp(KeyCode.Alpha1))
                {
                    KeyDown1 = false;
                }

                if (Input.GetKeyDown(KeyCode.Alpha2) && !KeyDown2)// WHITE LONG
                {
                StartCoroutine(MoveAndDestroyItem(WxWhiteBoxPrefab, MovePositionsL, healthW));
                KeyDown2 = true;
                Debug.Log("检测到按下2");
                }
                else if(Input.GetKeyUp(KeyCode.Alpha2))
                {
                    KeyDown2 = false;
                }

                if (Input.GetKeyDown(KeyCode.Alpha3) && !KeyDown3)// GS
                {
                StartCoroutine(MoveAndDestroyItem(WxMessageBoxPrefabShort, MovePositionsRM, healthGS));
                KeyDown3 = true;
                Debug.Log("检测到按下3");
                }
                else if(Input.GetKeyUp(KeyCode.Alpha3))
                {
                    KeyDown3 = false;
                }
            
                if (Input.GetKeyDown(KeyCode.Alpha4) && !KeyDown4)// WS
                {
                StartCoroutine(MoveAndDestroyItem(WxWhiteBoxPrefabShort, MovePositionsLM, healthWS));
                KeyDown4 = true;
                Debug.Log("检测到按下4");
                }
                else if(Input.GetKeyUp(KeyCode.Alpha4))
                {
                    KeyDown4 = false;
                }

                if (item != null && currentTargetPosition != Vector3.zero) {
                // 计算并应用力
                /*
                Vector3 direction = currentTargetPosition - item.transform.position;
                float distance = direction.magnitude;
                Vector3 force = 5 * direction.normalized * Mathf.Min(1 / Mathf.Max(distance, 0.1f), maxForce);
                item.transform.position += force * Time.deltaTime;
                */
                }
            }
        }
        public GameObject SpawnPrefab(GameObject prefabToSpawn, Transform spawnPosition) // 生成预制体
        {
            Debug.Log("spawnPosition = " + spawnPosition.position);
            GameObject spawnedPrefab = Instantiate(prefabToSpawn, spawnPosition);
            return spawnedPrefab;
        }

        private IEnumerator SpawnRandomPrefabAfterRandomInterval() 
        {
            while (started) {
                float randomInterval = Random.Range(5f, 20f);
                yield return new WaitForSeconds(randomInterval);

                int prefabIndex = Random.Range(0, 4);
                GameObject selectedPrefab = null;
                switch (prefabIndex) {
                    case 0:
                        selectedPrefab = WxMessageBoxPrefab;
                        break;
                    case 1:
                        selectedPrefab = WxMessageBoxPrefabShort;
                        break;
                    case 2:
                        selectedPrefab = WxWhiteBoxPrefab;
                        break;
                    case 3:
                        selectedPrefab = WxWhiteBoxPrefabShort;
                        break;
                }

                if (selectedPrefab != null) {
                    // 这里需要确定预制体的生成位置，这里假设为spTrans01L，您可以根据需要调整
                    SpawnPrefab(selectedPrefab, spTrans01L);
                }
            }
        }


        private IEnumerator MoveAndDestroyItem(GameObject prefab, Transform[] positions, int health) {
            // 首先，在初始位置实例化物品
            item = SpawnPrefab(prefab, positions[0]);
            Animator itemAnimator = item.GetComponent<Animator>();
            // 遍历所有位置
            for (int i = 1; i < positions.Length; i++) 
            {
                currentTargetPosition = positions[i].position;
                Vector3 startPosition = item.transform.position;
                Vector3 endPosition = positions[i].position;
               /* itemAnimator.SetInteger("massageGreenChange", health);*/
                health--;

                // 检查动画状态并在适当时销毁物品
                if (health <= 0) {
                    // 等待消失动画完成
                    yield return new WaitForSeconds(0.5f);
                    Destroy(item);
                    break;
                }
                yield return new WaitForSeconds(GenerateInterval);
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


        private void GetmassageGreenPrefabPosition()
        {
            if (WxMessageBoxPrefab.transform != null)
            {
            Vector3 position = WxMessageBoxPrefab.transform.position;
            }
        }
        public void OnGameStart()
        {
            started = true;
        }
        public void OnGameOver()
        {
            started = false;
        }
        // 生成方向（绿色白色）
        // 生成哪一个预制体
        // 功能： Content 生成
    }
}