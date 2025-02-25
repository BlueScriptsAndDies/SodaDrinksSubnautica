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
    public class StalkerSoda
    {
        public static PrefabInfo Info { get; private set; }



        public static void Register()
        {
            Info = PrefabInfo.WithTechType("StalkerSoda", "Stalker Soda", "A refreshing beverage made from stalkers ?").WithIcon(SpriteManager.Get(TechType.FilteredWater));
            var stalkersodaPrefab = new CustomPrefab(Info);

            var stalkersodaObj = new CloneTemplate(Info, TechType.FilteredWater);
            stalkersodaPrefab.SetGameObject(stalkersodaObj);
            {
                stalkersodaObj.ModifyPrefab = prefab1 =>
                {
                    Eatable eatable = prefab1.EnsureComponent<Eatable>();
                    eatable.waterValue = 100;
                };
            }


            var recipe = new RecipeData(new Ingredient(CarbonatedWater.Info.TechType), new Ingredient(TechType.StalkerTooth));
            stalkersodaPrefab.SetRecipe(recipe).WithCraftingTime(3f).WithFabricatorType(CraftTree.Type.Fabricator).WithStepsToFabricatorTab("Survival", "Water");
            stalkersodaPrefab.SetPdaGroupCategory(TechGroup.Survival,TechCategory.Water);
            stalkersodaPrefab.SetUnlock(TechType.StalkerTooth);





            stalkersodaPrefab.Register();
        }
    }

}
