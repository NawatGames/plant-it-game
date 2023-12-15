using System;
using UnityEngine;

namespace Database.Contents
{
    [Serializable]
    public class Fertilizer
    {
        // Database properties
        public string fertilizerName;
        // Nutrient Properties
        public int water;
        public int nitrogen;
        public int potassium;
        public int phosphorus;
        public int iron;
        public int zinc;
        public int magnesium;

        public Fertilizer(string line)
        {
            var segments = line.Split(",");
            // Database properties
            fertilizerName = segments[0];
            // Nutrient Properties
            int.TryParse(segments[1], out water);
            int.TryParse(segments[2], out nitrogen);
            int.TryParse(segments[3], out potassium);
            int.TryParse(segments[4], out phosphorus);
            int.TryParse(segments[5], out iron);
            int.TryParse(segments[6], out zinc);
            int.TryParse(segments[7], out magnesium);
        }
    }
}