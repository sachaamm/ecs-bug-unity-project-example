using GenerativeRoad.Scripts._DOTS._Component._Authoring._Test;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace GenerativeRoad.Scripts._DOTS._System._Test
{
    public partial class TestComplexPrefabSystem : SystemBase
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            RequireForUpdate<TestComplexPrefab>();
        }

        protected override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                var testComplexPrefab = GetSingleton<TestComplexPrefab>();
                GameObject camGo = Camera.main.gameObject;
                Vector3 pos = camGo.transform.position + camGo.transform.forward * 3;

                InstantiateAtPos(testComplexPrefab.rootPrefab, pos, quaternion.identity);

            }

        }

        void InstantiateAtPos(Entity prefab, float3 pos, quaternion rot)
        {
            var entity = EntityManager.Instantiate(prefab);

            // Set LocalTransform position
            var lt = EntityManager.GetComponentData<LocalTransform>(entity);
            lt.Position += new Unity.Mathematics.float3(pos.x, pos.y, pos.z);
            lt.Rotation = rot;
            EntityManager.SetComponentData(entity, lt);
        }

    }
}
