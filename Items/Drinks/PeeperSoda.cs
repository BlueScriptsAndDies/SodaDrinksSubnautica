using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nautilus.Assets.Gadgets;
using Nautilus.Crafting;
using Ingredient = CraftData.Ingredient;
using Nautilus.Handlers;
using System.Runtime.InteropServices;
using UnityEngine;
using Nautilus.Utility;
using System.Reflection;



namespace SodaMod.Items.Minerals
{
    public class PeeperSoda
    {
        public static PrefabInfo Info { get; private set; }



        public static void Register()
        {
            Info = PrefabInfo.WithTechType("PeeperSoda", "Peeper Soda", "A refreshing beverage made from peepers.").WithIcon(SpriteManager.Get(TechType.FilteredWater));
            var peeperjuicePrefab = new CustomPrefab(Info);

            var peeperjuiceObj = new CloneTemplate(Info, TechType.FilteredWater);
            peeperjuicePrefab.SetGameObject(peeperjuiceObj);
            {
                peeperjuiceObj.ModifyPrefab = prefab1 =>
                {
                    Eatable eatable = prefab1.EnsureComponent<Eatable>();
                    eatable.waterValue = 100;
                };
            }


            var recipe = new RecipeData(new Ingredient(CarbonatedWater.Info.TechType), new Ingredient(TechType.Peeper));
            peeperjuicePrefab.SetRecipe(recipe).WithCraftingTime(3f).WithFabricatorType(CraftTree.Type.Fabricator).WithStepsToFabricatorTab("Survival", "Water");
            peeperjuicePrefab.SetPdaGroupCategory(TechGroup.Survival,TechCategory.Water);
            peeperjuicePrefab.SetUnlock(TechType.Peeper);





            peeperjuicePrefab.Register();
        }
    }

}
