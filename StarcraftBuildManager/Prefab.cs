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
    public class Prefab
    {
        private readonly string name;
        private readonly int mineralCost;
        private readonly int vespinCost;
        private readonly int buildTime;
        private readonly Bitmap view;
        private readonly int supply;

        public string Name
        { get { return name; } }
        public int MineralCost
        { get { return mineralCost; } }
        public int VespinCost
        { get { return vespinCost; } }
        public int BuildTime
        { get { return buildTime; } }
        public Bitmap Icon
        { get { return view; } }
        public int Supply
        { get { return supply; } }

        public Prefab(string name, int mineralCost, int vespinCost, int buildTime, Bitmap view)
        {
            this.name = name;
            this.mineralCost = mineralCost;
            this.vespinCost = vespinCost;
            this.buildTime = buildTime;
            this.view = view;
        }
        public Prefab(string name, int mineralCost, int vespinCost, int buildTime, Bitmap view, int supply)
        {
            this.name = name;
            this.mineralCost = mineralCost;
            this.vespinCost = vespinCost;
            this.buildTime = buildTime;
            this.view = view;
            this.supply = supply;
        }
    }
}