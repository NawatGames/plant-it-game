using System;
using System.Collections.Generic;
using System.Linq;
using Database.Contents;
using UnityEngine;

namespace Database.Interpreters
{
    public class FertilizerInterpreter : MonoBehaviour
    {
        public TextAsset fertilizerDatabase;
        [SerializeField] private List<Fertilizer> items = new List<Fertilizer>();
        public FertilizerInterpreter()
        {
            var text = fertilizerDatabase.text;
            
            // Splits the CSV into lines
            var lines = text.Split('\n').ToList();
            
            // Removes invalid lines
            lines.RemoveAt(0);
            lines.RemoveAt(lines.Count - 1);
            
            // Creates a fertilizer item for each line
            foreach (var line in lines)
            {
                Debug.Log(line);
                Fertilizer item = new Fertilizer(line);
                items.Add(item);
            }
        }
        
        public Fertilizer GetItem(string fertilizerName)
        {
            return items.FirstOrDefault(fertilizer => fertilizer.fertilizerName == fertilizerName);
        }
    }
}