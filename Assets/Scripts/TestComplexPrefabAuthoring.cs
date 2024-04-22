using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace GenerativeRoad.Scripts._DOTS._Component._Authoring._Test
{
    public class TestComplexPrefabAuthoring : MonoBehaviour
    {
        // public List<GameObject> children;

        public GameObject prefab;
        
        // ECS_Baker
        class TestComplexPrefabAuthoringBaker : Baker<TestComplexPrefabAuthoring>
        {
            public override void Bake(TestComplexPrefabAuthoring prefabAuthoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                var entityPrefab = GetEntity(prefabAuthoring.prefab, TransformUsageFlags.Dynamic);

                AddComponent(entity, new TestComplexPrefab
                {
                    rootPrefab = entityPrefab
                });
                
            }
        }
    }

    public struct TestComplexPrefab : IComponentData
    {
        public Entity rootPrefab;
    }

    public struct TestComplexPrefabContainer : IComponentData
    {
        
    }
}