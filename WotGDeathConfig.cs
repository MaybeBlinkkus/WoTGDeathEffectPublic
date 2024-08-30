using Terraria.ModLoader.Config;
using System.ComponentModel;
using Terraria.ModLoader;

namespace WotGDeath
{
    [Autoload(Side = ModSide.Client)]
    public class WotGDeathConfig : ModConfig
    {
        public static WotGDeathConfig Instance;

        public override ConfigScope Mode => ConfigScope.ServerSide;


        [Header("EffectConfig")]

        [Slider]
        [Range(4.8f, 14.4f)]
        [DefaultValue(9.6f)]
        public float ScreenShakeIntensity;

        [Slider]
        [Range(0.01f, 1f)]
        [DefaultValue(0.2f)]
        public float ShakeDissipationRate;

        [Slider]
        [Range(1, 100)]
        [DefaultValue(100)]
        public int RipperBreakVolume;

        [Header("VisualsConfig")]

        [ReloadRequired]
        [DefaultValue(true)]
        public bool OverrideYouWereSlain;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool TextOffset;
    }
}
