using PersonalAgenda.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAgenda.Domain.Entities
{
    public class User : IEntity
    {
        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICollection<Meeting> Meetings { get => throw new NotImplementedException();  set => throw new NotImplementedException(); }

        public ICollection<Meetup> Meetups { get => throw new NotImplementedException(); set { throw new NotImplementedException(); } }

        public ICollection<Shopping> Shoppings { get => throw new NotImplementedException(); set { throw new NotImplementedException(); } }
    }
}
