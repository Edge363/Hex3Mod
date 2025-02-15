﻿using BepInEx;
using BepInEx.Configuration;
using R2API;
using R2API.Utils;
using RoR2;
using RoR2.ExpansionManagement;
using System;
using System.Runtime;
using System.Linq;
using UnityEngine;
using Hex3Mod;
using Hex3Mod.Logging;
using Hex3Mod.HelperClasses;
using VoidItemAPI;

namespace Hex3Mod.Items
{
    /*
    If you're going for a full void build, Discovery will be a decent method of getting shields.
    To match with Infusion's purpose and to be thematically consistent with exploration of the void, this item gives shield based on your "discoveries" (interactions)
    */
    public class Discovery
    {
        // Create functions here for defining the ITEM, TOKENS, HOOKS and CONFIG. This is simpler than doing it in Main
        static string itemName = "Discovery"; // Change this name when making a new item
        static string upperName = itemName.ToUpper();
        public static ItemDef itemDefinition = CreateItem();
        public static ItemDef hiddenItemDefinition = CreateHiddenItem();
        public static GameObject LoadPrefab()
        {
            GameObject pickupModelPrefab = Main.MainAssets.LoadAsset<GameObject>("Assets/Models/Prefabs/DiscoveryPrefab.prefab");
            return pickupModelPrefab;
        }
        public static Sprite LoadSprite()
        {
            Sprite pickupIconSprite = Main.MainAssets.LoadAsset<Sprite>("Assets/Icons/Discovery.png");
            return pickupIconSprite;
        }
        public static ItemDef CreateItem()
        {
            ItemDef item = ScriptableObject.CreateInstance<ItemDef>();

            item.name = itemName;
            item.nameToken = "H3_" + upperName + "_NAME";
            item.pickupToken = "H3_" + upperName + "_PICKUP";
            item.descriptionToken = "H3_" + upperName + "_DESC";
            item.loreToken = "H3_" + upperName + "_LORE";

            item.tags = new ItemTag[]{ ItemTag.Healing, ItemTag.AIBlacklist, ItemTag.BrotherBlacklist }; // Would be useless and complicated on monsters
            item.deprecatedTier = ItemTier.VoidTier2;
            item.canRemove = true;
            item.hidden = false;
            item.requiredExpansion = ExpansionCatalog.expansionDefs.FirstOrDefault(x => x.nameToken == "DLC1_NAME");

            item.pickupModelPrefab = LoadPrefab();
            item.pickupIconSprite = LoadSprite();

            return item;
        }

        public static ItemDisplayRuleDict CreateDisplayRules() // We've figured item displays out!
        {
            GameObject ItemDisplayPrefab = helpers.PrepareItemDisplayModel(PrefabAPI.InstantiateClone(LoadPrefab(), LoadPrefab().name + "Display", false));

            ItemDisplayRuleDict rules = new ItemDisplayRuleDict();
            rules.Add("mdlCommandoDualies", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "Pelvis",
                        localPos = new Vector3(0.15416F, -0.07144F, -0.00001F),
                        localAngles = new Vector3(0F, 0F, 0F),
                        localScale = new Vector3(0.09441F, 0.09441F, 0.09441F)
                    }
                }
            );
            rules.Add("mdlHuntress", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "Head",
                        localPos = new Vector3(0.00001F, 0.24273F, 0.05034F),
                        localAngles = new Vector3(25.39802F, 0F, 0F),
                        localScale = new Vector3(0.07587F, 0.07587F, 0.07587F)
                    }
                }
            );
            rules.Add("mdlToolbot", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "Chest",
                        localPos = new Vector3(1.05056F, 1.94221F, 1.64765F),
                        localAngles = new Vector3(45.8378F, 0F, 0F),
                        localScale = new Vector3(0.85108F, 0.85108F, 0.85108F)
                    }
                }
            );
            rules.Add("mdlEngi", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "CannonHeadR",
                        localPos = new Vector3(0F, 0.39234F, 0.00003F),
                        localAngles = new Vector3(314.5863F, 0F, 0F),
                        localScale = new Vector3(0.11812F, 0.11812F, 0.11812F)
                    }
                }
            );
            rules.Add("mdlMage", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "Chest",
                        localPos = new Vector3(0.11241F, 0.28087F, -0.18459F),
                        localAngles = new Vector3(323.6529F, 0F, 0F),
                        localScale = new Vector3(0.09022F, 0.09022F, 0.09022F)
                    }
                }
            );
            rules.Add("mdlMerc", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "HandR",
                        localPos = new Vector3(-0.021F, 0.17313F, 0.01653F),
                        localAngles = new Vector3(36.11853F, 98.29133F, 8.29494F),
                        localScale = new Vector3(0.1098F, 0.1098F, 0.1098F)
                    }
                }
            );
            rules.Add("mdlTreebot", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "WeaponPlatform",
                        localPos = new Vector3(-0.14601F, 0.07474F, 0.17599F),
                        localAngles = new Vector3(314.9279F, 0F, 0F),
                        localScale = new Vector3(0.19015F, 0.19015F, 0.19015F)
                    }
                }
            );
            rules.Add("mdlLoader", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "Chest",
                        localPos = new Vector3(0.20309F, 0.53486F, 0.03296F),
                        localAngles = new Vector3(50.2245F, 0F, 0F),
                        localScale = new Vector3(0.10039F, 0.10039F, 0.10039F)
                    }
                }
            );
            rules.Add("mdlCroco", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "MouthMuzzle",
                        localPos = new Vector3(-0.21135F, 2.19588F, 2.52151F),
                        localAngles = new Vector3(44.53611F, 86.83545F, 0.12085F),
                        localScale = new Vector3(1.12444F, 1.12444F, 1.12885F)
                    }
                }
            );
            rules.Add("mdlCaptain", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "LowerArmL",
                        localPos = new Vector3(-0.00595F, 0.42614F, 0.04707F),
                        localAngles = new Vector3(315.9901F, 351.1433F, 12.76379F),
                        localScale = new Vector3(0.11838F, 0.11838F, 0.11838F)
                    }
                }
            );
            rules.Add("mdlBandit2", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "MainWeapon",
                        localPos = new Vector3(-0.14041F, 0.41272F, -0.00407F),
                        localAngles = new Vector3(315.4345F, 0F, 0F),
                        localScale = new Vector3(0.08203F, 0.08203F, 0.08203F)
                    }
                }
            );
            rules.Add("EngiTurretBody", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "Head",
                        localPos = new Vector3(0F, 0.57577F, 0.58945F),
                        localAngles = new Vector3(45.66947F, 0F, 0F),
                        localScale = new Vector3(0.35445F, 0.35445F, 0.35445F)
                    }
                }
            );
            rules.Add("EngiWalkerTurretBody", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "Head",
                        localPos = new Vector3(0F, 0.20624F, -0.20413F),
                        localAngles = new Vector3(45.29741F, 0F, 0F),
                        localScale = new Vector3(0.33057F, 0.33057F, 0.33057F)
                    }
                }
            );
            rules.Add("mdlScav", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "Backpack",
                        localPos = new Vector3(-10.62732F, 13.82996F, 1.14351F),
                        localAngles = new Vector3(42.83438F, 0F, 0F),
                        localScale = new Vector3(1.34648F, 1.34648F, 1.34648F)
                    }
                }
            );
            rules.Add("mdlRailGunner", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "GunScope",
                        localPos = new Vector3(-0.07081F, -0.14643F, 0.17777F),
                        localAngles = new Vector3(44.5719F, 0F, 0F),
                        localScale = new Vector3(0.13531F, 0.13156F, 0.13156F)
                    }
                }
            );
            rules.Add("mdlVoidSurvivor", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "ThighL",
                        localPos = new Vector3(0F, 0F, -0.14146F),
                        localAngles = new Vector3(345.2758F, 49.11308F, 282.4109F),
                        localScale = new Vector3(0.10932F, 0.10932F, 0.10932F)
                    }
                }
            );

            return rules;
        }

        // Hidden items should not display at all
        public static ItemDisplayRuleDict CreateHiddenDisplayRules()
        {
            return new ItemDisplayRuleDict();
        }

        public static void AddTokens(float Discovery_ShieldAdd, int Discovery_MaxStacks)
        {
            float finalNumber = Discovery_ShieldAdd * Discovery_MaxStacks;
            LanguageAPI.Add("H3_" + upperName + "_NAME", "Discovery");
            LanguageAPI.Add("H3_" + upperName + "_PICKUP", "Using a world interactable grants <style=cIsHealing>regenerating shield</style> to all holders of this item. <style=cIsVoid>Corrupts all Infusions.</style>");
            LanguageAPI.Add("H3_" + upperName + "_DESC", "Using a world interactable grants <style=cIsHealing>" + Discovery_ShieldAdd + "</style> points per stack of <style=cIsHealing>regenerating shield</style> to every player who has this item. Caps at <style=cIsHealing>" + finalNumber + " shield</style> <style=cStack>(+" + finalNumber + " per stack)</style>. <style=cIsVoid>Corrupts all Infusions.</style>");
            LanguageAPI.Add("H3_" + upperName + "_LORE", "EXPLORER'S LOG" +
            "\n// 'Author' information lost, attempting to fix..." +
            "\n// 'Date' information lost, attempting to fix..." +
            "\n// 'Location' information lost, attempting to fix..." +
            "\n\nI no longer know where I am, and I'm certain that nobody else does either. What I do know is that it's dark. It's cold and it's humid, too. Each breath I take is belaboured, like I'm sucking in water. I've started to become used to it though. I think..." +
            "\n\nI am away now from the dangers of the planet, but I've been missing them. It was exhilirating, and almost fun to duck and dodge around and away from certain death, having lasers and balls of fire and crude projectiles launched at me from all directions. But now I'm here, and there's nothing. I came here to explore, but where I am now, everything is the same. I walk into what looks to be a black portal, but on the other side is a repeat of the same terrain. I'm hopelessly bored." +
            "\n\nI forget how many days it's been. I've already turned over every rock, searched each hilltop and tried most of the common passphrases that I know. Nothing. It's cold and yet I'm sweating. Will I be here forever? I have hope that there's a way to escape, but that's only hope. My heart is beating out of my chest... Why do I feel so anxious?" +
            "\n\nMy spyglass and toolkit are gone. I left them beside me before sleeping, woke up and they were missing. I'm so bored... but I'm so anxious. I'll try the portal again. Maybe something will change. Why am I still sweating?" +
            "\n\n<style=cStack>I'm so cold...</style>");
        }

        private static void AddHooks(ItemDef itemDefToHooks, ItemDef hiddenItemDefToHooks, float Discovery_ShieldAdd, int Discovery_MaxStacks) // Insert hooks here
        {
            // Void transformation
            VoidTransformation.CreateTransformation(itemDefToHooks, "Infusion");

            // Easy way to do this: Make a new hidden item, add one each time an interactable is used
            void DiscoveryInteract(Interactor interactor, PurchaseInteraction interaction)
            {
                // First, make sure the item isn't a printer, so we can't have infinite interaction loops
                if (interaction.costType != CostTypeIndex.WhiteItem && interaction.costType != CostTypeIndex.GreenItem && interaction.costType != CostTypeIndex.RedItem && interaction.costType != CostTypeIndex.BossItem && interaction.costType != CostTypeIndex.LunarItemOrEquipment)
                {
                    if (interactor.gameObject.GetComponent<CharacterBody>())
                    {
                        CharacterBody body = interactor.gameObject.GetComponent<CharacterBody>();
                        var bodyTeamMembers = TeamComponent.GetTeamMembers(body.teamComponent.teamIndex);

                        foreach (var member in bodyTeamMembers)
                        {
                            if (member.body && member.body.inventory && member.body.inventory.GetItemCount(itemDefToHooks) > 0 && body.inventory.GetItemCount(hiddenItemDefToHooks) < (Discovery_MaxStacks * member.body.inventory.GetItemCount(itemDefToHooks)))
                            {
                                member.body.inventory.GiveItem(hiddenItemDefToHooks, member.body.inventory.GetItemCount(itemDefToHooks));
                                if (member.body.inventory.GetItemCount(hiddenItemDefToHooks) > Discovery_MaxStacks * member.body.inventory.GetItemCount(itemDefToHooks))
                                {
                                    for (int i = member.body.inventory.GetItemCount(hiddenItemDefToHooks); i > Discovery_MaxStacks * member.body.inventory.GetItemCount(itemDefToHooks); i--)
                                    {
                                        member.body.inventory.RemoveItem(hiddenItemDefToHooks);
                                    }
                                }
                                Util.PlaySound(EntityStates.VoidJailer.Weapon.ChargeFire.attackSoundEffect, interactor.gameObject);
                                EffectData effectData = new EffectData
                                {
                                    origin = body.corePosition
                                };
                                EffectManager.SpawnEffect(EntityStates.NullifierMonster.FirePortalBomb.muzzleflashEffectPrefab, effectData, false);
                            }
                            if (member.body && member.body.inventory && member.body.inventory.GetItemCount(itemDefToHooks) < 1)
                            {
                                member.body.inventory.ResetItem(hiddenItemDefToHooks);
                            }
                        }
                    }
                }
            }
            void DiscoveryBarrelInteract(Interactor interactor)
            {

                if (interactor.gameObject.GetComponent<CharacterBody>())
                {
                    CharacterBody body = interactor.gameObject.GetComponent<CharacterBody>();
                    var bodyTeamMembers = TeamComponent.GetTeamMembers(body.teamComponent.teamIndex);

                    foreach (var member in bodyTeamMembers)
                    {
                        if (member.body && member.body.inventory && member.body.inventory.GetItemCount(itemDefToHooks) > 0 && body.inventory.GetItemCount(hiddenItemDefToHooks) < (Discovery_MaxStacks * member.body.inventory.GetItemCount(itemDefToHooks)))
                        {
                            member.body.inventory.GiveItem(hiddenItemDefToHooks, member.body.inventory.GetItemCount(itemDefToHooks));
                            if (member.body.inventory.GetItemCount(hiddenItemDefToHooks) > Discovery_MaxStacks * member.body.inventory.GetItemCount(itemDefToHooks))
                            {
                                for (int i = member.body.inventory.GetItemCount(hiddenItemDefToHooks); i > Discovery_MaxStacks * member.body.inventory.GetItemCount(itemDefToHooks); i--)
                                {
                                    member.body.inventory.RemoveItem(hiddenItemDefToHooks);
                                }
                            }
                            Util.PlaySound(EntityStates.VoidJailer.Weapon.ChargeFire.attackSoundEffect, interactor.gameObject);
                            EffectData effectData = new EffectData
                            {
                                origin = body.corePosition
                            };
                            EffectManager.SpawnEffect(EntityStates.NullifierMonster.FirePortalBomb.muzzleflashEffectPrefab, effectData, false);
                        }
                    }
                }
            }

            void DiscoveryRecalculateStats(CharacterBody body, RecalculateStatsAPI.StatHookEventArgs args)
            {
                if (body && body.inventory && body.inventory.GetItemCount(itemDefToHooks) > 0)
                {
                    args.baseShieldAdd += Discovery_ShieldAdd * body.inventory.GetItemCount(hiddenItemDefToHooks);
                    body.SetBuffCount(discoveryBuff.buffIndex, body.inventory.GetItemCount(hiddenItemDefToHooks));
                }
            }

            RecalculateStatsAPI.GetStatCoefficients += DiscoveryRecalculateStats;
            On.RoR2.PurchaseInteraction.OnInteractionBegin += (orig, self, interactor) =>
            {
                orig(self, interactor);
                DiscoveryInteract(interactor, self);
            };
            On.RoR2.BarrelInteraction.OnInteractionBegin += (orig, self, interactor) =>
            {
                orig(self, interactor);
                DiscoveryBarrelInteract(interactor);
            };
        }

        public static ItemDef CreateHiddenItem()
        {
            ItemDef item = ScriptableObject.CreateInstance<ItemDef>(); // New hidden item to keep track of stacks, like infusion

            item.name = "DiscoveryHidden";
            item.nameToken = "H3_" + upperName + "_NAME";
            item.pickupToken = "H3_" + upperName + "_PICKUP";
            item.descriptionToken = "H3_" + upperName + "_DESC";
            item.loreToken = "H3_" + upperName + "_LORE";

            item.tags = new ItemTag[] { ItemTag.CannotCopy, ItemTag.CannotSteal, ItemTag.CannotDuplicate };
            item.deprecatedTier = ItemTier.NoTier;
            item.canRemove = false;
            item.hidden = true;

            item.pickupModelPrefab = Main.MainAssets.LoadAsset<GameObject>("Assets/Models/Prefabs/DiscoveryPrefab.prefab");
            item.pickupIconSprite = Main.MainAssets.LoadAsset<Sprite>("Assets/Textures/Icons/Discovery.png");

            return item;
        }

        public static BuffDef discoveryBuff { get; private set; }
        public static void AddBuffs() // Just for players to track their discovery stacks
        {
            discoveryBuff = ScriptableObject.CreateInstance<BuffDef>();
            discoveryBuff.buffColor = new Color(1f, 1f, 1f);
            discoveryBuff.canStack = true;
            discoveryBuff.isDebuff = false;
            discoveryBuff.name = "Discovery Shields";
            discoveryBuff.isHidden = false;
            discoveryBuff.isCooldown = false;
            discoveryBuff.iconSprite = Main.MainAssets.LoadAsset<Sprite>("Assets/Icons/Buff_Discovery.png"); // Rework this later
            ContentAddition.AddBuffDef(discoveryBuff);
        }

        public static void Initiate(float Discovery_ShieldAdd, int Discovery_MaxStacks) // Finally, initiate the item and all of its features
        {
            CreateItem();
            CreateHiddenItem();
            ItemAPI.Add(new CustomItem(itemDefinition, CreateDisplayRules()));
            ItemAPI.Add(new CustomItem(hiddenItemDefinition, CreateHiddenDisplayRules()));
            AddTokens(Discovery_ShieldAdd, Discovery_MaxStacks);
            AddBuffs();
            AddHooks(itemDefinition, hiddenItemDefinition, Discovery_ShieldAdd, Discovery_MaxStacks);
        }
    }
}
