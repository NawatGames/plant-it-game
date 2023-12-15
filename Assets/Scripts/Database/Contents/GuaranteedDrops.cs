using System;
using UnityEngine;

namespace Database.Contents
{
    public class GuaranteedDrops
    {
        public int id;
        
        public string seedName;
        public string itemDrop;
        public string minimalProduction;
        public string maximalProduction;

        public GuaranteedDrops(string line)
        {
            var segments = line.Split(",");
            int.TryParse(segments[0], out id);
            seedName = segments[1];
            itemDrop = segments[2];
            minimalProduction = segments[3];
            maximalProduction = segments[4];
        }
    }
}