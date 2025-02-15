﻿using BepInEx;
using BepInEx.Configuration;
using R2API;
using R2API.Utils;
using RoR2;
using System;
using UnityEngine;
using Hex3Mod;
using Hex3Mod.Logging;
using Hex3Mod.HelperClasses;

namespace Hex3Mod.Items
{
    /*
    400 Tickets is part of the Consumables pack. There are many "break on low health" consumables, so one that has a novel utility seemed like a good idea
    Mostly useless (but still advantageous) if used on a small chest, but a Large Chest or Legendary Chest is where you need one of these.
    */
    public class Tickets
    {
        // Create functions here for defining the ITEM, TOKENS, HOOKS and CONFIG. This is simpler than doing it in Main
        static string itemName = "Tickets"; // Change this name when making a new item
        static string upperName = itemName.ToUpper();
        public static ItemDef itemDefinition = CreateItem();
        public static ItemDef consumedItemDefinition = CreateConsumedItem();
        public static GameObject LoadPrefab()
        {
            GameObject pickupModelPrefab = Main.MainAssets.LoadAsset<GameObject>("Assets/Models/Prefabs/TicketsPrefab.prefab");
            return pickupModelPrefab;
        }
        public static Sprite LoadSprite()
        {
            Sprite pickupIconSprite = Main.MainAssets.LoadAsset<Sprite>("Assets/Icons/Tickets.png");
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

            item.tags = new ItemTag[]{ ItemTag.Utility, ItemTag.AIBlacklist, ItemTag.BrotherBlacklist }; // Would be useless on AI
            item.deprecatedTier = ItemTier.Tier1;
            item.canRemove = true;
            item.hidden = false;

            item.pickupModelPrefab = LoadPrefab();
            item.pickupIconSprite = LoadSprite();

            return item;
        }
        public static ItemDef CreateConsumedItem()
        {
            ItemDef item = ScriptableObject.CreateInstance<ItemDef>();

            item.name = itemName + "Consumed";
            item.nameToken = "H3_" + upperName + "CONSUMED_NAME";
            item.pickupToken = "H3_" + upperName + "CONSUMED_PICKUP";
            item.descriptionToken = "H3_" + upperName + "CONSUMED_DESC";
            item.loreToken = "H3_" + upperName + "CONSUMED_LORE";

            item.tags = new ItemTag[] { ItemTag.CannotCopy, ItemTag.CannotDuplicate , ItemTag.AIBlacklist, ItemTag.BrotherBlacklist }; // Need to make sure the item can't be given or cloned
            item.deprecatedTier = ItemTier. NoTier;
            item.canRemove = true;
            item.hidden = false;

            item.pickupModelPrefab = Main.MainAssets.LoadAsset<GameObject>("Assets/Models/Prefabs/TicketsPrefab.prefab");
            item.pickupIconSprite = Main.MainAssets.LoadAsset<Sprite>("Assets/Icons/TicketsConsumed.png");

            return item;
        }

        public static ItemDisplayRuleDict CreateDisplayRules() // We've figured item displays out!
        {
            GameObject ItemDisplayPrefab = helpers.PrepareItemDisplayModel(PrefabAPI.InstantiateClone(LoadPrefab(), LoadPrefab().name + "Display", false));

            ItemDisplayRuleDict rules = new ItemDisplayRuleDict();
            rules.Add("mdlCommandoDualies", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "CalfL",
                        localPos = new Vector3(0.00927F, 0.10541F, -0.02883F),
                        localAngles = new Vector3(15.07626F, 184.3583F, 246.3487F),
                        localScale = new Vector3(0.37297F, 0.34407F, 0.34949F)
                    }
                }
            );
            rules.Add("mdlHuntress", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "HeadCenter",
                        localPos = new Vector3(0.05518F, -0.03063F, -0.05223F),
                        localAngles = new Vector3(22.7539F, 112.5206F, 30.06874F),
                        localScale = new Vector3(0.3862F, 0.3862F, 0.3862F)
                    }
                }
            );
            rules.Add("mdlToolbot", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "LowerArmL",
                        localPos = new Vector3(0.64832F, 5.44166F, -0.05396F),
                        localAngles = new Vector3(358.7048F, 106.5688F, 270.3022F),
                        localScale = new Vector3(2.94697F, 2.94697F, 2.94697F)
                    }
                }
            );
            rules.Add("mdlEngi", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "Stomach",
                        localPos = new Vector3(-0.06484F, -0.0086F, -0.05942F),
                        localAngles = new Vector3(350.3929F, 247.1018F, 264.1864F),
                        localScale = new Vector3(0.62793F, 0.62793F, 0.62793F)
                    }
                }
            );
            rules.Add("mdlMage", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "Chest",
                        localPos = new Vector3(-0.16061F, 0.26349F, -0.14924F),
                        localAngles = new Vector3(347.4555F, 280.9578F, 297.396F),
                        localScale = new Vector3(-0.43104F, 0.42094F, 0.35703F)
                    }
                }
            );
            rules.Add("mdlMerc", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "HandL",
                        localPos = new Vector3(-0.08698F, 0.10075F, -0.0041F),
                        localAngles = new Vector3(49.75164F, 1.50993F, 181.2459F),
                        localScale = new Vector3(-0.25159F, 0.27408F, 0.2336F)
                    }
                }
            );
            rules.Add("mdlTreebot", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "CalfBackR",
                        localPos = new Vector3(0.08805F, 0.61719F, -0.08117F),
                        localAngles = new Vector3(8.24625F, 100.2931F, 272.7766F),
                        localScale = new Vector3(-0.64708F, 0.7225F, 0.7225F)
                    }
                }
            );
            rules.Add("mdlLoader", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "Chest",
                        localPos = new Vector3(0.14977F, 0.32377F, 0.29649F),
                        localAngles = new Vector3(0F, 0F, 0F),
                        localScale = new Vector3(0.33674F, 0.33674F, 0.33674F)
                    }
                }
            );
            rules.Add("mdlCroco", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "HandL",
                        localPos = new Vector3(0.41647F, 1.1654F, 0.46774F),
                        localAngles = new Vector3(357.1312F, 12.39285F, 124.7832F),
                        localScale = new Vector3(3.67553F, 3.67553F, 3.67553F)
                    }
                }
            );
            rules.Add("mdlCaptain", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "HandL",
                        localPos = new Vector3(-0.04707F, -0.08236F, 0.04182F),
                        localAngles = new Vector3(8.12018F, 300.2912F, 97.09362F),
                        localScale = new Vector3(0.34931F, 0.34931F, 0.34931F)
                    }
                }
            );
            rules.Add("mdlBandit2", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "Hat",
                        localPos = new Vector3(-0.09384F, 0.01368F, -0.04171F),
                        localAngles = new Vector3(8.61942F, 231.3094F, 282.6341F),
                        localScale = new Vector3(0.52385F, 0.52385F, 0.52385F)
                    }
                }
            );
            rules.Add("EngiTurretBody", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "LegBar2",
                        localPos = new Vector3(0.16568F, 0.50018F, -0.06216F),
                        localAngles = new Vector3(354.0227F, 92.69547F, 87.36358F),
                        localScale = new Vector3(1.14751F, 1.14751F, 1.14751F)
                    }
                }
            );
            rules.Add("EngiWalkerTurretBody", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "LegBar2",
                        localPos = new Vector3(0.16876F, -0.16572F, -0.34877F),
                        localAngles = new Vector3(2.86457F, 92.27133F, 149.7901F),
                        localScale = new Vector3(1.25716F, 1.25716F, 1.25716F)
                    }
                }
            );
            rules.Add("mdlScav", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "Backpack",
                        localPos = new Vector3(-2.91533F, 6.70336F, -2.1303F),
                        localAngles = new Vector3(345.0512F, 210.8083F, 4.95444F),
                        localScale = new Vector3(15.02295F, 15.02295F, 15.02295F)
                    }
                }
            );
            rules.Add("mdlRailGunner", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "ThighR",
                        localPos = new Vector3(0.02434F, 0.18574F, 0.11247F),
                        localAngles = new Vector3(343.7317F, 15.11429F, 272.6107F),
                        localScale = new Vector3(0.52614F, 0.52614F, 0.52614F)
                    }
                }
            );
            rules.Add("mdlVoidSurvivor", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "UpperArmR",
                        localPos = new Vector3(0.11415F, 0.06479F, 0.10721F),
                        localAngles = new Vector3(327.629F, 11.98644F, 134.3462F),
                        localScale = new Vector3(0.57511F, 0.57511F, 0.57511F)
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

        public static void AddTokens()
        {
            LanguageAPI.Add("H3_" + upperName + "_NAME", "400 Tickets");
            LanguageAPI.Add("H3_" + upperName + "_PICKUP", "The next chest you buy will contain an additional item.");
            LanguageAPI.Add("H3_" + upperName + "_DESC", "The next chest you buy will contain an additional item. <style=cIsUtility>Consumed on use.</style>");
            LanguageAPI.Add("H3_" + upperName + "_LORE", "\"Oh yeah, these. They're old tickets from that 'space casino' they tried to open up. While the adults were playing slots or roulette or whatever in the main floor, their kids could go spend their pocket change on the machines downstairs. These are the tickets they'd get as winnings. Could buy- you know- teddy bears and hoverboards and stuff with them.\"" +
            "\n\n\"That's screwed up. Why do you have those?\"" +
            "\n\n\"Well, there's one crucial detail they forgot about before closing up the casino: All the tickets are still valid.\"" +
            "\n\n\"...Can we still get a hoverboard with them?\"");

            LanguageAPI.Add("H3_" + upperName + "CONSUMED_NAME", "Used Tickets");
            LanguageAPI.Add("H3_" + upperName + "CONSUMED_PICKUP", "No longer valid.");
            LanguageAPI.Add("H3_" + upperName + "CONSUMED_DESC", "No longer valid.");
            LanguageAPI.Add("H3_" + upperName + "CONSUMED_LORE", "");
        }

        private static void AddHooks(ItemDef itemDefToHooks, ItemDef consumedItemDefToHooks) // Insert hooks here
        {
            // Store the chest and the character to ensure that the right chest and the right player are getting affected
            GameObject purchasedObject = new GameObject();
            CharacterBody interactorBody = new CharacterBody();

            On.RoR2.PurchaseInteraction.OnInteractionBegin += (orig, self, interactor) =>
            {
                orig(self, interactor);
                if (interactor.GetComponent<CharacterBody>() && interactor.GetComponent<CharacterBody>().inventory && interactor.GetComponent<CharacterBody>().inventory.GetItemCount(itemDefToHooks) > 0)
                {
                    if (self.isShrine != true)
                    {
                        purchasedObject = self.gameObject;
                        interactorBody = interactor.GetComponent<CharacterBody>();
                    }
                }
            };

            On.RoR2.ChestBehavior.ItemDrop += (orig, self) =>
            {
                if (self.gameObject == purchasedObject && interactorBody.inventory && interactorBody.inventory.GetItemCount(itemDefToHooks) > 0)
                {
                    self.dropCount += 1;
                    interactorBody.inventory.RemoveItem(itemDefToHooks);
                    interactorBody.inventory.GiveItem(consumedItemDefToHooks);
                    CharacterMasterNotificationQueue.PushItemTransformNotification(interactorBody.master, itemDefToHooks.itemIndex, consumedItemDefToHooks.itemIndex, CharacterMasterNotificationQueue.TransformationType.Default);
                    Util.PlaySound(RouletteChestController.Opening.soundEntryEvent, self.gameObject);
                    purchasedObject = null;
                    interactorBody = null;
                }
                orig(self);
            };
        }

        public static void Initiate() // Finally, initiate the item and all of its features
        {
            ItemAPI.Add(new CustomItem(itemDefinition, CreateDisplayRules()));
            ItemAPI.Add(new CustomItem(consumedItemDefinition, CreateHiddenDisplayRules()));
            AddTokens();
            AddHooks(itemDefinition, consumedItemDefinition);
        }
    }
}
