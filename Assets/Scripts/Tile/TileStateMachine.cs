// using System;
// using KevinCastejon.MoreAttributes;
// using Unity.VisualScripting;
// using UnityEngine;
// using UnityEngine.Events;
// using UnityEngine.Serialization;
//
// public class TileStateMachine : MonoBehaviour
// {
//     [SerializeField][ReadOnly] private ItemProfileSO currentProfileSo;
//     public UnityEvent<ItemProfileSO> stateChangedEvent;
//     [SerializeField][ReadOnlyOnPlay] private ItemProfileSO initialProfileSo;
//     [SerializeField] private ItemProfileSO nextProfile;
//     
//     public void Start()
//     {
//         if (initialProfileSo != null)
//         {
//             SetProfile(initialProfileSo);
//         }
//     }
//     public void SetProfile(ItemProfileSO newProfile)
//     {
//         
//         if (currentProfileSo != null)
//         {
//             currentProfileSo.itemUnselectEvent.Invoke();
//         }
//
//         currentProfileSo = newProfile;
//
//         stateChangedEvent.Invoke(newProfile);
//
//         if (currentProfileSo != null)
//         {
//             currentProfileSo.itemSelectEvent.Invoke();
//         }
//     }
//
//     public ItemProfileSO GetProfile()
//     {
//         return currentProfileSo;
//     }
//     [ContextMenu("SetNextState")]
//     private void SetNextState(){
//         SetProfile(nextProfile);
//     }
// }