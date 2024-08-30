using MonoMod.Cil;
using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace WotGDeath.Core.Visuals
{
    [Autoload(Side = ModSide.Client)]
    public class DeathVisualsSystem : ModSystem
    {
        public bool TextOverride = ModContent.GetInstance<WotGDeathConfig>().OverrideYouWereSlain;
        public bool Offset = ModContent.GetInstance<WotGDeathConfig>().TextOffset;

        public int DeathTimerOverride
        {
            get;
            set;
        }

        public override void OnModLoad()
        {
            IL_Main.DrawInterface_35_YouDied += DeathTextReplacement;
        }

        private void DeathTextReplacement(ILContext il)
        {
            ILCursor cursor = new(il);

            // Make the text offset higher if enabled in config
            if (Offset)
            {
                cursor.GotoNext(MoveType.Before, i => i.MatchStloc(out _));
                cursor.EmitDelegate<Func<float, float>>(textOffset =>
                {
                    textOffset -= 120f;

                    return textOffset;
                });
            }

            // Replace "You were slain..." text if enabled in config
            if (TextOverride)
            {
                cursor.GotoNext(i => i.MatchLdsfld<Lang>("inter"));
                cursor.GotoNext(MoveType.Before, i => i.MatchStloc(out _));
                cursor.EmitDelegate<Func<string, string>>(originalText =>
                {
                    return Language.GetTextValue("Mods.WotGDeath.Dialog.OverridenDeathText");
                });
            }
        }
    }
}
