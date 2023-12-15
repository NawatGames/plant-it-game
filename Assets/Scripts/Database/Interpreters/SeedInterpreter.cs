using System;
using System.Collections.Generic;
using System.Linq;
using Database.Contents;
using UnityEngine;

namespace Database.Interpreters
{
    [Serializable]
    public class SeedInterpreter
    {
        public TextAsset seedDatabase; // Seed CSV file database
        [SerializeField] private List<Seed> seeds = new List<Seed>();
        public void Init()
        {
            string text = seedDatabase.text;
            
            // Splits the CSV into lines
            List<string> lines = text.Split('\n').ToList();
            
            // Removes invalid lines
            lines.RemoveAt(0);
            lines.RemoveAt(lines.Count - 1);
            
            // Creates a seed for each line
            foreach (var line in lines)
            {
                Debug.Log(line);
                Seed seed = new Seed(line);
                seeds.Add(seed);
            }
        }
        // Finds a seed by its name
        public Seed GetSeed(string seedName)
        {
            return seeds.FirstOrDefault(item => item.seedName == seedName);
        }       
    }
}