﻿using MelonLoader;
using System.IO;
using UnityEngine;

namespace ModComponentMapper
{
    public class Implementation : MelonMod
    {
        public static event SceneReady OnSceneReady;

        public override void OnApplicationStart()
        {
#if DEBUG
            Logger.Log("Debug Compilation");
#else
            Logger.Log("Release Compilation");
#endif
            Debug.Log($"[{Info.Name}] Version {Info.Version} loaded!");

            Settings.OnLoad();

            PageManager.Initialize();

            Logger.LogDebug("Running in Debug Mode");

            InjectClasses();

            ZipFileLoader.Initialize();

            AutoMapper.Initialize();
            ModHealthManager.Initialize();
            AssetBundleManager.LoadPendingAssetBundles();
            GearSpawner.Initialize();
            BlueprintReader.Initialize();
        }

        public static string GetModsFolderPath()
        {
            return Path.GetFullPath(typeof(MelonMod).Assembly.Location + @"\..\..\Mods");
        }

        internal static void SceneReady()
        {
            Logger.Log("Invoking 'SceneReady' for scene '{0}' ...", GameManager.m_ActiveScene);

            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            OnSceneReady?.Invoke();

            stopwatch.Stop();
            Logger.Log("Completed 'SceneReady' for scene '{0}' in {1} ms", GameManager.m_ActiveScene, stopwatch.ElapsedMilliseconds);
        }

        internal static void InjectClasses()
        {
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<AlcoholComponent>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ChangeLayer>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModAnimationStateMachine>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<FixMuzzleFlashTransformParent>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<RestoreMaterialQueue>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModHealthManager>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModComponentAPI.ModSaveBehaviour>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModComponentAPI.ModComponent>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModComponentAPI.ModFireStartingComponent>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModComponentAPI.ModAccelerantComponent>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModComponentAPI.ModBurnableComponent>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModComponentAPI.ModEvolveComponent>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModComponentAPI.ModFireStarterComponent>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModComponentAPI.ModHarvestableComponent>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModComponentAPI.ModMillableComponent>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModComponentAPI.ModRepairableComponent>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModComponentAPI.ModScentComponent>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModComponentAPI.ModSharpenableComponent>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModComponentAPI.ModStackableComponent>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModComponentAPI.EquippableModComponent>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModComponentAPI.ModBedComponent>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModComponentAPI.ModBodyHarvestComponent>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModComponentAPI.ModClothingComponent>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModComponentAPI.ModCookableComponent>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModComponentAPI.ModCookingPotComponent>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModComponentAPI.ModExplosiveComponent>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModComponentAPI.ModFirstAidComponent>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModComponentAPI.ModFoodComponent>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModComponentAPI.ModGenericComponent>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModComponentAPI.ModLiquidComponent>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModComponentAPI.ModPowderComponent>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModComponentAPI.ModRifleComponent>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModComponentAPI.ModToolComponent>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModComponentAPI.AddTag>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModComponentAPI.AlternativeAction>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModComponentAPI.AttachBehaviour>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModComponentAPI.ModBlueprint>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModComponentAPI.ModSkill>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModComponentAPI.PlayAkSound>();
            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<ModPlaceHolderComponent>();
        }
    }
}