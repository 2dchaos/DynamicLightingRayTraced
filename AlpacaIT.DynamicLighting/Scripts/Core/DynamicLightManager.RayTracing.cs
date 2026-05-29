using UnityEngine;
using UnityEngine.Rendering;

namespace AlpacaIT.DynamicLighting
{
    // implements raytracing.

    public partial class DynamicLightManager
    {
        private RayTracingAccelerationStructure raytracingAccelerationStructure;

        /// <summary>Initialization of the DynamicLightManager.Raytracing partial class.</summary>
        private void RaytracingInitialize()
        {
            RayTracingAccelerationStructure.Settings settings = new RayTracingAccelerationStructure.Settings();
            settings.rayTracingModeMask = RayTracingAccelerationStructure.RayTracingModeMask.Everything;
            settings.managementMode = RayTracingAccelerationStructure.ManagementMode.Automatic;
            settings.layerMask = 255;

            raytracingAccelerationStructure = new RayTracingAccelerationStructure(settings);
            raytracingAccelerationStructure.Build();
            Shader.SetGlobalRayTracingAccelerationStructure("g_AccelStruct", raytracingAccelerationStructure);
        }

        /// <summary>Cleanup of the DynamicLightManager.LightCookie partial class.</summary>
        private void RaytracingCleanup()
        {
            if (raytracingAccelerationStructure != null)
            {
                raytracingAccelerationStructure.Dispose();
                raytracingAccelerationStructure = null;
            }
        }

        /// <summary>Called before the lights are processed for rendering.</summary>
        private void RaytracingUpdate()
        {
            if (raytracingAccelerationStructure != null)
            {
                raytracingAccelerationStructure.Build();
            }
        }
    }
}
