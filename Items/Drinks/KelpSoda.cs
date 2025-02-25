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
    public class KelpSoda
    {
        public static PrefabInfo Info { get; private set; }



        public static void Register()
        {
            Info = PrefabInfo.WithTechType("KelpSoda", "Kelp Soda", "A refreshing beverage made from kelp.").WithIcon(SpriteManager.Get(TechType.FilteredWater));
            var kelpsodaPrefab = new CustomPrefab(Info);

            var kelpsodaObj = new CloneTemplate(Info, TechType.FilteredWater);
            kelpsodaPrefab.SetGameObject(kelpsodaObj);
            {
                kelpsodaObj.ModifyPrefab = prefab1 =>
                {
                    Eatable eatable = prefab1.EnsureComponent<Eatable>();
                    eatable.waterValue = 100;
                };
            }


            var recipe = new RecipeData(new Ingredient(CarbonatedWater.Info.TechType), new Ingredient(TechType.CreepvinePiece));
            kelpsodaPrefab.SetRecipe(recipe).WithCraftingTime(3f).WithFabricatorType(CraftTree.Type.Fabricator).WithStepsToFabricatorTab("Survival", "Water");
            kelpsodaPrefab.SetPdaGroupCategory(TechGroup.Survival,TechCategory.Water);
            kelpsodaPrefab.SetUnlock(TechType.CreepvinePiece);





            kelpsodaPrefab.Register();
        }
    }

}
