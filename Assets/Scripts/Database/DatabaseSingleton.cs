using Database.Interpreters;
using DefaultNamespace;
using UnityEngine;

namespace Database
{
    public class DatabaseSingleton : Singleton<DatabaseSingleton>
    {
        public ItemIntrepeter itemIntrepeter;
        public SeedInterpreter seedInterpreter;
        public FertilizerInterpreter fertilizerInterpreter;
        public CountedDropsInterpreter countedDropsInterpreter;
        public GuaranteedDropsInterpreter guaranteedDropsInterpreter;
        protected override void OnAwake()
        {
            itemIntrepeter.Init();
            seedInterpreter.Init();
            fertilizerInterpreter.Init();
            countedDropsInterpreter.Init();
            guaranteedDropsInterpreter.Init();
            
        }
    }
}