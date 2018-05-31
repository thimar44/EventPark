using EventPark.BO;
using System;

namespace EventPark.Models
{
    public class ViewModel<T> where T : IEntityIdentifiable
    {
        public T Metier { get; protected set; }

        public Guid ID
        {
            get
            { return this.Metier.id; }
            set
            { this.Metier.id = value; }
        }
    }
}