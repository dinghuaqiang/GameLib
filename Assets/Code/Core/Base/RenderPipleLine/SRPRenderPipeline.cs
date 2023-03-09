using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace Code.Core.Base
{
    [CreateAssetMenu(menuName = "SRP/SRPRenderPipelineAssets")]
    public class SRPRenderPipeline : RenderPipelineAsset
    {
        protected override IRenderPipeline InternalCreatePipeline()
        {
            throw new NotImplementedException();
        }
    }

    public class SkyBoxPipleline : RenderPipeline
    {
        public override void Render(ScriptableRenderContext renderContext, Camera[] cameras)
        {
            base.Render(renderContext, cameras);
            foreach (var camera in cameras)
            {
                renderContext.SetupCameraProperties(camera);
                renderContext.DrawSkybox(camera);
            }
            renderContext.Submit();
        }
    }
}
