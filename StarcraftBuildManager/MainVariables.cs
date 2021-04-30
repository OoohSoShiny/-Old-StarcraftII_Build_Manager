using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarcraftBuildManager
{
    public class MainVariables
    {
        string activeRace = "";
        public string Active_Race
        { get { return activeRace; } set { activeRace = value; } }

        int individualNumber = 0;
        public int Individual_Number
        { get { return individualNumber; } set { individualNumber = value; } }

        //Standard menu
        readonly int mainMenuXSize = 245;
        readonly int mainMenuYSize = 355;

        public int MainMenu_X
        { get { return mainMenuXSize; } }
        public int MainMenu_Y
        { get { return mainMenuYSize; } }

        readonly Bitmap mainMenuBackground = new Bitmap(@"Backgrounds\MainBackgroundLarge.jpg");
        public Bitmap MainMenu_Background
        { get { return mainMenuBackground; } }

        //Icon
        readonly Icon starcraftII_Icon = new Icon(@"Pictures\StarcraftII_Icon.ico");
        public Icon BuildManager_Icon
        { get { return starcraftII_Icon; } }
        
        //Button bitmaps Main Menu
        readonly Bitmap mainMenuNewBuild = new Bitmap(@"Pictures\MainMenuNewBuild.png");
        readonly Bitmap mainMenuLoadBuild = new Bitmap(@"Pictures\MainMenuLoadBuild.png");
        readonly Bitmap mainMenuExit = new Bitmap(@"Pictures\MainMenuExit.png");

        public Bitmap MainMenu_NewBuildBM
        { get { return mainMenuNewBuild; } }
        public Bitmap MainMenu_LoadBuildBM
        { get { return mainMenuLoadBuild; } }
        public Bitmap MainMenu_ExitBM
        { get { return mainMenuExit; } }

        //New Build menu        
        readonly int newBuildYSize = 415;
        public int NewBuild_Y
        { get { return newBuildYSize; } }

        //Building Area
        //Background
        readonly Bitmap buildWindow_Background = new Bitmap(@"Backgrounds\BuildWindowBackground.png");
        public Bitmap BuildWindow_BackgroundBM
        { get { return buildWindow_Background; } }

        //UI Elements
        readonly Bitmap buildingarea_UiMinerals = new Bitmap(@"Pictures\Minerals_Icon.png");
        readonly Bitmap buildingarea_UiVespin = new Bitmap(@"Pictures\Vespin_Icon.png");
        readonly Bitmap buildingarea_UiClock = new Bitmap(@"Pictures\Clock_Icon.png");
        readonly Bitmap buildarea_UiClose = new Bitmap(@"Pictures\CloseApp.png");
        readonly Bitmap buildarea_optimize = new Bitmap(@"Pictures\BuildMenuOptimize.png");
        readonly Bitmap buildWindow_arrowUp = new Bitmap(@"Pictures\ArrowUp.png");
        readonly Bitmap buildWindow_arrowDown = new Bitmap(@"Pictures\ArrowDown.png");
        readonly Bitmap builingAreadRunnerStart = new Bitmap(@"Pictures\RunnerStart.png");
        readonly Bitmap buildUiBackToMenu = new Bitmap(@"Pictures\BackToMenu.png");
        readonly Bitmap buildingarea_UiSafe = new Bitmap(@"Pictures\safeIcon.png");
        readonly Bitmap loadarea_load = new Bitmap(@"Pictures\LoadMenuLoad.png");
        readonly Bitmap loadarea_loadBackground = new Bitmap(@"Backgrounds\LoadingScreenBackground.png");
        readonly Bitmap loadarea_protosseyes = new Bitmap(@"Pictures\ProtossEyes.jpg");

        public Bitmap BuildingArea_UiMineralsBM
        { get { return buildingarea_UiMinerals; } }
        public Bitmap BuildingArea_UiVespinBM
        { get { return buildingarea_UiVespin; } }
        public Bitmap BuildingArea_UiClockBM
        { get { return buildingarea_UiClock; } }
        public Bitmap BuildingArea_UiCloseBM
        { get { return buildarea_UiClose; } }
        public Bitmap BuildingArea_OptimizeBM
        { get { return buildarea_optimize; } }
        public Bitmap BuildingArea_ArrowDownBM
        { get { return buildWindow_arrowDown; } }
        public Bitmap BuildingArea_ArrowUpBM
        { get { return buildWindow_arrowUp; } }
        public Bitmap BuildingArea_StartBM
        { get { return builingAreadRunnerStart; } }
        public Bitmap BuildingArea_BackToMenu
        { get { return buildUiBackToMenu; } }
        public Bitmap Building_Area_SafeIconBM
        { get { return buildingarea_UiSafe; } }
        public Bitmap Loading_Area_LoadBM
        { get { return loadarea_load; } }
        public Bitmap Loading_Area_Background
        { get { return loadarea_loadBackground; } }
        public Bitmap Loading_Area_ProtossEyes
        { get { return loadarea_protosseyes; } }
        


        //Bitmaps New Build menu
        readonly Bitmap newBuildZerg = new Bitmap(@"Pictures\NewBuildZerg.png");
        readonly Bitmap newBuildProtoss = new Bitmap(@"Pictures\NewBuildProtoss.png");
        readonly Bitmap newBuildTerran = new Bitmap(@"Pictures\NewBuildTerran.png");
        readonly Bitmap newBuildBack = new Bitmap(@"Pictures\NewBuildBack.png");

        public Bitmap NewBuild_ZergBM
        { get { return newBuildZerg; } }
        public Bitmap NewBuild_ProtossBM
        { get { return newBuildProtoss; } }
        public Bitmap NewBuild_TerranBM
        { get { return newBuildTerran; } }
        public Bitmap NewBuild_Back
        { get { return newBuildBack; } }

        //Bitmaps
        //ZERG
        //Buildings
        readonly Bitmap zerg_HatcheryBM = new Bitmap(@"Pictures\Zerg\Buildings\Hatchery.png");
        readonly Bitmap zerg_LairBM = new Bitmap(@"Pictures\Zerg\Buildings\Lair.png");
        readonly Bitmap zerg_HiveBM = new Bitmap(@"Pictures\Zerg\Buildings\Hive.png");
        readonly Bitmap zerg_SpawningPoolBM = new Bitmap(@"Pictures\Zerg\Buildings\SpawningPool.png");
        readonly Bitmap zerg_HydraliskDenBM = new Bitmap(@"Pictures\Zerg\Buildings\HydraliskDen.png");
        readonly Bitmap zerg_SpireBM = new Bitmap(@"Pictures\Zerg\Buildings\Spire.png");
        readonly Bitmap zerg_GreaterSpireBM = new Bitmap(@"Pictures\Zerg\Buildings\GreaterSpire.png");
        readonly Bitmap zerg_InfestationPitBM = new Bitmap(@"Pictures\Zerg\Buildings\InfestationPit.png");
        readonly Bitmap zerg_SpineCrawlerBM = new Bitmap(@"Pictures\Zerg\Buildings\SpineCrawler.png");
        readonly Bitmap zerg_SporeCrawlerBM = new Bitmap(@"Pictures\Zerg\Buildings\SporeCrawler.png");
        readonly Bitmap zerg_ExtractorBM = new Bitmap(@"Pictures\Zerg\Buildings\Extractor.png");
        readonly Bitmap zerg_NydusNetworkBM = new Bitmap(@"Pictures\Zerg\Buildings\NydusNetwork.png");
        readonly Bitmap zerg_RoachWarrenBM = new Bitmap(@"Pictures\Zerg\Buildings\RoachWarren.png");
        readonly Bitmap zerg_UltraliskCavernBM = new Bitmap(@"Pictures\Zerg\Buildings\UltraliskCavern.png");
        readonly Bitmap zerg_BanelingNestBM = new Bitmap(@"Pictures\Zerg\Buildings\BanelingNest.png");
        readonly Bitmap zerg_EvolutionChamberBM = new Bitmap(@"Pictures\Zerg\Buildings\EvolutionChamber.png");
        readonly Bitmap zerg_LurkerDen = new Bitmap(@"Pictures\Zerg\Buildings\LurkerDen.png");

        public Bitmap HatcheryBM
        { get { return zerg_HatcheryBM; } }
        public Bitmap LairBM
        { get { return zerg_LairBM; } }
        public Bitmap HiveBM
        { get { return zerg_HiveBM; } }
        public Bitmap Spawning_PoolBM
        { get { return zerg_SpawningPoolBM; } }
        public Bitmap Hydralisk_DenBM
        { get { return zerg_HydraliskDenBM; } }
        public Bitmap SpireBM
        { get { return zerg_SpireBM; } }
        public Bitmap Greater_SpireBM
        { get { return zerg_GreaterSpireBM; } }
        public Bitmap Infestation_PitBM
        { get { return zerg_InfestationPitBM; } }
        public Bitmap Spine_CrawlerBM
        { get { return zerg_SpineCrawlerBM; } }
        public Bitmap Spore_CrawlerBM
        { get { return zerg_SporeCrawlerBM; } }
        public Bitmap Zerg_ExtractorBM
        { get { return zerg_ExtractorBM; } }
        public Bitmap Nydus_NetworkBM
        { get { return zerg_NydusNetworkBM; } }
        public Bitmap Roach_WarrenBM
        { get { return zerg_RoachWarrenBM; } }
        public Bitmap Ultralisk_CavernBM
        { get { return zerg_UltraliskCavernBM; } }
        public Bitmap Baneling_NestBM
        { get { return zerg_BanelingNestBM; } }
        public Bitmap Evolution_ChamberBM
        { get { return zerg_EvolutionChamberBM; } }
        public Bitmap Lurker_DenBM
        { get { return zerg_LurkerDen; } }

        //Units
        readonly Bitmap zerg_BanelingBM = new Bitmap(@"Pictures\Zerg\Units\Baneling.jpg");
        readonly Bitmap zerg_BroodLordBM = new Bitmap(@"Pictures\Zerg\Units\Brood_Lord.jpg");
        readonly Bitmap zerg_CorrupterBM = new Bitmap(@"Pictures\Zerg\Units\Corruptor.jpg");
        readonly Bitmap zerg_DroneBM = new Bitmap(@"Pictures\Zerg\Units\Drone.jpg");
        readonly Bitmap zerg_HydraliskBM = new Bitmap(@"Pictures\Zerg\Units\Hydralisk.jpg");
        readonly Bitmap zerg_InfestorBM = new Bitmap(@"Pictures\Zerg\Units\Infestor.jpg");
        readonly Bitmap zerg_LurkerBM = new Bitmap(@"Pictures\Zerg\Units\Lurker.jpg");
        readonly Bitmap zerg_MutaliskBM = new Bitmap(@"Pictures\Zerg\Units\Mutalisk.jpg");
        readonly Bitmap zerg_OverlordBM = new Bitmap(@"Pictures\Zerg\Units\Overlord.jpg");
        readonly Bitmap zerg_OverseerBM = new Bitmap(@"Pictures\Zerg\Units\Overseer.jpg");
        readonly Bitmap zerg_QueenBM = new Bitmap(@"Pictures\Zerg\Units\Queen.jpg");
        readonly Bitmap zerg_RavagerBM = new Bitmap(@"Pictures\Zerg\Units\Ravager.jpg");
        readonly Bitmap zerg_RoachBM = new Bitmap(@"Pictures\Zerg\Units\Roach.jpg");
        readonly Bitmap zerg_SwarmHostBM = new Bitmap(@"Pictures\Zerg\Units\Swarm_Host.jpg");
        readonly Bitmap zerg_UltraliskBM = new Bitmap(@"Pictures\Zerg\Units\Ultralisk.jpg");
        readonly Bitmap zerg_ViperBM = new Bitmap(@"Pictures\Zerg\Units\Viper.jpg");
        readonly Bitmap zerg_ZerglingBM = new Bitmap(@"Pictures\Zerg\Units\Zergling.jpg");

        public Bitmap BanelingBM
        { get { return zerg_BanelingBM; } }
        public Bitmap Boord_LordBM
        { get { return zerg_BroodLordBM; } }
        public Bitmap CorrupterBM
        { get { return zerg_CorrupterBM; } }
        public Bitmap DroneBM
        { get { return zerg_DroneBM; } }
        public Bitmap HydraliskBM
        { get { return zerg_HydraliskBM; } }
        public Bitmap InfestorBM
        { get { return zerg_InfestorBM; } }
        public Bitmap LurkerBM
        { get { return zerg_LurkerBM; } }
        public Bitmap MutaliskBM
        { get { return zerg_MutaliskBM; } }
        public Bitmap OverlordBM
        { get { return zerg_OverlordBM; } }
        public Bitmap OverseerBM
        { get { return zerg_OverseerBM; } }
        public Bitmap QueenBM
        { get { return zerg_QueenBM; } }
        public Bitmap RavagerBM
        { get { return zerg_RavagerBM; } }
        public Bitmap RoachBM
        { get { return zerg_RoachBM; } }
        public Bitmap Swarm_HostBM
        { get { return zerg_SwarmHostBM; } }
        public Bitmap UltraliskBM
        { get { return zerg_UltraliskBM; } }
        public Bitmap ViperBM
        { get { return zerg_ViperBM; } }
        public Bitmap ZerglingBM
        { get { return zerg_ZerglingBM; } }

        //Upgrades
        readonly Bitmap zerg_AdaptiveTalonsBM = new Bitmap(@"Pictures\Zerg\Upgrades\Adaptive_Talons.png");
        readonly Bitmap zerg_AdrenalGlandsBM = new Bitmap(@"Pictures\Zerg\Upgrades\Adrenal_Glands.png");
        readonly Bitmap zerg_AnabolicSynthesisBM = new Bitmap(@"Pictures\Zerg\Upgrades\Anabolic_Synthesis.png");
        readonly Bitmap zerg_BurrowBM = new Bitmap(@"Pictures\Zerg\Upgrades\Burrow.png");
        readonly Bitmap zerg_CentrifugallHooksBM = new Bitmap(@"Pictures\Zerg\Upgrades\Centrifugal_Hooks.png");
        readonly Bitmap zerg_ChitinousPlatingBM = new Bitmap(@"Pictures\Zerg\Upgrades\Chitinous_Plating.png");
        readonly Bitmap zerg_FlyerAttacksBM = new Bitmap(@"Pictures\Zerg\Upgrades\Flyer_Attacks.png");
        readonly Bitmap zerg_FlyerCarapaceBM = new Bitmap(@"Pictures\Zerg\Upgrades\Flyer_Carapace.png");
        readonly Bitmap zerg_GlialReconstitutionBM = new Bitmap(@"Pictures\Zerg\Upgrades\Glial_Reconstitution.png");
        readonly Bitmap zerg_GroovedSpinesBM = new Bitmap(@"Pictures\Zerg\Upgrades\Grooved_Spines.png");
        readonly Bitmap zerg_GroundCarapaceBM = new Bitmap(@"Pictures\Zerg\Upgrades\Ground_Carapace.png");
        readonly Bitmap zerg_MeleeAttacksBM = new Bitmap(@"Pictures\Zerg\Upgrades\Melee_Attacks.png");
        readonly Bitmap zerg_MetabolicBoostBM = new Bitmap(@"Pictures\Zerg\Upgrades\Metabolic_Boost.png");
        readonly Bitmap zerg_MissileAttacksBM = new Bitmap(@"Pictures\Zerg\Upgrades\Missile_Attacks.png");
        readonly Bitmap zerg_MuscularAugmentsBM = new Bitmap(@"Pictures\Zerg\Upgrades\Muscular_Augments.png");
        readonly Bitmap zerg_NeuralParasiteBM = new Bitmap(@"Pictures\Zerg\Upgrades\Neural_Parasite.png");
        readonly Bitmap zerg_PathogenGlandsBM = new Bitmap(@"Pictures\Zerg\Upgrades\Pathogen_Glands.png");
        readonly Bitmap zerg_PneumatizedCarapaceBM = new Bitmap(@"Pictures\Zerg\Upgrades\Pneumatized_Carapace.png");
        readonly Bitmap zerg_SeismicSpinesBM = new Bitmap(@"Pictures\Zerg\Upgrades\Seismic_Spines.png");
        readonly Bitmap zerg_TunnelingClawsBM = new Bitmap(@"Pictures\Zerg\Upgrades\Tunneling_Claws.png");

        public Bitmap Adaptive_TalonsBM
        { get { return zerg_AdaptiveTalonsBM; } }
        public Bitmap Adrenal_GlandsBM
        { get { return zerg_AdrenalGlandsBM; } }
        public Bitmap Anabolic_SynthesisBM
        { get { return zerg_AnabolicSynthesisBM; } }
        public Bitmap BurrowBM
        { get { return zerg_BurrowBM; } }
        public Bitmap Centrifugal_HooksBM
        { get { return zerg_CentrifugallHooksBM; } }
        public Bitmap Chitinous_PlatingBM
        { get { return zerg_ChitinousPlatingBM; } }
        public Bitmap Zerg_FlyerAttacksBM
        { get { return zerg_FlyerAttacksBM; } }
        public Bitmap Flyer_CarapaceBM
        { get { return zerg_FlyerCarapaceBM; } }
        public Bitmap Glial_ReconstitutionBM
        { get { return zerg_GlialReconstitutionBM; } }
        public Bitmap Grooved_SpinesBM
        { get { return zerg_GroovedSpinesBM; } }
        public Bitmap Ground_CarapaceBM
        { get { return zerg_GroundCarapaceBM; } }
        public Bitmap Melee_AttacksBM
        { get { return zerg_MeleeAttacksBM; } }
        public Bitmap Metabolic_BoostBM
        { get { return zerg_MetabolicBoostBM; } }
        public Bitmap Missile_AttacksBM
        { get { return zerg_MissileAttacksBM; } }
        public Bitmap Muscular_AugmentsBM
        { get { return zerg_MuscularAugmentsBM; } }
        public Bitmap Neural_ParasiteBM
        { get { return zerg_NeuralParasiteBM; } }
        public Bitmap Pathogen_GlandsBM
        { get { return zerg_PathogenGlandsBM; } }
        public Bitmap Pneumatited_CarapaceBM
        { get { return zerg_PneumatizedCarapaceBM; } }
        public Bitmap Seismic_SpinesBM
        { get { return zerg_SeismicSpinesBM; } }
        public Bitmap Tunneling_ClawsBM
        { get { return zerg_TunnelingClawsBM; } }

        //PROTOSS
        //BUILDINGS
        readonly Bitmap assimilator = new Bitmap(@"Pictures\Protoss\Buildings\Icon_Protoss_Assimilator.jpg");
        readonly Bitmap cyberneticsCore = new Bitmap(@"Pictures\Protoss\Buildings\Icon_Protoss_Cybernetics_Core.jpg");
        readonly Bitmap darkShrine = new Bitmap(@"Pictures\Protoss\Buildings\Icon_Protoss_Dark_Shrine.jpg");
        readonly Bitmap fleetBeacon = new Bitmap(@"Pictures\Protoss\Buildings\Icon_Protoss_Fleet_Beacon.jpg");
        readonly Bitmap forge = new Bitmap(@"Pictures\Protoss\Buildings\Icon_Protoss_Forge.jpg");
        readonly Bitmap gateway = new Bitmap(@"Pictures\Protoss\Buildings\Icon_Protoss_Gateway.jpg");
        readonly Bitmap nexus = new Bitmap(@"Pictures\Protoss\Buildings\Icon_Protoss_Nexus.jpg");
        readonly Bitmap photonCannon = new Bitmap(@"Pictures\Protoss\Buildings\Icon_Protoss_Photon_Cannon.jpg");
        readonly Bitmap pylon = new Bitmap(@"Pictures\Protoss\Buildings\Icon_Protoss_Pylon.jpg");
        readonly Bitmap roboticsBay = new Bitmap(@"Pictures\Protoss\Buildings\Icon_Protoss_Robotics_Bay.jpg");
        readonly Bitmap roboticsFacility = new Bitmap(@"Pictures\Protoss\Buildings\Icon_Protoss_Robotics_Facility.jpg");
        readonly Bitmap starGate = new Bitmap(@"Pictures\Protoss\Buildings\Icon_Protoss_Stargate.jpg");
        readonly Bitmap templarArchives = new Bitmap(@"Pictures\Protoss\Buildings\Icon_Protoss_Templar_Archives.jpg");
        readonly Bitmap twilightCouncil = new Bitmap(@"Pictures\Protoss\Buildings\Icon_Protoss_Twilight_Council.jpg");
        readonly Bitmap shieldBattery = new Bitmap(@"Pictures\Protoss\Buildings\ShieldBattery_SC2-LotV_Rend1.jpg");

        public Bitmap Assimilator_BM
        { get { return assimilator; } }
        public Bitmap CyberneticsCore_BM
        { get { return cyberneticsCore; } }
        public Bitmap DarkShrine_BM
        { get { return darkShrine; } }
        public Bitmap FleetBeacon_BM
        { get { return fleetBeacon; } }
        public Bitmap Forge_BM
        { get { return forge; } }
        public Bitmap Gateway_BM
        { get { return gateway; } }
        public Bitmap Nexus_BM
        { get { return nexus; } }
        public Bitmap PhotonCannon_BM
        { get { return photonCannon; } }
        public Bitmap Pylon_BM
        { get { return pylon; } }
        public Bitmap RoboticsBay_BM
        { get { return roboticsBay; } }
        public Bitmap RoboticsFacility_BM
        { get { return roboticsFacility; } }
        public Bitmap Stargate_BM
        { get { return starGate; } }
        public Bitmap TemplarArchives_BM
        { get { return templarArchives; } }
        public Bitmap TwilightCouncil_BM
        { get { return twilightCouncil; } }
        public Bitmap Shieldbattery_BM
        { get { return shieldBattery; } }

        //UNITS
        readonly Bitmap adept = new Bitmap(@"Pictures\Protoss\Units\Icon_Protoss_Adept.jpg");
        readonly Bitmap archon = new Bitmap(@"Pictures\Protoss\Units\Icon_Protoss_Archon.jpg");
        readonly Bitmap carrier = new Bitmap(@"Pictures\Protoss\Units\Icon_Protoss_Carrier.jpg");
        readonly Bitmap colossus = new Bitmap(@"Pictures\Protoss\Units\Icon_Protoss_Colossus.jpg");
        readonly Bitmap darkTemplar = new Bitmap(@"Pictures\Protoss\Units\Icon_Protoss_Dark_Templar.jpg");
        readonly Bitmap disruptor = new Bitmap(@"Pictures\Protoss\Units\Icon_Protoss_Disruptor.jpg");
        readonly Bitmap highTemplar = new Bitmap(@"Pictures\Protoss\Units\Icon_Protoss_High_Templar.jpg");
        readonly Bitmap immortal = new Bitmap(@"Pictures\Protoss\Units\Icon_Protoss_Immortal.jpg");
        readonly Bitmap motherShip = new Bitmap(@"Pictures\Protoss\Units\Icon_Protoss_Mothership.jpg");

        public Bitmap Adept_BM
        { get { return adept; } }
        public Bitmap Archon_BM
        { get { return archon; } }
        public Bitmap Carrier_BM
        { get { return carrier; } }
        public Bitmap Colossus_BM
        { get { return colossus; } }
        public Bitmap DarkTemplar_BM
        { get { return darkTemplar; } }
        public Bitmap Disruptor_BM
        { get { return disruptor; } }
        public Bitmap HighTemplar_BM
        { get { return highTemplar; } }
        public Bitmap Immortal_BM
        { get { return immortal; } }
        public Bitmap Mothership_BM
        { get { return motherShip; } }

        readonly Bitmap mothershipCore = new Bitmap(@"Pictures\Protoss\Units\Icon_Protoss_Mothership_Core.jpg");
        readonly Bitmap observer = new Bitmap(@"Pictures\Protoss\Units\Icon_Protoss_Observer.jpg");
        readonly Bitmap oracle = new Bitmap(@"Pictures\Protoss\Units\Icon_Protoss_Oracle.jpg");
        readonly Bitmap phoenix = new Bitmap(@"Pictures\Protoss\Units\Icon_Protoss_Phoenix.jpg");
        readonly Bitmap probe = new Bitmap(@"Pictures\Protoss\Units\Icon_Protoss_Probe.jpg");
        readonly Bitmap sentry = new Bitmap(@"Pictures\Protoss\Units\Icon_Protoss_Sentry.jpg");
        readonly Bitmap stalker = new Bitmap(@"Pictures\Protoss\Units\Icon_Protoss_Stalker.jpg");
        readonly Bitmap tempest = new Bitmap(@"Pictures\Protoss\Units\Icon_Protoss_Tempest.jpg");
        readonly Bitmap warpPrism = new Bitmap(@"Pictures\Protoss\Units\Icon_Protoss_Warp_Prism.jpg");
        readonly Bitmap zealot = new Bitmap(@"Pictures\Protoss\Units\Icon_Protoss_Zealot.jpg");
        readonly Bitmap voidRay = new Bitmap(@"Pictures\Protoss\Units\VoidRay_SC2_Rend1.jpg");

        public Bitmap MothershipCore_BM
        { get { return mothershipCore; } }
        public Bitmap Observer_BM
        { get { return observer; } }
        public Bitmap Oracle_BM
        { get { return oracle; } }
        public Bitmap Phoenix_BM
        { get { return phoenix; } }
        public Bitmap Probe_BM
        { get { return probe; } }
        public Bitmap Sentry_BM
        { get { return sentry; } }
        public Bitmap Stalker_BM
        { get { return stalker; } }
        public Bitmap Tempest_BM
        { get { return tempest; } }
        public Bitmap WarpPrism_BM
        { get { return warpPrism; } }
        public Bitmap Zealot_BM
        { get { return zealot; } }
        public Bitmap VoidRaY_BM
        { get { return voidRay; } }

        //UPGRADES
        readonly Bitmap airArmor = new Bitmap(@"Pictures\Protoss\Upgrades\AirArmor.png");
        readonly Bitmap airWeapon = new Bitmap(@"Pictures\Protoss\Upgrades\AirWeaponAttack.png");
        readonly Bitmap anionPulseCrystals = new Bitmap(@"Pictures\Protoss\AnionPulseCrystals.png");
        readonly Bitmap blink = new Bitmap(@"Pictures\Protoss\Upgrades\Blink.png");
        readonly Bitmap charge = new Bitmap(@"Pictures\Protoss\Upgrades\Charge.png");
        readonly Bitmap extendedThermalLance = new Bitmap(@"Pictures\Protoss\Upgrades\ExtendedThermalLance.png");
        readonly Bitmap fluxVanes= new Bitmap(@"Pictures\Protoss\Upgrades\FluxVanes.png");
        readonly Bitmap graviticDrive = new Bitmap(@"Pictures\Protoss\Upgrades\GraviticDrive.png");
        readonly Bitmap graviticBooster = new Bitmap(@"Pictures\Protoss\Upgrades\GraviticBooster.png");
        readonly Bitmap gravitronCatapult = new Bitmap(@"Pictures\Protoss\GravitonCatapult.png");
        readonly Bitmap groundArmor = new Bitmap(@"Pictures\Protoss\Upgrades\GroundArmor.png");

        public Bitmap AirArmor_BM
        { get { return airArmor; } }
        public Bitmap AirWeapon_BM
        { get { return airWeapon; } }
        public Bitmap AnionPulseCrystals_BM
        { get { return anionPulseCrystals; } }
        public Bitmap Blink_BM
        { get { return blink; } }
        public Bitmap Charge_BM
        { get { return charge; } }
        public Bitmap ExtendedThermalLance_BM
        { get { return extendedThermalLance; } }
        public Bitmap FluxVanes_BM
        { get { return fluxVanes; } }
        public Bitmap GraviticDrive_BM
        { get { return graviticDrive; } }
        public Bitmap GraviticBooster_BM
        { get { return graviticBooster; } }
        public Bitmap GravitronCatapult_BM
        { get { return gravitronCatapult; } }
        public Bitmap GroundArmor_BM
        { get { return groundArmor; } }

        readonly Bitmap hallucination = new Bitmap(@"Pictures\Protoss\Upgrades\Hallucination.png");
        readonly Bitmap groundAttack = new Bitmap(@"Pictures\Protoss\Upgrades\GroundAttack.png");
        readonly Bitmap psionicStorm = new Bitmap(@"Pictures\Protoss\Upgrades\PsionicStorm.png");
        readonly Bitmap resonatingGlaives = new Bitmap(@"Pictures\Protoss\Upgrades\ResonatingGlaives.png");
        readonly Bitmap shadowStride = new Bitmap(@"Pictures\Protoss\Upgrades\ShadowStride.png");
        readonly Bitmap shields = new Bitmap(@"Pictures\Protoss\Shields.png");
        readonly Bitmap tectonicDestabilizers = new Bitmap(@"Pictures\Protoss\Upgrades\TectonicDestabilizers.png");
        readonly Bitmap warpGate = new Bitmap(@"Pictures\Protoss\Upgrades\WarpGate.png");

        public Bitmap Hallucination_BM
        { get { return hallucination; } }
        public Bitmap GroundAttack_BM
        { get { return groundAttack; } }
        public Bitmap Psionic_Storm_BM
        { get { return psionicStorm; } }
        public Bitmap ResonatingGlaives_BM
        { get { return resonatingGlaives; } }
        public Bitmap ShadowStride_BM
        { get { return shadowStride; } }
        public Bitmap Shields_BM
        { get { return shields; } }
        public Bitmap TectonicDestabilizers_BM
        { get { return tectonicDestabilizers; } }
        public Bitmap Warpgate_BM
        { get { return warpGate; } }

        //TERRAN
        //BUILDINGS
        readonly Bitmap armory = new Bitmap(@"Pictures\Terran\Buildings\Armory_SC2_Icon1.jpg");
        readonly Bitmap barracks = new Bitmap(@"Pictures\Terran\Buildings\Barracks_SC2_Icon1.jpg");
        readonly Bitmap bunker = new Bitmap(@"Pictures\Terran\Buildings\Bunker_SC2_Icon1.jpg");
        readonly Bitmap commandCenter = new Bitmap(@"Pictures\Terran\Buildings\CommandCenter_SC2_Icon1.jpg");
        readonly Bitmap engineeringBay = new Bitmap(@"Pictures\Terran\Buildings\EngineeringBay_SC2_Icon1.jpg");
        readonly Bitmap factory = new Bitmap(@"Pictures\Terran\Buildings\Factory_SC2_Icon1.jpg");
        readonly Bitmap fusionCore = new Bitmap(@"Pictures\Terran\Buildings\FusionCore_SC2_Icon1.jpg");
        readonly Bitmap ghostAcademy = new Bitmap(@"Pictures\Terran\Buildings\GhostAcademy_SC2_Icon1.jpg");
        readonly Bitmap missileTurret = new Bitmap(@"Pictures\Terran\Buildings\MissileTurret_SC2_Icon1.jpg");
        readonly Bitmap orbitalCommand = new Bitmap(@"Pictures\Terran\Buildings\OrbitalCommand_SC2_Icon1.jpg");
        readonly Bitmap planetaryFortress = new Bitmap(@"Pictures\Terran\Buildings\PlanetaryFortress_SC2_Icon1.jpg");
        readonly Bitmap refinery = new Bitmap(@"Pictures\Terran\Buildings\Refinery_SC2_Icon1.jpg");
        readonly Bitmap sensorTower = new Bitmap(@"Pictures\Terran\Buildings\SensorTower_SC2_Icon1.jpg");
        readonly Bitmap starport = new Bitmap(@"Pictures\Terran\Buildings\Starport_SC2_Icon1.jpg");
        readonly Bitmap supplyDepot = new Bitmap(@"Pictures\Terran\Buildings\SupplyDepot_SC2_Icon1.jpg");
        
        public Bitmap Armory_BM
        { get { return armory; } }
        public Bitmap Barracks_BM
        { get { return barracks; } }
        public Bitmap Bunker_BM
        { get { return bunker; } }
        public Bitmap CommandCenter_BM
        { get { return commandCenter; } }
        public Bitmap EngineeringBay_BM
        { get { return engineeringBay; } }
        public Bitmap Factory_BM
        { get { return factory; } }
        public Bitmap FusionCore_BM
        { get { return fusionCore; } }
        public Bitmap GhostAcademy_BM
        { get { return ghostAcademy; } }
        public Bitmap MissilyTurret_BM
        { get { return missileTurret; } }
        public Bitmap OrbitalCommand_BM
        { get { return orbitalCommand; } }
        public Bitmap PlanetaryFortress_BM
        { get { return planetaryFortress; } }
        public Bitmap Refinery_BM
        { get { return refinery; } }
        public Bitmap SensorTower_BM
        { get { return sensorTower; } }
        public Bitmap Starport_BM
        { get { return starport; } }
        public Bitmap SupplyDepot_BM
        { get { return supplyDepot; } }

        //UNITS
        readonly Bitmap banshee = new Bitmap(@"Pictures\Terran\Buildings\Banshee_SC2_Icon1.jpg");
        readonly Bitmap battleCruiser = new Bitmap(@"Pictures\Terran\Buildings\Battlecruiser_SC2_Icon1.jpg");
        readonly Bitmap cyclone = new Bitmap(@"Pictures\Terran\Buildings\Cyclone_SC2-LotV_Icon1.jpg");
        readonly Bitmap ghost = new Bitmap(@"Pictures\Terran\Buildings\Ghost_SC2_Icon1.jpg");
        readonly Bitmap hellion = new Bitmap(@"Pictures\Terran\Buildings\Hellion_SC2_Icon1.jpg");
        readonly Bitmap liberator = new Bitmap(@"Pictures\Terran\Buildings\Liberator_SC2-LotV_Icon1.jpg");
        readonly Bitmap marauder = new Bitmap(@"Pictures\Terran\Buildings\Marauder_SC2_Icon1.jpg");
        readonly Bitmap spaceMarine = new Bitmap(@"Pictures\Terran\Buildings\Marine_SC2_Icon1.jpg");
        public Bitmap Banshee_BM
        { get { return banshee; } }
        public Bitmap BattleCruiser_BM
        { get { return battleCruiser; } }
        public Bitmap Cyclone_BM
        { get { return cyclone; } }
        public Bitmap Ghost_BM
        { get { return ghost; } }
        public Bitmap Hellion_BM
        { get { return hellion; } }
        public Bitmap Liberator_BM
        { get { return liberator; } }
        public Bitmap Marauder_BM
        { get { return marauder; } }
        public Bitmap SpaceMarine_BM
        { get { return spaceMarine; } }

        readonly Bitmap medivac = new Bitmap(@"Pictures\Terran\Buildings\Medivac_SC2_Icon1.jpg");
        readonly Bitmap raven = new Bitmap(@"Pictures\Terran\Buildings\Raven_SC2_Icon1.jpg");
        readonly Bitmap reaper = new Bitmap(@"Pictures\Terran\Buildings\Reaper_SC2_Icon1.jpg");
        readonly Bitmap scv = new Bitmap(@"Pictures\Terran\Buildings\SCV_SC2_Icon1.jpg");
        readonly Bitmap siegeTank = new Bitmap(@"Pictures\Terran\Buildings\SiegeTank_SC2_Icon1.jpg");
        readonly Bitmap thor = new Bitmap(@"Pictures\Terran\Buildings\Thor_SC2_Icon1.jpg");
        readonly Bitmap viking = new Bitmap(@"Pictures\Terran\Buildings\Viking_SC2_Icon1.jpg");
        readonly Bitmap widowMine = new Bitmap(@"Pictures\Terran\Buildings\WidowMine_SC2-HotS_Icon1.jpg");

        public Bitmap Medivac_BM
        { get { return medivac; } }
        public Bitmap Raven_BM
        { get { return raven; } }
        public Bitmap Reaper_BM
        { get { return reaper; } }
        public Bitmap SCV_BM
        { get { return scv; } }
        public Bitmap SiegeTank_BM
        { get { return siegeTank; } }
        public Bitmap Thor_BM
        { get { return thor; } }
        public Bitmap Viking_BM
        { get { return viking; } }
        public Bitmap WidowMine_BM
        { get { return widowMine; } }

        //UPGRADES
        readonly Bitmap advancedBallistics = new Bitmap(@"Pictures\Terran\Upgrades\AdvancedBallistics.png");
        readonly Bitmap cloakingField = new Bitmap(@"Pictures\Terran\Upgrades\CloakingField.png");
        readonly Bitmap combatShield = new Bitmap(@"Pictures\Terran\Upgrades\CombatShield.png");
        readonly Bitmap concussiveShells = new Bitmap(@"Pictures\Terran\Upgrades\ConcussiveShells.png");
        readonly Bitmap corvidReactor = new Bitmap(@"Pictures\Terran\Upgrades\CorvidReactor.png");
        readonly Bitmap drillingClaws = new Bitmap(@"Pictures\Terran\Upgrades\DrillingClaws.png");
        readonly Bitmap hisecAutoTracking = new Bitmap(@"Pictures\Terran\Upgrades\HisecAutoTracking.png");
        readonly Bitmap hyperflightRotor = new Bitmap(@"Pictures\Terran\Upgrades\HyperflightRotor.png");
        readonly Bitmap infantryArmor = new Bitmap(@"Pictures\Terran\Upgrades\InfantryArmor.png");
        readonly Bitmap infantryWeapon = new Bitmap(@"Pictures\Terran\Upgrades\InfantryWeapon.png");
        readonly Bitmap infernalPreigniter = new Bitmap(@"Pictures\Terran\Upgrades\InfernalPreigniter.png");
        public Bitmap AdvancedBallistics_BM
        { get { return advancedBallistics; } }
        public Bitmap CloakingField_BM
        { get { return cloakingField; } }
        public Bitmap CombatShield_BM
        { get { return combatShield; } }
        public Bitmap ConcussiveShells_BM
        { get { return concussiveShells; } }
        public Bitmap CorvidReactor_BM
        { get { return corvidReactor; } }
        public Bitmap DrillingClaws_BM
        { get { return drillingClaws; } }
        public Bitmap HisecAutoTracking_BM
        { get { return hisecAutoTracking; } }
        public Bitmap HyperFlightRotor_BM
        { get { return hyperflightRotor; } }
        public Bitmap InfantryArmor_BM
        { get { return infantryArmor; } }
        public Bitmap InfantryWeapon_BM
        { get { return infantryWeapon; } }
        public Bitmap InfernalPreigniter
        { get { return infernalPreigniter; } }

        readonly Bitmap magfieldaccelerator = new Bitmap(@"Pictures\Terran\Upgrades\MagfieldAccelerator.png");
        readonly Bitmap neosteelArmor = new Bitmap(@"Pictures\Terran\Upgrades\NeosteelArmor.png");
        readonly Bitmap personalCloaking = new Bitmap(@"Pictures\Terran\Upgrades\PersonalCloaking.png");
        readonly Bitmap rapidReignitionSystem = new Bitmap(@"Pictures\Terran\Upgrades\RapidReignitionSystem.png");
        readonly Bitmap shipWeapons = new Bitmap(@"Pictures\Terran\Upgrades\ShipWeapons.png");
        readonly Bitmap smartServos = new Bitmap(@"Pictures\Terran\Upgrades\SmartServos.png");
        readonly Bitmap stimpack = new Bitmap(@"Pictures\Terran\Upgrades\Stimpack.png");
        readonly Bitmap vehicleAndShipPlating = new Bitmap(@"Pictures\Terran\Upgrades\VehicleAndShipPlating.png");
        readonly Bitmap vehicleWeapon = new Bitmap(@"Pictures\Terran\Upgrades\VehicleWeapon.png");
        readonly Bitmap weaponRefit = new Bitmap(@"Pictures\Terran\Upgrades\WeaponRefit.png");

        public Bitmap MagfieldAccelerator_BM
        { get { return magfieldaccelerator; } }
        public Bitmap NeosteelArmor_BM
        { get { return neosteelArmor; } }
        public Bitmap PersonalCloaking_BM
        { get { return personalCloaking; } }
        public Bitmap RapidReignitionSystem_BM
        { get { return rapidReignitionSystem; } }
        public Bitmap ShipWeapons_BM
        { get { return shipWeapons; } }
        public Bitmap SmartServos_BM
        { get { return smartServos; } }
        public Bitmap Stimpack_BM
        { get { return stimpack; } }
        public Bitmap VehicleAndShipPlating_BM
        { get { return vehicleAndShipPlating; } }
        public Bitmap VehicleWeapon_BM
        { get { return vehicleWeapon; } }
        public Bitmap WeaponRefit_BM
        { get { return weaponRefit; } }
    }
}
