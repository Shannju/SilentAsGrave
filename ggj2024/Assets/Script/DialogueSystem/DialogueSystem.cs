using UnityEngine;
using System.Collections;

namespace Script.DialogueSystem
{
   
    public class DialogueSystem : MonoBehaviour
    {
        public float GenerateInterval = 10.0f;
        // 数值越大，停留时间越长；数值越小，停留时间越短。例如，如果您想让物品在每个位置停留10秒，可以将GenerateInterval设为10秒（10f）。
        public Transform spTrans01; // 生成位置1
        public Transform spTrans02; // 生成位置2
        public Transform spTrans03;
        public Transform spTrans04;
        public Transform spTrans05;
        private Transform[] MovePositions;

        public GameObject WxMessageBoxPrefab;
        public GameObject WxMessageBoxPrefabShort;
        public GameObject WxWhiteBoxPrefab;
        public GameObject WxWhiteBoxPrefabShort;
        private bool KeyDown = false;
        public float moveDuration = 1.0f; // 协程中，平滑移动的距离。值越小，移动越快。
        void Start()
        {
            MovePositions = new Transform[] { spTrans01, spTrans02, spTrans03, spTrans04, spTrans05 };

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
            if (Input.GetKeyDown(KeyCode.Alpha1) && !KeyDown)
            {
            StartCoroutine(MoveAndDestroyItem(WxMessageBoxPrefab, MovePositions));
            KeyDown = true;
            Debug.Log("检测到按下1");
            }
            else if(Input.GetKeyUp(KeyCode.Alpha1))
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


        private void GetmassageGreenPrefabPosition()
        {
            if (WxMessageBoxPrefab.transform != null)
            {
            Vector3 position = WxMessageBoxPrefab.transform.position;
            }
        }

        // 生成方向（绿色白色）
        // 生成哪一个预制体
        // 功能： Content 生成
    }
}