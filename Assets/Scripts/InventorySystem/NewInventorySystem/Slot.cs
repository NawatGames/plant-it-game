using KevinCastejon.MoreAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace InventorySystem.NewInventorySystem
{
    public class Slot : MonoBehaviour
    {
        [ReadOnly] private int _amount;
        public ItemProfileSO itemProfile;
        public string itemId;
        public UnityEvent<Slot> slotDeletedEvent;
        public UnityEvent<Slot> slotUpdatedEvent;

        public int GetAmount()
        {
            return _amount;
        }
        
        public void Inject(ItemProfileSO item, int amount = 1) //método "construtor"
        {
            itemProfile = item;
            itemId = item.itemId;
            _amount = amount;
        }

        public void AddAmount(int quantity)
        {
            if (_amount >= 0)
            {
                _amount += quantity;
            }
            if (_amount <= 0)
            {
                InvokeSlotDeleted();
            }
            slotUpdatedEvent.Invoke(this);
        }

        public void SetAmount(int quantity)
        {
            if (_amount >= 0)
            {
                _amount = quantity;
            }
            if (_amount <= 0)
            {
                InvokeSlotDeleted();
            }
            slotUpdatedEvent.Invoke(this);
        }
        
        //Player usa item, item abaixo de 0, logo deve ser removido do inventário,
        //item removido deve ter categoria e tira-lo da categoria e disparar um evento a nivel de categoria/slot
        //para limpar as variaveis do slot, depois disso formamos a categoria, 
        //a categoria se atualiza, com isso o iventario deve se atualizar tambem,
        public void RemoveAmount(int quantity)
        {
            _amount-= quantity;
            if (_amount <= 0)
            {
                InvokeSlotDeleted();
            }
            slotUpdatedEvent.Invoke(this);
        }

        public void Consume(int quantity = 1)
        {
            if(!itemProfile.consumable) return;
            RemoveAmount(quantity);
        }

        public void InvokeSlotDeleted()
        {
            slotDeletedEvent.Invoke(this);
        }

        [ContextMenu("Add Test")]
        private void AddTest()
        {
            AddAmount(1);
        }
        
        [ContextMenu("Remove Test")]
        private void RemoveTest()
        {
            RemoveAmount(1);
        }
        
        [ContextMenu("Set Test")]
        private void SetTest()
        {
            SetAmount(1);
        }
        
        [ContextMenu("Consume Test")]
        private void ConsumeTest()
        {
            Consume(1);
        }
    }
}