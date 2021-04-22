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
        private readonly float buildTime;
        private readonly Bitmap view;
        private readonly float supply;

        public string Name
        { get { return name; } }
        public int MineralCost
        { get { return mineralCost; } }
        public int VespinCost
        { get { return vespinCost; } }
        public float BuildTime
        { get { return buildTime; } }
        public Bitmap Icon
        { get { return view; } }
        public float Supply
        { get { return supply; } }

        public Prefab(string name, int mineralCost, int vespinCost, float buildTime, Bitmap view)
        {
            this.name = name;
            this.mineralCost = mineralCost;
            this.vespinCost = vespinCost;
            this.buildTime = buildTime;
            this.view = view;
        }
        public Prefab(string name, int mineralCost, int vespinCost, float buildTime, Bitmap view, float supply)
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
