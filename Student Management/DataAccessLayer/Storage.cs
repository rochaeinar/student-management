using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccessLayer
{
    public sealed class Storage
    {
        private static volatile Storage instance = null;
        private static readonly object padlock = new object();
        private List<IEntity> entities;

        private Storage()
        {
            this.entities = new List<IEntity>();
        }

        public void Add(IEntity entity)
        {
            
        }

        public void Delete(int Id)
        {
           
        }

        public void Update(int Id, IEntity entity)
        {
            
        }

        public void Get(IEntity entity)
        {
            
        }

        public static Storage Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                            instance = new Storage();
                    }
                }

                return instance;
            }
        }
    }
}
