using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models
{
    public sealed class PizzaStoreManager
    {
        private static readonly PizzaStoreManager instance = new PizzaStoreManager();
        private static Dictionary<int, PizzaStore> stores = new Dictionary<int, PizzaStore>();

        //private int totalStores;
        private static PizzaStore currStore;

        static PizzaStoreManager()
        {
        }
        private PizzaStoreManager()
        {
        }

        public static PizzaStoreManager Instance
        {
            get
            {
                return instance;
            }
        }

        public List<PizzaStore> GetStoreList()
        {
            return new List<PizzaStore>(stores.Values);
        }

        public List<int> GetStoreIDList()
        {
            return new List<int>(stores.Keys);
        }

        // add store using PizzaStore obj
        public bool AddStore(PizzaStore store)
        {
            if (store != null)
            {
                stores.Add(store.storeID, store);
                return true;
            }
            else
            {
                return false;
            }
        }

        public PizzaStore GetCurrStore()
        {
            return currStore;
        }

        public void SetCurrStore(int storeID)
        {
            currStore = stores[storeID];
        }

        public void AddPizzaToStore(Pizza p, PizzaStore store)
        {
            store.AddPizza(p);
        }
    }
}
