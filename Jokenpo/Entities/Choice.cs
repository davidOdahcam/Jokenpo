using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jokenpo.Entities
{
    internal class Choice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<int, Choice> Weakness { get; set; } = new Dictionary<int, Choice>();

        public void AddWeakness(Choice choice)
        {
            Weakness.Add(choice.Id, choice);
        }
    }
}
