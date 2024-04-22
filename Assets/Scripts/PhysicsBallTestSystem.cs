using GenerativeRoad.Scripts._DOTS._Component._Authoring;
using Unity.Entities;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;

namespace GenerativeRoad.Scripts._DOTS._System._Physics
{
    public partial class PhysicsBallTestSystem : SystemBase
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            RequireForUpdate<PhysicsBallPrefab>();
        }

        protected override void OnUpdate()
        {
            if(Input.GetKeyDown(KeyCode.Keypad8))
            {
                var physicsBallAuthoring = GetSingleton<PhysicsBallPrefab>();
                var entity = EntityManager.Instantiate(physicsBallAuthoring.prefab);

                var p = Camera.main.gameObject;

                EntityManager.SetComponentData(entity, new LocalTransform
                {
                    Position = p.transform.position + p.transform.forward + new Vector3(0, 1, 0),
                    Rotation = p.transform.rotation,
                    Scale = 1
                });

                // Add force to the ball
                EntityManager.SetComponentData(entity, new PhysicsVelocity
                {
                    Linear = p.transform.forward * 20
                });


            }
        }
    }
}
