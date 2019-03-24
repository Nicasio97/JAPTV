using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Actor
    {
        public int ActorID { get; set; }
        public string Name { get; set; }

        public Actor()
        {
        }
        public Actor(int actorID, string name)
        {
            ActorID = actorID;
            Name = name;
        }

        public override string ToString()
        {
            return String.Format(Name);
        }
    }
}
