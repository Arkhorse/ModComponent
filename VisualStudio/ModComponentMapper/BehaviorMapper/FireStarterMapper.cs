﻿using ModComponentAPI;
using UnityEngine;

namespace ModComponentMapper.ComponentMapper
{
    internal static class FireStarterMapper
    {
        internal static void Configure(ModComponent modComponent)
        {
            ModFireStarterComponent modFireStarterComponent = ComponentUtils.GetComponent<ModFireStarterComponent>(modComponent);
            if (modFireStarterComponent == null) return;

            FireStarterItem fireStarterItem = ComponentUtils.GetOrCreateComponent<FireStarterItem>(modFireStarterComponent);

            fireStarterItem.m_SecondsToIgniteTinder = modFireStarterComponent.SecondsToIgniteTinder;
            fireStarterItem.m_SecondsToIgniteTorch = modFireStarterComponent.SecondsToIgniteTorch;

            fireStarterItem.m_FireStartSkillModifier = modFireStarterComponent.SuccessModifier;

            fireStarterItem.m_ConditionDegradeOnUse = Mapper.GetDecayPerStep(modFireStarterComponent.NumberOfUses, modComponent.MaxHP);
            fireStarterItem.m_ConsumeOnUse = modFireStarterComponent.DestroyedOnUse;
            fireStarterItem.m_RequiresSunLight = modFireStarterComponent.RequiresSunLight;
            fireStarterItem.m_OnUseSoundEvent = modFireStarterComponent.OnUseSoundEvent;
        }
    }
}