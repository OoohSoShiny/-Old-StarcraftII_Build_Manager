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

        public Bitmap BuildingArea_UiMinerals
        { get { return buildingarea_UiMinerals; } }
        public Bitmap BuildingArea_UiVespin
        { get { return buildingarea_UiVespin; } }
        public Bitmap BuildingArea_UiClock
        { get { return buildingarea_UiClock; } }

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
    }
}
