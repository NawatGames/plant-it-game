using Database.Interpreters;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;

namespace Database
{
    public class DatabaseSingleton : Singleton<DatabaseSingleton>
    {
        public ItemIntrepeter itemInterpreter;
        public SeedInterpreter seedInterpreter;
        public FertilizerInterpreter fertilizerInterpreter;
        public CountedDropsInterpreter countedDropsInterpreter;
        public GuaranteedDropsInterpreter guaranteedDropsInterpreter;
        protected override void OnAwake()
        {
            itemInterpreter.Init();
            seedInterpreter.Init();
            fertilizerInterpreter.Init();
            countedDropsInterpreter.Init();
            guaranteedDropsInterpreter.Init();
            
        }
    }
}