using HarmonyLib;
using BepInEx;
using BepInEx.Configuration;

namespace PVEAlwaysOn
{
    [BepInPlugin("pve_force", "PVEAlwaysOn", "1.0.0.2")]
    public class PVELOAD : BaseUnityPlugin
    {
        public const string version = "1.0.0.2";
        public static string newestVersion = "";
        public static bool isUpToDate = false;

        // Project Repository Info
        public static string Repository = "";
        public static string ApiRepository = "https://api.github.com/repos/BetterWards/BetterWards/tags";
        void Awake()
        {
            Harmony harmony = new Harmony("mod.pve_force");
            harmony.PatchAll();
            isUpToDate = !Settings.isNewVersionAvailable();
            if (!isUpToDate)
            {
                Logger.LogError("There is a newer version available of PVEAlwaysOn.");
                Logger.LogWarning("Please visit " + PVELOAD.Repository + ".");
            }
            else
            {
                Logger.LogInfo("PVElwaysOn [" + version + "] is up to date.");
            }
        }
    }
}
