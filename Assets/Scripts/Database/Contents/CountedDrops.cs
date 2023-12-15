using System;
using UnityEngine;

namespace Database.Contents
{
    public class CountedDrops
    {
        public int id;
        
        public string seedName;
        public string itemDrop;

        public CountedDrops(string line)
        {
            var segments = line.Split(",");
            int.TryParse(segments[0], out id);
            seedName = segments[1];
            itemDrop = segments[2];
        }
    }
}