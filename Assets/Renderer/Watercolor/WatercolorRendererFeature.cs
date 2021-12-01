using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class WatercolorRendererFeature : ScriptableRendererFeature
{
    [SerializeField] Material watercolorGlobalEffectMaterial;

    class CustomRenderPass : ScriptableRenderPass
    {
        Material material;
        RenderTargetIdentifier source;
        RenderTargetHandle tempTexture;

        public CustomRenderPass(Material material) : base()
        {
            this.material = material;
            tempTexture.Init("_TempWatercolorTexture");
        }

        public void SetSource(RenderTargetIdentifier source)
        {
            this.source = source;
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            CommandBuffer cmd = CommandBufferPool.Get("WatercolorRendererFeature");

            RenderTextureDescriptor cameraTextureDesc = renderingData.cameraData.cameraTargetDescriptor;
            cameraTextureDesc.depthBufferBits = 0;
            cmd.GetTemporaryRT(tempTexture.id, cameraTextureDesc, FilterMode.Bilinear);

            Blit(cmd, source, tempTexture.Identifier(), material, 0);
            Blit(cmd, tempTexture.Identifier(), source);

            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }

        public override void FrameCleanup(CommandBuffer cmd)
        {
            cmd.ReleaseTemporaryRT(tempTexture.id);
        }
    }

    CustomRenderPass renderPass;

    public override void Create()
    {
        //var material = new Material(Shader.Find("Shader Graphs/WatercolorGlobalEffect"));
        this.renderPass = new CustomRenderPass(watercolorGlobalEffectMaterial);

        renderPass.renderPassEvent = RenderPassEvent.AfterRenderingPostProcessing;
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        renderPass.SetSource(renderer.cameraColorTarget);
        renderer.EnqueuePass(renderPass);
    }
}


