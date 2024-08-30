using Luminance.Core.Graphics;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Audio;
using Terraria;
using Microsoft.Xna.Framework.Audio;

namespace WotGDeath.Common.Effects
{
    [Autoload(Side = ModSide.Client)]
    public class DeathVisualsPlayer : ModPlayer
    {
        // public int DeathTimerOverride
        // {
        //     get;
        //     set;
        // } --unused for now

        // public static int DeathTimerMax => 240; --unused for now

        public float Volume = (float)(ModContent.GetInstance<WotGDeathConfig>().RipperBreakVolume / 100); // Divided by 100 to turn the variable into a decimal while keeping it easy to read on the config side
        public static readonly SoundStyle Trigger = new("WotGDeath/Core/Sounds/FUCKYOUSTUPIDRIPPERS"); // Set the sound to play

        public float TwoPi = 6.28318548f; // TwoPi will be used for the radius

        public float Intensity = ModContent.GetInstance<WotGDeathConfig>().ScreenShakeIntensity * 10; // Get shake intensity and multiply the intensity by 10 because the values are quite low
        public float Dissipation = ModContent.GetInstance<WotGDeathConfig>().ShakeDissipationRate; // Get dissiaption rate

        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genDust, ref PlayerDeathReason damageSource) 
        {
            // The if check is to prevent this from occuring when player revive items are used
            if (Player.statLife < 1)
            {
                playSound = false;
                SoundEngine.PlaySound(Trigger);
                ScreenShakeSystem.StartShake(
                    Intensity,
                    TwoPi, // Radius
                    null, // Direction
                    Dissipation
                    );
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
