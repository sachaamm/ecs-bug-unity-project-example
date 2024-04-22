using Unity.Entities;
using UnityEngine;

namespace GenerativeRoad.Scripts._DOTS._Component._Authoring
{
    public class PhysicsBallPrefabAuthoring : MonoBehaviour
    {
        public GameObject prefab;
        
        // ECS_Baker
        class PhysicsBallAuthoringBaker : Baker<PhysicsBallPrefabAuthoring>
        {
            public override void Bake(PhysicsBallPrefabAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new PhysicsBallPrefab
                {
                    prefab = GetEntity(authoring.prefab, TransformUsageFlags.Dynamic)
                });
            }
        }
    }
    
    public struct PhysicsBallPrefab : IComponentData
    {
        public Entity prefab;
    }
}