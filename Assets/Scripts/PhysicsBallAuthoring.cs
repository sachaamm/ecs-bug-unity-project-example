using Unity.Entities;
using UnityEngine;

namespace GenerativeRoad.Scripts._DOTS._Component._Authoring
{
    public class PhysicsBallAuthoring : MonoBehaviour
    {
        // ECS_Baker
        class PhysicsBallAuthoringBaker : Baker<PhysicsBallAuthoring>
        {
            public override void Bake(PhysicsBallAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new PhysicsBall());
            }
        }
    }

    public struct PhysicsBall : IComponentData
    {
        
    }
}