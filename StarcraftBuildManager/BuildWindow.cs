using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarcraftBuildManager
{
    public partial class BuildWindow : Form
    {
        //Methods and main variables
        MainVariables mainVariables;
        MainMethods mainMethods;
        MainFrame mainFrame;

        //The Lists for everything
        List<string> stringSafeList, prefabTypeList, targetTimeList, loadedList, givenPrefabTimestamps;
        string[] nextPartSafeArray;
        List<int> prefabTimestampList, prefabIndexList, prefabNumberList;
        int listWalker = 0, addedToLists = 0, nextTime = 0, nextIndex = 0, timestampWalker = 0, currentWorkerInProgress = 0;
        string targetListAddAstring, nextType = "";

        public List<string> Safe_List
        { get { return stringSafeList; } set { stringSafeList = value; } }
        Prefab nextPrefab;


        //UI Elements
        PictureBox[] building_Pictureboxes, upgrade_Pictureboxes, unit_Pictureboxes;
        int timeProgressor = -1,  optimizeProgressor = -1;

        //Calling used prefabs
        //ZERG
        int larvaeCount = 3;

        //Zerg Buildings
        Prefab hatchery, lair, hive, zerg_Extractor, spawning_Pool, evolution_Chamber, spine_Crawler, spore_Crawler,
        hydralisk_Den, baneling_Nest, roach_Warren, infestation_Pit, spire, greater_Spire, nydus_Network, ultralisk_Cavern, lurker_Den;
        
        Prefab[] building_Array;

        public Prefab[] Building_Array
        { get { return building_Array; } }

        //Zerg Units
        Prefab baneling, brood_Lord, corruptor, drone, hydralisk, infestor, lurker, mutalisk, overlord, overseer, queen,
            ravager, roach, swarm_Host, ultralisk, viper, zergling;
       
        Prefab[] unit_Array;
        public Prefab[] Unit_Array
        { get { return unit_Array; } }
        
        //Zerg Upgrades
        Prefab adaptive_Talons, adrenal_Glands, anabolic_Synthesis, burrow, centrifugal_Hooks, chitinious_Plating, flyer_Attacks1, flyer_Attacks2, flyer_Attacks3,
            flyer_Carapace1, flyer_Carapace2, flyer_Carapace3, glial_Reconstitution, grooved_Spines, ground_Carapace1, ground_Carapace2, ground_Carapace3, melee_Attacks1, melee_Attacks2, melee_Attacks3, metabolic_Boost,
            missile_Attacks1, missile_Attacks2, missile_Attacks3, muscular_Augments, neural_Parasite, pathogen_Glands, pneumatized_Carapace, seismic_Spines, tunneling_Claws;

        Prefab[] upgrade_Array;
        public Prefab[] Upgrade_Array
        { get { return upgrade_Array; } }

        //PROTOSS
        //Buildings
        Prefab assimilator, cybernetics_Core, dark_Shrine, fleetBeacon, forge, gateway, nexus, photon_Cannon, pylon, robotics_bay,
            robotics_Facility, stargate, templar_Archives, twilight_Council, shieldBattery;
        //units
        Prefab adept, archon, carrier, colossus, dark_Templar, disruptor, high_Templar, immortal, mothership, mothership_Core,
            observer, oracle, phoenix, probe, sentry, stalker, tempest, warp_Prism, zealot, void_Ray;
        //Upgrades
        Prefab air_Armor1, air_Armor2, air_Armor3, air_WeaponAttack1, air_WeaponAttack2, air_WeaponAttack3, anion_Pulse_Crystals, blink,
            charge, extended_Thermal_Lance, flux_Vanes, gravitic_Booster, gravitic_Drive, gravitron_Catapult, ground_Armor1, ground_Armor2,
            ground_Armor3, ground_Attack1, ground_Attack2, ground_Attack3, shields1, shields2, shields3, hallucination, psionic_Storm,
            resonating_Glaives, shadow_Stride, tectonic_Destabilizers, warpgate;
        //TERRAN
        //Buildings
        Prefab armory, barracks, bunker, command_Center, engineering_Bay, factory, fusion_Core, ghost_Academy, missile_Turret, orbital_Command,
            planetary_Fortress, refinery, sensor_Tower, starport, supply_Depot;
        //Units
        Prefab banshee, battlecruiser, cyclone, ghost, hellion, liberator, marauder, space_Marine, medivac, raven, reaper,
            scv, siege_Tank, thor, viking, widow_Mine;
        //Upgrades
        Prefab advanced_Ballistics, cloaking_Field, combat_Shield, concussive_Shells, corvid_Reactor, drilling_Claws, enhanced_Shockwave,
            hisec_Auto_Tracking, hyperflight_Rotor, infantry_Armor1, infantry_Armor2, infantry_Armor3, infantry_Weapon1, infantry_Weapon2, infantry_Weapon3,
            infernal_Preigniter, magfield_Accelerator, neosteel_Armor, personal_Cloaking, rapid_Resignition_System, ship_Weapons1, ship_Weapons2, ship_Weapons3,
            smart_Servos, stimpack, vehicle_Weapon1, vehicle_Weapon2, vehicle_Weapon3, vehicle_And_Ship_Plating1, vehicle_And_Ship_Plating2, vehicle_And_Ship_Plating3,
            weapon_Refit;
        //Variables uses by every race
        Prefab workerPrefabNorm, supplyPrefabNorm, mainPrefabNorm, extractorPrefabNorm;
        int workerCountMinerals = 12, workerCountVespin = 0, supply, mainBuildingCount = 1, extractorCount = 0;
        float mineralCollectionRate = 0.96f, vespinCollectionRate = 1f, vespinCollectionRateLow = 0.9f, mineralCount = 50, vespinCount = 0;
        bool supplyInProgress = false, extractorInProgress = false;

        public BuildWindow(string race, MainVariables givenMainVariables, MainFrame givenMainFrame, List<string> givenLoadedList = null)
        {
            //initialzing UI
            InitializeComponent();

            mainVariables = givenMainVariables;
            mainMethods = new MainMethods(this);
            mainFrame = givenMainFrame;
            mainVariables.Active_Race = race;
            loadedList = givenLoadedList;
            givenPrefabTimestamps = new List<string> { };

            building_Pictureboxes = new PictureBox[] {picbBuilding1, picbBuilding2, picbBuilding3, picbBuilding4, picbBuilding5, picbBuilding6, picbBuilding7, picbBuilding8, picbBuilding9, picbBuilding10, 
            picbBuilding11, picbBuilding12, picbBuilding13, picbBuilding14, picbBuilding15, picbBuilding16, picbBuilding17, picbBuilding18};
            unit_Pictureboxes = new PictureBox[] {picbUnit1, picbUnit2, picbUnit3, picbUnit4, picbUnit5, picbUnit6, picbUnit7, picbUnit8, picbUnit9, picbUnit10, picbUnit11, picbUnit12, picbUnit13, picbUnit14,
            picbUnit15, picbUnit16, picbUnit17, picbUnit18, picbUnit19, picturepicbUnit20, picbUnit21, picbUnit22, picbUnit23, picbUnit24, picbUnit25, picbUnit26, picbUnit27, picbUnit28, picbUnit29, picbUnit30};
            upgrade_Pictureboxes = new PictureBox[] {picbUpgrade1, picbUpgrade2, picbUpgrade3, picbUpgrade4, picbUpgrade5, picbUpgrade6, picbUpgrade7, picbUpgrade8, picbUpgrade9, picbUpgrade10, picbUpgrade11,
            picbUpgrade12, picbUpgrade13, picbUpgrade14, picbUpgrade15, picbUpgrade16, picbUpgrade17, picbUpgrade18, picbUpgrade19, picbUpgrade20, picbUpgrade21, picbUpgrade22, picbUpgrade23, picbUpgrade24, picbUpgrade25,
            picbUpgrade26, picbUpgrade27, picbUpgrade28, picbUpgrade29, picbUpgrade30, picbUpgrade31, picbUpgrade32, picbUpgrade33, picbUpgrade34, picbUpgrade35, picbUpgrade36, picbUpgrade37,
            picbUpgrade38, picbUpgrade39, picbUpgrade40, picbUpgrade41, picbUpgrade42};

            this.BackgroundImage = mainVariables.BuildWindow_BackgroundBM;
            picbTooltipTime.Image = mainVariables.BuildingArea_UiClockBM;
            picbMinerals.Image = mainVariables.BuildingArea_UiMineralsBM;
            picbVespin.Image = mainVariables.BuildingArea_UiVespinBM;
            picBOptimize.Image = mainVariables.BuildingArea_OptimizeBM;
            picBStartRunner.Image = mainVariables.BuildingArea_StartBM;
            picBArrowDown.Image = mainVariables.BuildingArea_ArrowDownBM;
            picBArrowUp.Image = mainVariables.BuildingArea_ArrowUpBM;
            picBBackToMenu.Image = mainVariables.BuildingArea_BackToMenu;
            picBSafe.Image = mainVariables.Building_Area_SafeIconBM;
            
            trackbarTimeline.Location = new Point(39, 46);
            lblTimeEnd.Location = new Point(36, 30);
            lbltimeStart.Location = new Point(36, 625);
            
            lblNow.Location = new Point(162, 329);
            lblPreviousFirst.Location = new Point(162, 474);
            lblPreviousMid.Location = new Point(162, 527);
            picBPreviousLast.Location = new Point(162, 581);
            lblNextFirst.Location = new Point(162, 180);
            lblNextMid.Location = new Point(162, 124);
            lblNextLast.Location = new Point(162, 68);
            picBPreviousLast.Location = new Point(106, 562);


            lblCurrentTrackbarValue.Text = trackbarTimeline.Value.ToString();
            mainMethods.Fill_Picturebox(picbExit, mainVariables.BuildingArea_UiCloseBM);

            switch (race)
            {
                case "Zerg":
                    Zerg();
                    break;
                case "Protoss":
                    Protoss();
                    break;
                case "Terran":
                    Terran();
                    break;
            }

            //What happens when a list was loaded
            if (loadedList != null)
            {
                stringSafeList = loadedList;
                prefabIndexList = new List<int> { };
                prefabTimestampList = new List<int> { };
                prefabTypeList = new List<string> { };
                prefabNumberList = new List<int> { };
                for (int i = 1; i < stringSafeList.Count; i++)
                {
                    string[] loadStringArray = stringSafeList[i].Split('_');
                    prefabTimestampList.Add(Convert.ToInt32(loadStringArray[0]));
                    prefabTypeList.Add(loadStringArray[1]);
                    prefabIndexList.Add(Convert.ToInt32(loadStringArray[2]));
                    prefabNumberList.Add(Convert.ToInt32(loadStringArray[3]));
                }
                Update_Timeline(0);
            }
            else
            {
                stringSafeList = new List<string> { };
            }

            this.Icon = mainVariables.BuildManager_Icon;
        }

        public void Zerg()
        {              
            //Initializing the Buildings and set them on their place in the UI
            hatchery = new Prefab("Hatchery", 300, 0, 100, mainVariables.HatcheryBM, 4);
            lair = new Prefab("Lair", 150, 100, 80, mainVariables.LairBM);
            hive = new Prefab("Hive", 200, 150, 100, mainVariables.HiveBM);
            zerg_Extractor = new Prefab("Extractor", 25, 0, 30, mainVariables.Zerg_ExtractorBM, 1);
            spawning_Pool = new Prefab("Spawning Pool", 200, 0, 65, mainVariables.Spawning_PoolBM, 1);
            evolution_Chamber = new Prefab("Evolution Chamber", 75, 0, 35, mainVariables.Evolution_ChamberBM, 1);
            spine_Crawler = new Prefab("Spine Crawler", 100, 0, 50, mainVariables.Spine_CrawlerBM, 1);
            spore_Crawler = new Prefab("Spore Crawler", 75, 0, 30, mainVariables.Spore_CrawlerBM, 1);
            hydralisk_Den = new Prefab("Hydralisk Den", 100, 100, 60, mainVariables.Hydralisk_DenBM, 1);
            baneling_Nest = new Prefab("Baneling Nest", 100, 50, 60, mainVariables.Baneling_NestBM, 1);
            roach_Warren = new Prefab("Roach Warren", 150, 0, 55, mainVariables.Roach_WarrenBM, 1);
            infestation_Pit = new Prefab("Infestation Pit", 100, 100, 50, mainVariables.Infestation_PitBM, 1);
            spire = new Prefab("Spire", 200, 200, 100, mainVariables.SpireBM, 1);
            greater_Spire = new Prefab("Greater Spire", 100, 150, 100, mainVariables.Greater_SpireBM);
            nydus_Network = new Prefab("Nydus Network", 150, 200, 50, mainVariables.Nydus_NetworkBM, 1);
            ultralisk_Cavern = new Prefab("Ultralisk Cavern", 150, 200, 65, mainVariables.Ultralisk_CavernBM, 1);
            lurker_Den = new Prefab("Lurker Den", 150, 100, 57, mainVariables.Lurker_DenBM, 1);

            building_Array = new Prefab[] {hatchery, lair, hive, zerg_Extractor, spawning_Pool, evolution_Chamber, spine_Crawler, spore_Crawler,
            hydralisk_Den, baneling_Nest, roach_Warren, infestation_Pit, spire, greater_Spire, nydus_Network, ultralisk_Cavern, lurker_Den};

            mainMethods.Fill_Picturebox_Array(building_Pictureboxes, building_Array);
            //Initialzing units 

            baneling = new Prefab("Baneling", 50, 25, 44, mainVariables.BanelingBM, -1);
            drone = new Prefab("Drone", 50, 0, 17, mainVariables.DroneBM, -1);
            overlord = new Prefab("Overlord", 100, 0, 25, mainVariables.OverlordBM, 8);
            zergling = new Prefab("Zergling", 50, 0, 24, mainVariables.ZerglingBM, -1);
            roach = new Prefab("Roach", 75, 25, 27, mainVariables.RoachBM, -2);
            queen = new Prefab("Queen", 150, 0, 50, mainVariables.QueenBM, -2);
            hydralisk = new Prefab("Hydralisk", 100, 50, 33, mainVariables.HydraliskBM, -2);
            mutalisk = new Prefab("Mutalisk", 100, 100, 33, mainVariables.MutaliskBM, -2);
            corruptor = new Prefab("Corrupter", 150, 100, 40, mainVariables.CorrupterBM, -4);
            infestor = new Prefab("Infestor", 100, 150, 50, mainVariables.InfestorBM, -2);
            swarm_Host = new Prefab("Swarm Host", 200, 100, 40, mainVariables.Swarm_HostBM, -3);
            ultralisk = new Prefab("Ultralisk", 300, 200, 55, mainVariables.UltraliskBM, -6);
            viper = new Prefab("Viper", 100, 200, 40, mainVariables.ViperBM, -3);
            brood_Lord = new Prefab("Brood Lord", 300, 250, 77, mainVariables.Boord_LordBM, -4);
            overseer = new Prefab("Overseer", 150, 50, 42, mainVariables.OverseerBM);
            lurker = new Prefab("Lurker", 150, 100, 42, mainVariables.LurkerBM, -3);
            ravager = new Prefab("Ravager", 100, 100, 28, mainVariables.RavagerBM, -3);
            
            unit_Array = new Prefab[] {baneling, brood_Lord, corruptor, drone, hydralisk, infestor, lurker, mutalisk, overlord, overseer, queen,
            ravager, roach, swarm_Host, ultralisk, viper, zergling};
            
            mainMethods.Fill_Picturebox_Array(unit_Pictureboxes, unit_Array);

            supplyPrefabNorm = overlord;
            workerPrefabNorm = drone;
            mainPrefabNorm = hatchery;
            extractorPrefabNorm = zerg_Extractor;
            supply = 2;

            //Initialzing upgrades
            melee_Attacks1 = new Prefab("Melee Attacks 1", 100, 100, 114, mainVariables.Melee_AttacksBM);
            melee_Attacks2 = new Prefab("Melee Attacks 2", 150, 150, 136, mainVariables.Melee_AttacksBM);
            melee_Attacks3 = new Prefab("Melee Attacks 3", 200, 200, 157, mainVariables.Melee_AttacksBM);
            ground_Carapace1 = new Prefab("Ground Carapace 1", 150, 150, 114, mainVariables.Ground_CarapaceBM);
            ground_Carapace2 = new Prefab("Ground Carapace 2", 225, 225, 136, mainVariables.Ground_CarapaceBM);
            ground_Carapace3 = new Prefab("Ground Carapace 3", 300, 300, 257, mainVariables.Ground_CarapaceBM);
            missile_Attacks1 = new Prefab("Missile Attacks 1", 100, 100, 114, mainVariables.Missile_AttacksBM);
            missile_Attacks2 = new Prefab("Missile Attacks 2", 150, 150, 136, mainVariables.Missile_AttacksBM);
            missile_Attacks3 = new Prefab("Missile Attacks 3", 200, 200, 157, mainVariables.Missile_AttacksBM);
            flyer_Attacks1 = new Prefab("Flyer Attacks 1", 100, 100, 114, mainVariables.Zerg_FlyerAttacksBM);
            flyer_Attacks2 = new Prefab("Flyer Attacks 2", 175, 175, 136, mainVariables.Zerg_FlyerAttacksBM);
            flyer_Attacks3 = new Prefab("Flyer Attacks 3", 250, 250, 157, mainVariables.Zerg_FlyerAttacksBM);
            flyer_Carapace1 = new Prefab("Flyer Carapace 1", 150, 150, 114, mainVariables.Flyer_CarapaceBM);
            flyer_Carapace2 = new Prefab("Flyer Carapace 2", 225, 225, 136, mainVariables.Flyer_CarapaceBM);
            flyer_Carapace3 = new Prefab("Flyer Carapace 3", 300, 300, 157, mainVariables.Flyer_CarapaceBM);
            chitinious_Plating = new Prefab("Chitinious Plating", 150, 150, 79, mainVariables.Chitinous_PlatingBM);
            adaptive_Talons = new Prefab("Adaptive Talons", 150, 150, 57, mainVariables.Adaptive_TalonsBM);
            anabolic_Synthesis = new Prefab("Anabolic Synthesis", 150, 150, 43, mainVariables.Anabolic_SynthesisBM);
            centrifugal_Hooks = new Prefab("Centrifugal Hooks", 150, 150, 79, mainVariables.Centrifugal_HooksBM);
            glial_Reconstitution = new Prefab("Glial Reconstitution", 100, 100, 79, mainVariables.Glial_ReconstitutionBM);
            metabolic_Boost = new Prefab("Metabolic Boost", 100, 100, 79, mainVariables.Metabolic_BoostBM);
            pneumatized_Carapace = new Prefab("Pneumatized Carapace", 100, 100, 43, mainVariables.Pneumatited_CarapaceBM);
            muscular_Augments = new Prefab("Muscular Augments", 100, 100, 71, mainVariables.Muscular_AugmentsBM);
            grooved_Spines = new Prefab("Grooved Spines", 100, 100, 71, mainVariables.Grooved_SpinesBM);
            seismic_Spines = new Prefab("Seismic Spines", 150, 150, 57, mainVariables.Seismic_SpinesBM);
            burrow = new Prefab("Burrow", 100, 100, 71, mainVariables.BurrowBM);
            pathogen_Glands = new Prefab("Pathogen Glands", 150, 150, 57, mainVariables.Pathogen_GlandsBM);
            neural_Parasite = new Prefab("Neural Parasite", 150, 150, 79, mainVariables.Neural_ParasiteBM);
            adrenal_Glands = new Prefab("Adrenal Glands", 200, 200, 93, mainVariables.Adrenal_GlandsBM);
            tunneling_Claws = new Prefab("Tunneling Claws", 100, 100, 79, mainVariables.Tunneling_ClawsBM);

            upgrade_Array = new Prefab[] {adaptive_Talons, adrenal_Glands, anabolic_Synthesis, burrow, centrifugal_Hooks, chitinious_Plating, flyer_Attacks1,
            flyer_Carapace1, glial_Reconstitution, grooved_Spines, ground_Carapace1, melee_Attacks1, metabolic_Boost,
            missile_Attacks1, muscular_Augments, neural_Parasite, pathogen_Glands, pneumatized_Carapace, seismic_Spines, tunneling_Claws};

            mainMethods.Fill_Picturebox_Array(upgrade_Pictureboxes, upgrade_Array);
        }
        public void Protoss()
        {
            //Units
            archon = new Prefab("Archon", 100, 300, 87, mainVariables.Archon_BM, -4);
            adept = new Prefab("Adept", 100, 25, 30, mainVariables.Adept_BM, -2);
            carrier = new Prefab("Carrier", 350, 250, 64, mainVariables.Carrier_BM, -6);
            colossus = new Prefab("Colossus", 300, 200, 54, mainVariables.Colossus_BM, -6);
            dark_Templar = new Prefab("Dark Templar", 125, 125, 29, mainVariables.DarkTemplar_BM, -2);
            disruptor = new Prefab("Disruptor", 150, 150, 36, mainVariables.Disruptor_BM, -3);
            high_Templar = new Prefab("High Templar", 50, 150, 39, mainVariables.HighTemplar_BM, -2);
            immortal = new Prefab("Immortal", 275, 100, 39, mainVariables.Immortal_BM, -4);
            mothership = new Prefab("Mothership", 300, 300, 71, mainVariables.Mothership_BM, -8);
            mothership_Core = new Prefab("Mothership Core", 100, 100, 21, mainVariables.MothershipCore_BM, -2);
            observer = new Prefab("Observer", 25, 75, 21, mainVariables.Observer_BM, -1);
            phoenix = new Prefab("Phoenix", 150, 100, 25, mainVariables.Phoenix_BM, -2);
            probe = new Prefab("Probe", 50, 0, 12, mainVariables.Probe_BM, -1);
            sentry = new Prefab("Sentry", 50, 100, 26, mainVariables.Sentry_BM, -2);
            stalker = new Prefab("Stalker", 125, 50, 30, mainVariables.Stalker_BM, -2);
            void_Ray = new Prefab("Void Ray", 200, 150, 37, mainVariables.VoidRaY_BM, -4);
            warp_Prism = new Prefab("Warp Prism", 250, 0, 36, mainVariables.WarpPrism_BM, -2);
            zealot = new Prefab("Zealot", 100, 0, 27, mainVariables.Zealot_BM, -2);
            oracle = new Prefab("Oracle", 150, 150, 37, mainVariables.Oracle_BM, -3);
            tempest = new Prefab("Tempest", 250, 175, 43, mainVariables.Tempest_BM, -5);

            unit_Array = new Prefab[] { archon, adept, carrier, colossus, dark_Templar, disruptor, high_Templar, immortal,
            mothership, mothership_Core, observer, phoenix, probe, sentry, stalker, void_Ray, warp_Prism, zealot, oracle, tempest };
            mainMethods.Fill_Picturebox_Array(unit_Pictureboxes, unit_Array);

            //Buildings
            nexus = new Prefab("Nexus", 400, 0, 71, mainVariables.Nexus_BM, 15);
            assimilator = new Prefab("Assimilator", 75, 0, 21, mainVariables.Assimilator_BM);
            cybernetics_Core = new Prefab("Cybernetics Core", 150, 0, 36, mainVariables.CyberneticsCore_BM);
            dark_Shrine = new Prefab("Dark Shrine", 150, 150, 71, mainVariables.DarkShrine_BM);
            fleetBeacon = new Prefab("Fleet Beacon", 300, 200, 43, mainVariables.FleetBeacon_BM);
            forge = new Prefab("Forge", 150, 0, 32, mainVariables.Forge_BM);
            gateway = new Prefab("Gateway", 150, 0, 46, mainVariables.Gateway_BM);
            photon_Cannon = new Prefab("Photon Cannon", 150, 0, 29, mainVariables.PhotonCannon_BM);
            pylon = new Prefab("Pylon", 100, 0, 18, mainVariables.Pylon_BM, 8);
            robotics_Facility = new Prefab("Robotics Facility", 150, 100, 46, mainVariables.RoboticsFacility_BM);
            robotics_bay = new Prefab("Robotics Bay", 150, 150, 46, mainVariables.RoboticsBay_BM);
            shieldBattery = new Prefab("Shield Battery", 100, 0, 29, mainVariables.Shieldbattery_BM);
            stargate = new Prefab("Stargate", 150, 150, 43, mainVariables.Stargate_BM);
            templar_Archives = new Prefab("Templar Archives", 150, 200, 36, mainVariables.TemplarArchives_BM);
            twilight_Council = new Prefab("Twilight Council", 150, 100, 36, mainVariables.TwilightCouncil_BM);

            building_Array = new Prefab[] {nexus, assimilator, cybernetics_Core, dark_Shrine, fleetBeacon, forge, gateway, photon_Cannon,
            pylon, robotics_Facility, robotics_bay, shieldBattery, stargate, templar_Archives, twilight_Council };
            mainMethods.Fill_Picturebox_Array(building_Pictureboxes, building_Array);

            //Upgrades
            ground_Attack1 = new Prefab("Ground Attack 1", 100, 100, 129, mainVariables.GroundAttack_BM);
            ground_Attack2 = new Prefab("Ground Attack 2", 150, 150, 154, mainVariables.GroundAttack_BM);
            ground_Attack3 = new Prefab("Ground Attack 3", 200, 200, 179, mainVariables.GroundAttack_BM);
            air_WeaponAttack1 = new Prefab("Air Weapon 1", 100, 100, 129, mainVariables.AirWeapon_BM);
            air_WeaponAttack2 = new Prefab("Air Weapon 2", 175, 175, 154, mainVariables.AirWeapon_BM);
            air_WeaponAttack3 = new Prefab("Air Weapon 3", 250, 250, 179, mainVariables.AirWeapon_BM);
            ground_Armor1 = new Prefab("Ground Armor 1", 100, 100, 129, mainVariables.GroundArmor_BM);
            ground_Armor2 = new Prefab("Ground Armor 2", 150, 150, 154, mainVariables.GroundArmor_BM);
            ground_Armor3 = new Prefab("Ground Armor 3", 200, 200, 179, mainVariables.GroundArmor_BM);
            air_Armor1 = new Prefab("Air Armor 1", 150, 150, 129, mainVariables.AirArmor_BM);
            air_Armor2 = new Prefab("Air Armor 2", 225, 225, 154, mainVariables.AirArmor_BM);
            air_Armor3 = new Prefab("Air Armor 3", 300, 300, 179, mainVariables.AirArmor_BM);
            shields1 = new Prefab("Shields 1", 150, 150, 129, mainVariables.Shields_BM);
            shields2 = new Prefab("Shields 2", 225, 225, 154, mainVariables.Shields_BM);
            shields3 = new Prefab("Shields 3", 300, 300, 179, mainVariables.Shields_BM);
            charge = new Prefab("Charge", 100, 100, 100, mainVariables.Charge_BM);
            gravitic_Drive = new Prefab("Gravitic Drive", 100, 100, 57, mainVariables.GraviticDrive_BM);
            gravitic_Booster = new Prefab("Gravitic Boosters", 100, 100, 57, mainVariables.GraviticBooster_BM);
            flux_Vanes = new Prefab("Flux Vanes", 100, 100, 57, mainVariables.FluxVanes_BM);
            resonating_Glaives = new Prefab("Resonating Glaives", 100, 100, 100, mainVariables.ResonatingGlaives_BM);
            anion_Pulse_Crystals = new Prefab("Anion Pulse-Crystals", 150, 150, 64, mainVariables.AnionPulseCrystals_BM);
            extended_Thermal_Lance = new Prefab("Extended Thermal Lance", 150, 150, 100, mainVariables.ExtendedThermalLance_BM);
            psionic_Storm = new Prefab("Psionic Storm", 200, 200, 79, mainVariables.Psionic_Storm_BM);
            blink = new Prefab("Blink", 150, 150, 121, mainVariables.Blink_BM);
            hallucination = new Prefab("Hallucination", 100, 100, 80, mainVariables.Hallucination_BM);
            shadow_Stride = new Prefab("Shadow Stride", 100, 100, 100, mainVariables.ShadowStride_BM);
            warpgate = new Prefab("Warpgate", 50, 50, 100, mainVariables.Warpgate_BM);
            tectonic_Destabilizers = new Prefab("Tectonic Destabilizers", 150, 150, 100, mainVariables.TectonicDestabilizers_BM);
            gravitron_Catapult = new Prefab("Graviton Catapult", 150, 150, 57, mainVariables.GravitronCatapult_BM);

            upgrade_Array = new Prefab[] {ground_Attack1, ground_Armor1, shields1, air_Armor1, air_WeaponAttack1, charge, gravitic_Drive,
            gravitic_Booster, flux_Vanes, resonating_Glaives, anion_Pulse_Crystals, extended_Thermal_Lance, psionic_Storm, blink, hallucination,
            shadow_Stride, warpgate, tectonic_Destabilizers, gravitron_Catapult};
            mainMethods.Fill_Picturebox_Array(upgrade_Pictureboxes, upgrade_Array);

            supplyPrefabNorm = pylon;
            workerPrefabNorm = probe;
            mainPrefabNorm = nexus;
            extractorPrefabNorm = assimilator;
            supply = 2;
        }
        public void Terran()
        {
            //Buildings
            armory = new Prefab("Armory", 150, 100, 46, mainVariables.Armory_BM);
            barracks = new Prefab("Barracks", 150, 100, 46, mainVariables.Barracks_BM);
            bunker = new Prefab("Bunker", 100, 0, 29, mainVariables.Bunker_BM);
            command_Center = new Prefab("Command Center", 400, 0, 71, mainVariables.CommandCenter_BM, 15);
            orbital_Command = new Prefab("Orbital Command", 150, 0, 25, mainVariables.OrbitalCommand_BM);
            planetary_Fortress = new Prefab("Planetary Fortress", 150, 150, 36, mainVariables.PlanetaryFortress_BM);
            engineering_Bay = new Prefab("Engineering Bay", 125, 0, 35, mainVariables.EngineeringBay_BM);
            factory = new Prefab("Factory", 150, 100, 43, mainVariables.Factory_BM);
            fusion_Core = new Prefab("Fusion Core", 150, 150, 46, mainVariables.FusionCore_BM);
            ghost_Academy = new Prefab("Ghost Academy", 150, 50, 29, mainVariables.GhostAcademy_BM);
            missile_Turret = new Prefab("Missile Turret", 100, 0, 18, mainVariables.MissilyTurret_BM);
            refinery = new Prefab("Refinery", 75, 0, 21, mainVariables.Refinery_BM);
            sensor_Tower = new Prefab("Sensor Tower", 125, 100, 18, mainVariables.SensorTower_BM);
            starport = new Prefab("Starport", 150, 100, 36, mainVariables.Starport_BM);
            supply_Depot = new Prefab("Supply Depot", 100, 0, 21, mainVariables.SupplyDepot_BM);

            building_Array = new Prefab[] {command_Center, supply_Depot, refinery, orbital_Command, planetary_Fortress, barracks, bunker,
            engineering_Bay, factory, fusion_Core, ghost_Academy, missile_Turret, sensor_Tower, starport };

            mainMethods.Fill_Picturebox_Array(building_Pictureboxes, building_Array);

            //Units
            banshee = new Prefab("Banshee", 150, 100, 43, mainVariables.Banshee_BM, -3);
            battlecruiser = new Prefab("Battlecruiser", 400, 300, 64, mainVariables.BattleCruiser_BM, -6);
            ghost = new Prefab("Ghost", 150, 125, 29, mainVariables.Ghost_BM, -2);
            hellion = new Prefab("Hellion", 100, 0, 21, mainVariables.Hellion_BM, -2);
            marauder = new Prefab("Marauder", 100, 25, 30, mainVariables.Marauder_BM, -2);
            space_Marine = new Prefab("Space Marine", 50, 0, 25, mainVariables.SpaceMarine_BM, -1);
            medivac = new Prefab("Medivac", 100, 100, 30, mainVariables.Medivac_BM, -2);
            raven = new Prefab("Raven", 100, 200, 43, mainVariables.Raven_BM, -2);
            reaper = new Prefab("Reaper", 50, 50, 32, mainVariables.Reaper_BM, -1);
            scv = new Prefab("SCV", 50, 0, 12, mainVariables.SCV_BM, -1);
            siege_Tank = new Prefab("Siege Tank", 150, 125, 31, mainVariables.SiegeTank_BM, -3);
            thor = new Prefab("Thor", 300, 200, 43, mainVariables.Thor_BM, -6);
            viking = new Prefab("Viking", 150, 75, 30, mainVariables.Viking_BM, -2);
            widow_Mine = new Prefab("Widow Mine", 75, 25, 21, mainVariables.WidowMine_BM, -2);
            liberator = new Prefab("Liberator", 150, 150, 43, mainVariables.Liberator_BM, -3);
            cyclone = new Prefab("Cyclone", 150, 100, 32, mainVariables.Cyclone_BM, -3);

            unit_Array = new Prefab[] {scv, space_Marine, banshee, battlecruiser, ghost, hellion, marauder, space_Marine, medivac,
            raven, reaper, siege_Tank, thor, viking, widow_Mine, liberator, cyclone};

            mainMethods.Fill_Picturebox_Array(unit_Pictureboxes, unit_Array);

            //Upgrades
            infantry_Weapon1 = new Prefab("Infantry Weapon 1", 100, 100, 114, mainVariables.InfantryWeapon_BM);
            infantry_Weapon2 = new Prefab("Infantry Weapon 2", 175, 175, 136, mainVariables.InfantryWeapon_BM);
            infantry_Weapon3 = new Prefab("Infantry Weapon 3", 250, 250, 157, mainVariables.InfantryWeapon_BM);
            infantry_Armor1 = new Prefab("Infantry Armor 1", 100, 100, 114, mainVariables.InfantryArmor_BM);
            infantry_Armor2 = new Prefab("Infantry Armor 2", 175, 175, 136, mainVariables.InfantryArmor_BM);
            infantry_Armor3 = new Prefab("Infantry Armor 3", 250, 250, 157, mainVariables.InfantryArmor_BM);
            vehicle_Weapon1 = new Prefab("Vehicle Weapon 1", 100, 100, 114, mainVariables.VehicleWeapon_BM);
            vehicle_Weapon2 = new Prefab("Vehicle Weapon 2", 175, 175, 136, mainVariables.VehicleWeapon_BM);
            vehicle_Weapon3 = new Prefab("Vehicle Weapon 3", 250, 250, 157, mainVariables.VehicleWeapon_BM);
            ship_Weapons1 = new Prefab("Ship Weapon 1", 100, 100, 114, mainVariables.ShipWeapons_BM);
            ship_Weapons2 = new Prefab("Ship Weapon 2", 175, 175, 136, mainVariables.ShipWeapons_BM);
            ship_Weapons3 = new Prefab("Ship Weapon 3", 250, 250, 157, mainVariables.ShipWeapons_BM);
            vehicle_And_Ship_Plating1 = new Prefab("VS Plating 1", 100, 100, 114, mainVariables.VehicleAndShipPlating_BM);
            vehicle_And_Ship_Plating2 = new Prefab("VS Plating 2", 175, 175, 136, mainVariables.VehicleAndShipPlating_BM);
            vehicle_And_Ship_Plating3 = new Prefab("VS Plating 3", 250, 250, 157, mainVariables.VehicleAndShipPlating_BM);
            hyperflight_Rotor = new Prefab("Hyperflight Rotor", 150, 150, 121, mainVariables.HyperFlightRotor_BM);
            smart_Servos = new Prefab("Smart Servos", 100, 100, 79, mainVariables.SmartServos_BM);
            rapid_Resignition_System = new Prefab("Rapid Reignition System", 100, 100, 57, mainVariables.RapidReignitionSystem_BM);
            advanced_Ballistics = new Prefab("Advanced Ballistics", 150, 150, 79, mainVariables.AdvancedBallistics_BM);
            hisec_Auto_Tracking = new Prefab("Hi-Sec Auto Tracking", 100, 100, 57, mainVariables.HisecAutoTracking_BM);
            enhanced_Shockwave = new Prefab("Enhanced Shockwaves", 150, 150, 79, mainVariables.EnhancedShockwaves_BM);
            magfield_Accelerator = new Prefab("Mag-Field Accelerator", 100, 100, 100, mainVariables.MagfieldAccelerator_BM);
            cloaking_Field = new Prefab("Cloaking Field", 100, 100, 79, mainVariables.CloakingField_BM);
            concussive_Shells = new Prefab("Concussive Shells", 50, 50, 43, mainVariables.ConcussiveShells_BM);
            personal_Cloaking = new Prefab("Personal Cloaking", 150, 150, 86, mainVariables.PersonalCloaking_BM);
            stimpack = new Prefab("Stimpack", 100, 100, 100, mainVariables.Stimpack_BM);
            weapon_Refit = new Prefab("Weapon Refit", 150, 150, 100, mainVariables.WeaponRefit_BM);
            corvid_Reactor = new Prefab("Corvid Reactor", 150, 150, 79, mainVariables.CorvidReactor_BM);
            drilling_Claws = new Prefab("Drilling Claws", 75, 75, 79, mainVariables.DrillingClaws_BM);
            combat_Shield = new Prefab("Combad Shield", 100, 100, 79, mainVariables.CombatShield_BM);
            neosteel_Armor = new Prefab("Neosteel Armor", 150, 150, 100, mainVariables.NeosteelArmor_BM);
            infernal_Preigniter = new Prefab("Infernal Pre-Igniter", 100, 100, 79, mainVariables.InfernalPreigniter_BM);

            upgrade_Array = new Prefab[] {infantry_Armor1, infantry_Weapon1, vehicle_Weapon1, ship_Weapons1, vehicle_And_Ship_Plating1,
            hyperflight_Rotor, smart_Servos, rapid_Resignition_System, advanced_Ballistics, hisec_Auto_Tracking, enhanced_Shockwave,
            magfield_Accelerator, cloaking_Field, concussive_Shells, personal_Cloaking, stimpack, weapon_Refit, corvid_Reactor, drilling_Claws,
            combat_Shield, neosteel_Armor, infernal_Preigniter };

            mainMethods.Fill_Picturebox_Array(upgrade_Pictureboxes, upgrade_Array);

            supplyPrefabNorm = supply_Depot;
            workerPrefabNorm = scv;
            mainPrefabNorm = command_Center;
            extractorPrefabNorm = refinery;
            supply = 2;


        }

        //Updating tooltip by clicking on pictures and show the data
        #region BuildingOnClick
        private void PicbBuilding8_Click(object sender, EventArgs e)
        { Update_Tooltip(building_Array[7]); }

        private void PicbBuilding9_Click(object sender, EventArgs e)
        { Update_Tooltip(building_Array[8]); }

        private void PicbBuilding10_Click(object sender, EventArgs e)
        { Update_Tooltip(building_Array[9]); }

        private void PicbBuilding11_Click(object sender, EventArgs e)
        { Update_Tooltip(building_Array[10]); }

        private void PicbBuilding12_Click(object sender, EventArgs e)
        { Update_Tooltip(building_Array[11]); }

        private void PicbBuilding13_Click(object sender, EventArgs e)
        { Update_Tooltip(building_Array[12]); }

        private void PicbBuilding14_Click(object sender, EventArgs e)
        { Update_Tooltip(building_Array[13]); }

        private void PicbBuilding15_Click(object sender, EventArgs e)
        { Update_Tooltip(building_Array[14]); }

        private void PicbBuilding16_Click(object sender, EventArgs e)
        { Update_Tooltip(building_Array[15]); }

        private void PicbBuilding17_Click(object sender, EventArgs e)
        { Update_Tooltip(building_Array[16]); }

        private void PicbBuilding18_Click(object sender, EventArgs e)
        { Update_Tooltip(building_Array[17]); }

        private void PicbBuilding7_Click(object sender, EventArgs e)
        { Update_Tooltip(building_Array[6]); }

        private void PicbBuilding6_Click(object sender, EventArgs e)
        { Update_Tooltip(building_Array[5]); }

        private void PicbBuilding5_Click(object sender, EventArgs e)
        { Update_Tooltip(building_Array[4]); }

        private void PicbBuilding4_Click(object sender, EventArgs e)
        { Update_Tooltip(building_Array[3]); }

        private void PicbBuilding3_Click(object sender, EventArgs e)
        { Update_Tooltip(building_Array[2]);  }

        private void PicbBuilding2_Click(object sender, EventArgs e)
        { Update_Tooltip(building_Array[1]); }

        private void PicbBuilding1_Click(object sender, EventArgs e)
        { Update_Tooltip(building_Array[0]); }
        #endregion

        #region UnitOnClick
        private void picbUnit7_Click(object sender, EventArgs e)
        { Update_Tooltip(unit_Array[6]); }

        private void picbUnit8_Click(object sender, EventArgs e)
        { Update_Tooltip(unit_Array[7]); }

        private void picbUnit9_Click(object sender, EventArgs e)
        { Update_Tooltip(unit_Array[8]); }

        private void picbUnit10_Click(object sender, EventArgs e)
        { Update_Tooltip(unit_Array[9]); }

        private void picbUnit11_Click(object sender, EventArgs e)
        { Update_Tooltip(unit_Array[10]); }

        private void picbUnit12_Click(object sender, EventArgs e)
        { Update_Tooltip(unit_Array[11]); }

        private void picbUnit13_Click(object sender, EventArgs e)
        { Update_Tooltip(unit_Array[12]); }

        private void picbUnit14_Click(object sender, EventArgs e)
        { Update_Tooltip(unit_Array[13]); }

        private void picbUnit15_Click(object sender, EventArgs e)
        { Update_Tooltip(unit_Array[14]); }

        private void picbUnit16_Click(object sender, EventArgs e)
        { Update_Tooltip(unit_Array[15]); }

        private void picbUnit17_Click(object sender, EventArgs e)
        { Update_Tooltip(unit_Array[16]); }

        private void picbUnit18_Click(object sender, EventArgs e)
        { Update_Tooltip(unit_Array[17]); }

        private void picbUnit19_Click(object sender, EventArgs e)
        { Update_Tooltip(unit_Array[18]); }

        private void picturepicbUnit20_Click(object sender, EventArgs e)
        { Update_Tooltip(unit_Array[19]); }

        private void picbUnit21_Click(object sender, EventArgs e)
        { Update_Tooltip(unit_Array[20]);  }

        private void picbUnit22_Click(object sender, EventArgs e)
        { Update_Tooltip(unit_Array[21]); }

        private void picbUnit23_Click(object sender, EventArgs e)
        { Update_Tooltip(unit_Array[22]); }

        private void picbUnit24_Click(object sender, EventArgs e)
        { Update_Tooltip(unit_Array[23]);  }

        private void picbUnit25_Click(object sender, EventArgs e)
        { Update_Tooltip(unit_Array[24]);  }

        private void picbUnit26_Click(object sender, EventArgs e)
        { Update_Tooltip(unit_Array[25]); }

        private void picbUnit27_Click(object sender, EventArgs e)
        { Update_Tooltip(unit_Array[26]); }

        private void picbUnit28_Click(object sender, EventArgs e)
        { Update_Tooltip(unit_Array[27]);  }

        private void picbUnit29_Click(object sender, EventArgs e)
        { Update_Tooltip(unit_Array[28]); }

        private void picbUnit30_Click(object sender, EventArgs e)
        { Update_Tooltip(unit_Array[29]); }

        private void picbUnit6_Click(object sender, EventArgs e)
        { Update_Tooltip(unit_Array[5]); }

        private void picbUnit5_Click(object sender, EventArgs e)
        { Update_Tooltip(unit_Array[4]); }

        private void picbUnit4_Click(object sender, EventArgs e)
        { Update_Tooltip(unit_Array[3]);  }

        private void picbUnit3_Click(object sender, EventArgs e)
        { Update_Tooltip(unit_Array[2]); }

        private void picbUnit2_Click(object sender, EventArgs e)
        { Update_Tooltip(unit_Array[1]); }

        private void picbUnit1_Click(object sender, EventArgs e)
        { Update_Tooltip(unit_Array[0]); }
        #endregion

        #region UpgradeOnClick

        private void picbUpgrade8_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[7]); }

        private void picbUpgrade9_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[8]); }

        private void picbUpgrade10_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[9]); }

        private void picbUpgrade11_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[10]); }

        private void picbUpgrade12_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[11]);  }

        private void picbUpgrade13_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[12]); }

        private void picbUpgrade14_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[13]); }

        private void picbUpgrade15_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[14]); }

        private void picbUpgrade16_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[15]); }

        private void picbUpgrade17_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[16]); }

        private void picbUpgrade18_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[17]); }

        private void picbUpgrade19_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[18]); }

        private void picbUpgrade20_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[19]); }

        private void picbUpgrade21_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[20]); }

        private void picbUpgrade22_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[21]);  }

        private void picbUpgrade23_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[22]); }

        private void picbUpgrade24_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[23]);  }

        private void picbUpgrade25_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[24]); }

        private void picbUpgrade26_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[25]); }

        private void picbUpgrade27_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[26]); }

        private void picbUpgrade28_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[27]); }

        private void picbUpgrade29_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[28]); }

        private void picbUpgrade30_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[29]); }

        private void picbUpgrade31_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[30]); }

        private void picbUpgrade32_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[31]); }

        private void picbUpgrade33_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[32]);  }

        private void picbUpgrade34_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[33]); }

        private void picbUpgrade35_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[34]); }

        private void picbUpgrade36_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[35]);  }

        private void picbUpgrade37_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[36]);  }

        private void picbUpgrade38_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[37]); }

        private void picbUpgrade39_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[38]); }        

        private void picbUpgrade40_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[39]); }

        private void picbUpgrade41_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[40]); }

        private void picbUpgrade42_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[41]); }

        private void picbUpgrade7_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[6]); }

        private void picbUpgrade6_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[5]);  }

        private void picbUpgrade5_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[4]); }

        private void picbUpgrade4_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[3]); }

        private void picbUpgrade3_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[2]);  }

        private void picbUpgrade2_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[1]); }

        private void picbUpgrade1_Click(object sender, EventArgs e)
        { Update_Tooltip(upgrade_Array[0]); }
        #endregion

        //Being able to drag the pictures//corresponding prefab
        #region BuildingsStartDrag
        //Start of the drop/Drop event, building_Array[0] is a prefab
        private void picbBuilding1_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(building_Array[0], DragDropEffects.Copy |  DragDropEffects.Move); }
        private void picbBuilding2_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(building_Array[1], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbBuilding3_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(building_Array[2], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbBuilding4_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(building_Array[3], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbBuilding5_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(building_Array[4], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbBuilding6_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(building_Array[5], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbBuilding7_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(building_Array[6], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbBuilding8_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(building_Array[7], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbBuilding9_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(building_Array[8], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbBuilding10_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(building_Array[9], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbBuilding11_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(building_Array[10], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbBuilding12_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(building_Array[11], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbBuilding13_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(building_Array[12], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbBuilding14_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(building_Array[13], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbBuilding15_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(building_Array[14], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbBuilding16_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(building_Array[15], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbBuilding17_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(building_Array[16], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbBuilding18_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(building_Array[17], DragDropEffects.Copy | DragDropEffects.Move); }
        #endregion

        #region UnitsStartDrag
        private void picbUnit1_MouseDown(object sender, MouseEventArgs e)
        {picbBuilding1.DoDragDrop(unit_Array[0], DragDropEffects.Copy | DragDropEffects.Move);}

        private void picbUnit2_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(unit_Array[1], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUnit3_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(unit_Array[2], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUnit4_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(unit_Array[3], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUnit5_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(unit_Array[4], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUnit6_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(unit_Array[5], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUnit7_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(unit_Array[6], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUnit8_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(unit_Array[7], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUnit9_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(unit_Array[8], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUnit10_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(unit_Array[9], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUnit11_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(unit_Array[10], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUnit12_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(unit_Array[11], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUnit13_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(unit_Array[12], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUnit14_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(unit_Array[13], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUnit15_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(unit_Array[14], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUnit16_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(unit_Array[15], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUnit17_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(unit_Array[16], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUnit18_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(unit_Array[17], DragDropEffects.Copy | DragDropEffects.Move); }
        private void picbUnit19_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(unit_Array[18], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picturepicbUnit20_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(unit_Array[19], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUnit21_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(unit_Array[20], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUnit22_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(unit_Array[21], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUnit23_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(unit_Array[22], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUnit24_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(unit_Array[23], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUnit25_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(unit_Array[24], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUnit26_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(unit_Array[25], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUnit27_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(unit_Array[26], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUnit28_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(unit_Array[27], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUnit29_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(unit_Array[28], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUnit30_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(unit_Array[29], DragDropEffects.Copy | DragDropEffects.Move); }
        #endregion

        #region UpgradesStartDrag
        private void picbUpgrade1_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[0], DragDropEffects.Copy | DragDropEffects.Move);}

        private void picbUpgrade2_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[1], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade3_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[2], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade4_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[3], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade5_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[4], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade6_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[5], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade7_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[6], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade8_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[7], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade9_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[8], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade10_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[9], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade11_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[10], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade12_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[11], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade13_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[12], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade14_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[13], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade15_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[14], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade16_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[15], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade17_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[16], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade18_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[17], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade19_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[18], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade20_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[19], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade21_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[20], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade22_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[21], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade23_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[22], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade24_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[23], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade25_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[24], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade26_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[25], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade27_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[26], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade28_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[27], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade29_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[28], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade30_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[29], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade31_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[30], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade32_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[31], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade33_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[32], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade34_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[33], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade35_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[34], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade36_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[35], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade37_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[36], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade38_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[37], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade39_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[38], DragDropEffects.Copy | DragDropEffects.Move);}

        private void picbUpgrade40_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[39], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade41_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[40], DragDropEffects.Copy | DragDropEffects.Move); }

        private void picbUpgrade42_MouseDown(object sender, MouseEventArgs e)
        { picbBuilding1.DoDragDrop(upgrade_Array[41], DragDropEffects.Copy | DragDropEffects.Move); }
        #endregion

        //tiny UI icons for exit/back to menu
        #region smallUiIcons
        private void picBBackToMenu_MouseHover(object sender, EventArgs e)
        {
            lblMenuTooltip.Text = "Back to menu";
        }

        private void picBBackToMenu_MouseLeave(object sender, EventArgs e)
        {
            lblMenuTooltip.Text = "";
        }

        private void picBBackToMenu_Click(object sender, EventArgs e)
        {
            StartWindow startWindow = new StartWindow(mainFrame);
            startWindow.Show();
            this.Close();
        }

        private void picbExit_MouseHover(object sender, EventArgs e)
        {
            lblMenuTooltip.Text = "Exit";
        }
        private void picbExit_MouseLeave(object sender, EventArgs e)
        {
            lblMenuTooltip.Text = "";
        }

        private void picBSafe_Click(object sender, EventArgs e)
        {
           if(txtSave.Text != "")
            {
                string filePath = @"SafeFiles\" + txtSave.Text + ".txt";
                try
                {
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                    using (FileStream fs = File.Create(filePath))
                    { }
                    using (StreamWriter sw = new StreamWriter(filePath))
                    {
                        sw.WriteLine(mainVariables.Active_Race);
                        foreach(string writeRow in Safe_List)
                        {
                            sw.WriteLine(writeRow);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
           else
            {
                MessageBox.Show("Name field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtSave.Text = "";
        }

        private void picBSafe_MouseHover(object sender, EventArgs e)
        {
            lblMenuTooltip.Text = "Save";
        }

        private void picBSafe_MouseLeave(object sender, EventArgs e)
        {
            lblMenuTooltip.Text = "";
        }
        #endregion
        private void picbExit_Click(object sender, EventArgs e)
        { mainFrame.Close(); }

        //Entering the target of the drag/drop event (a trackbar), breakpoint doesnt get triggered
        private void trackbarTimeline_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Prefab)))
            { e.Effect = DragDropEffects.Copy; }
            else
            { e.Effect = DragDropEffects.None; }            
        }

        //dropping into the trackbar
        private void trackbarTimeline_DragDrop(object sender, DragEventArgs e)
        {
            Prefab prefabGiven = (Prefab)e.Data.GetData(typeof(Prefab));                        
            
            //Setting the time
            int timing = trackbarTimeline.Value;
            timeProgressor = trackbarTimeline.Value;

            //Setting the index and which array to look for
            int indexFinder = Array.FindIndex(building_Array, prefabGiven.Equals); string arrayFinderString = "building";
            if(indexFinder == -1)
            {
                indexFinder = Array.FindIndex(unit_Array, prefabGiven.Equals); arrayFinderString = "unit";
            }
            if (indexFinder == -1)
            {
                indexFinder = Array.FindIndex(upgrade_Array, prefabGiven.Equals); arrayFinderString = "upgrade";
            }
            //Setting up individual number
            mainVariables.Individual_Number++;

            //Adding this state into the safelist
            string timeString;
            if(timing < 10)
            { timeString = "00" + timing.ToString(); }
            else if(timing > 9 && timing < 100)
            { timeString = "0" + timing.ToString(); }
            else
            { timeString = timing.ToString(); }

            string addBuilding = timeString + "_" + arrayFinderString + "_" + indexFinder.ToString() + "_" + mainVariables.Individual_Number.ToString();

            prefabIndexList = new List<int> { };
            prefabTimestampList = new List<int> { };
            prefabTypeList = new List<string> { };
            prefabNumberList = new List<int> { };

            stringSafeList.Add(addBuilding);
            givenPrefabTimestamps.Add(addBuilding);
            givenPrefabTimestamps.Sort();
            stringSafeList.Sort();
            foreach (string currentString in Safe_List)
            {
                string[] currentArray = currentString.Split('_');
                prefabTimestampList.Add(Convert.ToInt32(currentArray[0]));
                prefabTypeList.Add(currentArray[1]);
                prefabIndexList.Add(Convert.ToInt32(currentArray[2]));
                prefabNumberList.Add(Convert.ToInt32(currentArray[3]));
            }
            Update_Timeline(0);
        }
        private void Optimizing_Timeline(Prefab prefab, int time)
        {
            Prefab prefabGiven = prefab;

            //Setting the time
            int timing =time;

            //Setting the index and which array to look for
            int indexFinder = Array.FindIndex(building_Array, prefabGiven.Equals); string arrayFinderString = "building";
            if (indexFinder == -1)
            {
                indexFinder = Array.FindIndex(unit_Array, prefabGiven.Equals); arrayFinderString = "unit";
            }
            if (indexFinder == -1)
            {
                indexFinder = Array.FindIndex(upgrade_Array, prefabGiven.Equals); arrayFinderString = "upgrade";
            }
            //Setting up individual number
            mainVariables.Individual_Number++;

            //Adding this state into the safelist
            string timeString;
            if (timing < 10)
            { timeString = "00" + timing.ToString(); }
            else if (timing > 9 && timing < 100)
            { timeString = "0" + timing.ToString(); }
            else
            { timeString = timing.ToString(); }

            string addTimestamp = timeString + "_" + arrayFinderString + "_" + indexFinder.ToString() + "_" + mainVariables.Individual_Number.ToString();

            prefabIndexList = new List<int> { };
            prefabTimestampList = new List<int> { };
            prefabTypeList = new List<string> { };
            prefabNumberList = new List<int> { };

            stringSafeList.Add(addTimestamp);
            stringSafeList.Sort();

            foreach (string currentString in Safe_List)
            {
                string[] currentArray = currentString.Split('_');
                prefabTimestampList.Add(Convert.ToInt32(currentArray[0]));
                prefabTypeList.Add(currentArray[1]);
                prefabIndexList.Add(Convert.ToInt32(currentArray[2]));
                prefabNumberList.Add(Convert.ToInt32(currentArray[3]));
            }
        }
        
        //Showing the current clicked prefab in the tooltip menu
        private void Update_Tooltip(Prefab prefab)
        {
            groupTooltip.Text = prefab.Name;
            lblMineralCost.Text = prefab.MineralCost.ToString();
            lblVespinCost.Text = prefab.VespinCost.ToString();
            lblTooltipTime.Text = prefab.BuildTime.ToString();
        }

        //Updates the label that is linked to the Trackbar
        private void trackbarTimeline_ValueChanged(object sender, EventArgs e)
        {
            lblCurrentTrackbarValue.Text = (trackbarTimeline.Value).ToString();
        }

        private void picBOptimize_Click(object sender, EventArgs e)
        {            
            if (Safe_List.Count > 0)
            {
                Enable_Disable_UI("disable");
                Optimizer();
            }
        }
        private void picBArrowUp_Click(object sender, EventArgs e)
        {
            Update_Timeline(1);
        }

        private void picBArrowDown_Click(object sender, EventArgs e)
        {
            Update_Timeline(-1);
        }

        private void Update_Timeline(int listMover)
        {
            //Moves the list, the list mover is +1 or -1 to move the list up and down
            listWalker += listMover;
            PictureBox pictureBox = null;
            int secondaryCounter;
            Label label = null;

            //Takes care that the listwalker will not land out of bounds
            if (listWalker < 1)
            { listWalker = 0; picBArrowDown.Enabled = false; picBArrowUp.Enabled = true; }
            else if (listWalker >= Safe_List.Count - 1)
            { listWalker = Safe_List.Count - 1; picBArrowUp.Enabled = false; picBArrowDown.Enabled = true; }
            else
            { picBArrowDown.Enabled = true; picBArrowUp.Enabled = true; }

            //loops 7 times for each picturebox
            for (int i = 0; i < 7; i++)
            {
                secondaryCounter = 0;
                switch (i)
                {
                    case 0:
                        pictureBox = picBBuildNow;
                        label = lblNow;
                        break;
                    case 1:
                        pictureBox = picBPreviousFirst;
                        secondaryCounter--;
                        label = lblPreviousFirst;
                        break;
                    case 2:
                        pictureBox = picBPreviousMid;
                        secondaryCounter -= 2;
                        label = lblPreviousMid;
                        break;
                    case 3:
                        pictureBox = picBPreviousLast;
                        secondaryCounter -= 3;
                        label = lblPreviousLast;
                        break;
                    case 4:
                        pictureBox = picBNextFirst;
                        secondaryCounter++;
                        label = lblNextFirst;
                        break;
                    case 5:
                        pictureBox = picBNextMid;
                        secondaryCounter += 2;
                        label = lblNextMid;
                        break;
                    case 6:
                        pictureBox = picBNextLast;
                        secondaryCounter += 3;
                        label = lblNextLast;
                        break;
                }

                //this walker takes care that empty pictureboxes are actually empty & without timestamp
                int validifyWalker = listWalker + secondaryCounter;

                if (validifyWalker < 0)
                {
                    pictureBox.Image = null;
                    label.Text = "";
                }
                else if (validifyWalker > Safe_List.Count - 1)
                {
                    pictureBox.Image = null;
                    label.Text = "";
                }

                //after it checks if everything is valid, it actually puts the fitting prefab bitmap into the according window, and updates the label
                else
                {
                    Prefab foundPrefab = mainMethods.Prefab_Finder(prefabTypeList[validifyWalker], prefabIndexList[validifyWalker]);
                    pictureBox.Image = foundPrefab.Icon;
                    label.Text = prefabTimestampList[validifyWalker].ToString();
                }
            }
        }

        //Timer Start
        private void picBRunnerStart_Click(object sender, EventArgs e)
        {
            if (Safe_List.Count > 0)
            {
                Enable_Disable_UI("disable");
                mainTimer.Enabled = true;
                mainTimer.Start();
            }
        }

        //Automaticly progresses the timeline when a timestamp is reached
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            timeProgressor++;
            trackbarTimeline.Value = timeProgressor;
            lblCurrentTrackbarValue.Text = timeProgressor.ToString();

            while (listWalker < prefabTimestampList.Count - 1 && timeProgressor == prefabTimestampList[listWalker])
            {
                Update_Timeline(1);
            }
            if (timeProgressor >= prefabTimestampList[prefabTimestampList.Count - 1])
            {
                Enable_Disable_UI("enable");
                mainTimer.Stop();
            }
        }
        
        //Counts how many minerals are expected at a given point
        private float Expected_Minerals(int timePassed)
        {
            return mineralCount + (timePassed * mineralCollectionRate * workerCountMinerals);
        }

        //Counts how much vespin is expected at a given point
        private float Expected_Vespin(int timePassed)
        {
            if (workerCountVespin % 3 == 0)
            {
                return vespinCount + (timePassed * vespinCollectionRateLow * workerCountVespin);
            }
            else
            {
                return vespinCount + (timePassed * vespinCollectionRate * workerCountVespin);
            }
        }

        //Checks if the necessary requirements are met to build a worker without disrupting the next target
        private bool Check_For_Worker(Prefab nextTargetPrefab)
        {
            if(Larvae_Exists() && mineralCount >= 50 && supply >= 2 && Reach_Mineral_Target(nextTargetPrefab) && workerCountMinerals + workerCountVespin <= mainBuildingCount*22)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Checks if a new Main can be build
        private bool Check_For_Main(Prefab nextTargetPrefab)
        {
            if (mineralCount >= mainPrefabNorm.MineralCost && Reach_Mineral_Target(nextTargetPrefab) && workerCountMinerals + workerCountVespin >= mainBuildingCount * 10 && mainBuildingCount <= 4 || mineralCount > 500 && workerCountVespin + workerCountMinerals > 30 && mainBuildingCount <= 4)
            {return true; }
            else
            {return false;}
        }

        private bool Check_For_Extractor(Prefab nextTargetPrefab)
        {
            if (extractorInProgress == false && mineralCount >= extractorPrefabNorm.MineralCost && Reach_Mineral_Target(nextTargetPrefab) && extractorCount <= mainBuildingCount * 2 && workerCountMinerals > workerCountVespin*3 )
            { return true; }
            else
            { return false; }
        }

        //Checks if an Overlord should be build
        private bool Check_For_Overlord(Prefab nextTargetPrefab)
        {
            if (mineralCount >= 100 && Larvae_Exists() && Reach_Mineral_Target(nextTargetPrefab) && supplyInProgress == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool Check_For_Pylon(Prefab nextTargetPrefab)
        {
            if (mineralCount >= 100 && Reach_Mineral_Target(nextTargetPrefab) && supplyInProgress == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Optimizer()
        {
            nextPartSafeArray = Safe_List[0].Split('_');
            nextTime = Convert.ToInt32(nextPartSafeArray[0]);
            nextType = nextPartSafeArray[1];
            nextIndex = Convert.ToInt32(nextPartSafeArray[2]);
            nextPrefab = mainMethods.Prefab_Finder(nextType, nextIndex);

            //ACTUAL OPMIZITATION PROCESS
            for (optimizeProgressor = 0; optimizeProgressor < 601; optimizeProgressor++)
            {
                if (mainVariables.Active_Race == "Zerg" && optimizeProgressor % 11 == 0 && larvaeCount < mainBuildingCount * 3)
                {
                    larvaeCount += mainBuildingCount;
                    if(larvaeCount > 3*mainBuildingCount)
                    { larvaeCount = mainBuildingCount * 3; }
                }

                if (targetTimeList.Count > timestampWalker)
                {
                    while (optimizeProgressor == Convert.ToInt32(targetTimeList[timestampWalker].Split('_')[0]))
                    {
                        string name = targetTimeList[timestampWalker + addedToLists].Split('_')[1];
                        Timeline_TimeDone(name);
                        timestampWalker++;
                        if(timestampWalker >= targetTimeList.Count)
                        {
                            break;
                        }
                    }
                }

                while(optimizeProgressor == nextTime)
                {
                    listWalker++;

                    if(listWalker >= nextPartSafeArray.Length)
                    { break; }
                    mineralCount -= nextPrefab.MineralCost;
                    vespinCount -= nextPrefab.MineralCost;
                    supply += nextPrefab.Supply;

                    if (listWalker >= givenPrefabTimestamps.Count)
                    { listWalker = 0; }

                    nextPartSafeArray = givenPrefabTimestamps[listWalker].Split('_');
                    nextTime = Convert.ToInt32(nextPartSafeArray[0]);
                    nextType = nextPartSafeArray[1];
                    nextIndex = Convert.ToInt32(nextPartSafeArray[2]);

                    nextPrefab = mainMethods.Prefab_Finder(nextType, nextIndex);                    
                }
                if(optimizeProgressor == 300)
                {

                }

                //Calculates current minerals
                mineralCount = mineralCount + (workerCountMinerals * mineralCollectionRate);
                vespinCount = vespinCount + (workerCountVespin * vespinCollectionRate);

                //Checks if a worker should be build
                switch (mainVariables.Active_Race)
                {
                    case "Zerg":
                        for (int i = 0; i < larvaeCount; i++)
                        {
                            if (Check_For_Worker(nextPrefab))
                            {
                                mineralCount -= 50;
                                supply--;
                                Optimizing_Timeline(workerPrefabNorm, optimizeProgressor);
                                Add_To_Timestamp_List(workerPrefabNorm, "unit");
                            }
                            else
                            {
                                break;
                            }
                        }
                        break;
                    case "Terran":
                    case "Protoss":
                        if (Check_For_Worker(nextPrefab) && currentWorkerInProgress <= mainBuildingCount * 2)
                        {
                            currentWorkerInProgress++;
                            mineralCount -= 50;
                            supply--;
                            Optimizing_Timeline(workerPrefabNorm, optimizeProgressor);
                            Add_To_Timestamp_List(workerPrefabNorm, "unit");
                        }
                        break;
                }

                //Checks if supply needed and orders it
                if (supply <= 3)
                {
                    switch (mainVariables.Active_Race)
                    {
                        case "Zerg":
                            if (Check_For_Overlord(nextPrefab))
                            {
                                mineralCount -= supplyPrefabNorm.MineralCost;
                                supplyInProgress = true;                             
                                Optimizing_Timeline(supplyPrefabNorm, optimizeProgressor);
                                Add_To_Timestamp_List(supplyPrefabNorm, "unit");
                            }
                            break;
                        case "Terran":
                            if (Check_For_Pylon(nextPrefab))
                            {
                                workerCountMinerals--;
                                Add_To_Timestamp_List(workerPrefabNorm, "unit", supply_Depot.BuildTime);
                                Standard_Supply_Process();
                            }
                            break;
                        case "Protoss":
                            if(Check_For_Pylon(nextPrefab))
                            {
                                Standard_Supply_Process();
                            }
                            break;
                    }
                }
                //Checks if a new mainbuilding can be built
                if (Check_For_Main(nextPrefab))
                {
                    mineralCount -= mainPrefabNorm.MineralCost;
                    Optimizing_Timeline(mainPrefabNorm, optimizeProgressor);
                    Add_To_Timestamp_List(mainPrefabNorm, "building");
                }
                
                //Checks if a new vespin Extractor can be built
                if (Check_For_Extractor(nextPrefab))
                {
                    extractorInProgress = true;
                    mineralCount -= extractorPrefabNorm.MineralCost;
                    Optimizing_Timeline(extractorPrefabNorm, optimizeProgressor);
                    Add_To_Timestamp_List(extractorPrefabNorm, "building");
                }
            }
            Enable_Disable_UI("enable");
        }
        //Checks if there is larvae that can be transformed to a unit
        private bool Larvae_Exists()
        {
            if(larvaeCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //avoiding double code for terran/Protoss
        private void Standard_Supply_Process()
        {
            mineralCount -= 100;
            supplyInProgress = true;
            Optimizing_Timeline(supplyPrefabNorm, optimizeProgressor);
            Add_To_Timestamp_List(supplyPrefabNorm, "building");
        }

        //This is called when something is finished, to check if the item in question influences future ressources
        private void Timeline_TimeDone(string name)
        {
            switch (name)
            {
                case "Drone":
                case "SCV":
                case "Probe":
                    Worker_Distribute();
                    currentWorkerInProgress--;
                    break;
                case "Supply Depot":
                case "Pylon":
                case "Overlord":
                    supply += 8;
                    supplyInProgress = false;
                    break;
                case "Hatchery":
                case "Command Centre":
                case "Nexus":
                    supply += mainPrefabNorm.Supply;
                    mainBuildingCount++;
                    break;
                case "Extractor":
                case "Assimilator":
                case "Refinery":
                    extractorCount++;
                    extractorInProgress = false;
                    break;
            }
        }

        //Activites and deactivates everything according all buttons etc., and resets all main variables, string is either "enable" or "disable"
        private void Enable_Disable_UI(string abler)
        {
            givenPrefabTimestamps = new List<string> { };
            foreach(string safeString in Safe_List)
            {
                givenPrefabTimestamps.Add(safeString);
            }

            currentWorkerInProgress = 0;
            targetTimeList = new List<string> { };
            listWalker = 0;
            timeProgressor = -1;
            Update_Timeline(0);
            optimizeProgressor = 0;
            trackbarTimeline.Value = 0;
            mineralCount = 50;
            workerCountMinerals = 12;
            workerCountVespin = 0;
            extractorCount = 0;
            mainBuildingCount = 1;
            timestampWalker = 0;
            nextTime = 0; 
            nextIndex = 0;
            extractorInProgress = false;
            supplyInProgress = false;
            switch (mainVariables.Active_Race)
            {
                case "Zerg":
                    larvaeCount = 3;
                    supply = 2;
                    break;
                case "Terran":
                case "Protoss":
                    supply = 2;
                    break;
            }

            switch (abler)
            {
                case "enable":
                    picBStartRunner.Enabled = true;
                    picBOptimize.Enabled = true;
                    trackbarTimeline.Enabled = true;
                    picBArrowUp.Enabled = true;
                    picBArrowDown.Enabled = true;
                    break;

                case "disable":
                    picBStartRunner.Enabled = false;
                    picBOptimize.Enabled = false;
                    trackbarTimeline.Enabled = false;
                    picBArrowUp.Enabled = false;
                    picBArrowDown.Enabled = false;
                    break;
            }
        }
        //Returns how much time will pass until the next given timestamp is reached
        private int Check_Time_Next_Prefab()
        {
            return nextTime - optimizeProgressor;
        }

        //Returns if you can build something and still reach the given timestamp
        private bool Reach_Mineral_Target(Prefab prefab)
        {
            if(Expected_Minerals(Check_Time_Next_Prefab()) > prefab.MineralCost)
            { return true; }
            else
            { return false; }
        }

        //Returns if the worker should become a vespin or a mineral worker
        private void Worker_Distribute()
        {            
            if(extractorCount >= 1 && workerCountVespin <= extractorCount * 3 && workerCountVespin < workerCountMinerals/3)
            {
                workerCountVespin++;                                    
            }
            else
            {
                workerCountMinerals++;
            }
        }

        //Builds the String for the Timestamp List, it is TIME_NAME (for example 001_Drone or 583_Overlord)
        private string Timestamp_String_Builder(Prefab prefab, int delay = 0)
        {
            if (prefab.BuildTime + optimizeProgressor + delay < 100)
            {
                targetListAddAstring = "0" + (prefab.BuildTime + optimizeProgressor + delay).ToString();
            }
            else
            {
                targetListAddAstring = (delay + prefab.BuildTime + optimizeProgressor).ToString();
            }
            string returnString = targetListAddAstring + "_" + prefab.Name;
            return returnString;
        }
        
        // normalizes the minimum process for every addition to the timestamplist to avoid repeating code
        private void Add_To_Timestamp_List(Prefab prefab, string type, int delay = 0)
        {
            if(delay != 0)
            {
                delay -= prefab.BuildTime;
            }
            switch(type)
            {
                case "unit":
                    if (mainVariables.Active_Race == "Zerg")
                        { larvaeCount -= 1; }
                    break;
                case "building":
                    if (mainVariables.Active_Race == "Zerg")
                        { workerCountMinerals--; supply++; }
                    break;
                case "upgrade":
                    break;
            }
            string addString = Timestamp_String_Builder(prefab, delay);
            targetTimeList.Add(addString);
            targetTimeList.Sort();
        }
    }
}