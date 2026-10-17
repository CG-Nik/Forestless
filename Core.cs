using MelonLoader;
using Alta;
using UnityEngine;
using Alta.Woodcutting;
using System.Reflection;
using CustomDistributionAPI;
using Alta.Caves;
using Alta.Api.DataTransferModels.Extensions;
using UnityEngine.SceneManagement;
using Alta.Networking;

[assembly: MelonInfo(typeof(Forestless.Core), "Forestless", "1.0.0", "CGNik", null)]
[assembly: MelonGame("Alta", "A Township Tale")]

namespace Forestless
{
    public class Core : MelonMod
    {
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initialized.");
        }

        public override void OnLateInitializeMelon()
        {
            GameObject anyStandard = (GameObject)Resources.Load("network prefabs/woodcutting/spawners/Tree Spawner - Any Standard");
            TreeSpawner treeSpawner = anyStandard.GetComponent<TreeSpawner>();
            typeof(TreeSpawner).GetField("species", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(treeSpawner, TreeSpecies.All.ToArray());

            Distribution goteraDistribution = Distribution.All.Where(dist => dist.Hash == 13886u).First();
            CustomDistributionAPI.Core.AddToDistribution(
                goteraDistribution,
                ((GameObject)Resources.Load("network prefabs/creatures/monsters/gotera variants/Gotera Birch Variant")).GetComponent<NetworkPrefab>(),
                0.2f,
                0.2f,
                new AttributeCurveRange[] { }
            );
            CustomDistributionAPI.Core.AddToDistribution(
                goteraDistribution,
                ((GameObject)Resources.Load("network prefabs/creatures/monsters/gotera variants/Gotera Walnut Variant")).GetComponent<NetworkPrefab>(),
                0.1f,
                0.1f,
                new AttributeCurveRange[] { }
            );
            CustomDistributionAPI.Core.AddToDistribution(
                goteraDistribution,
                ((GameObject)Resources.Load("network prefabs/creatures/monsters/gotera variants/Gotera Ash Variant")).GetComponent<NetworkPrefab>(),
                0.05f,
                0.05f,
                new AttributeCurveRange[] { }
            );
            CustomDistributionAPI.Core.AddToDistribution(
                goteraDistribution,
                ((GameObject)Resources.Load("network prefabs/creatures/monsters/gotera variants/Gotera Redwood Variant")).GetComponent<NetworkPrefab>(),
                0.05f,
                0.05f,
                new AttributeCurveRange[] { }
            );
        }
    }
}