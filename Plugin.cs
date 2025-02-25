using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using SodaMod.Items.Minerals;

namespace SodaMod { 

    [BepInPlugin("com.blue.sodamod", PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency("com.snmodding.nautilus")]
    public class Plugin : BaseUnityPlugin
    {
        public new static ManualLogSource Logger { get; private set; }

        private static Assembly Assembly { get; } = Assembly.GetExecutingAssembly();

        

        private void Awake()
        {
            Logger = base.Logger;

            InitializePrefabs();

            Harmony.CreateAndPatchAll(Assembly, "com.blue.sodamod");
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_NAME} is loaded!");
        }

        private void InitializePrefabs()
        {
            CarbonatedWater.Register();
            PeeperSoda.Register();
            KelpSoda.Register();   
            StalkerSoda.Register();
        }
    }
}