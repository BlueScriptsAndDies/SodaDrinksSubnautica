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
    public class CarbonatedWater
    {
        public static PrefabInfo Info { get; private set; }

        

        public static void Register()
        {
            Info = PrefabInfo.WithTechType("CarbonatedWater", "Carbonated Water", "Water that's carbonated.").WithIcon(SpriteManager.Get(TechType.FilteredWater));
            var carbononatedwaterPrefab = new CustomPrefab(Info);
   
            var carbenatedwaterObj = new CloneTemplate(Info, TechType.FilteredWater);
            carbononatedwaterPrefab.SetGameObject(carbenatedwaterObj);
            {
                carbenatedwaterObj.ModifyPrefab = prefab1 =>
                {
                    Eatable eatable = prefab1.EnsureComponent<Eatable>();
                    eatable.waterValue = 35;
                };
            }
            

            var recipe = new RecipeData(new Ingredient(TechType.FilteredWater),new Ingredient(TechType.GasPod,4), new Ingredient(TechType.Bleach));
            carbononatedwaterPrefab.SetRecipe(recipe).WithCraftingTime(3f).WithFabricatorType(CraftTree.Type.Fabricator).WithStepsToFabricatorTab("Survival", "Water");
            carbononatedwaterPrefab.SetPdaGroupCategory(TechGroup.Survival,TechCategory.Water);
            carbononatedwaterPrefab.SetUnlock(TechType.GasPod);

            

            

            carbononatedwaterPrefab.Register();
        }
    }

}
