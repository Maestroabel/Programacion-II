using System;
using System.Collections.Generic;
using System.Text;

namespace Registro
{
    class HashSetArrayBased : HashSet<Persona>
    {
        public static LinkedList<Persona>[] Gavetas =
        {
            new LinkedList<Persona>(),
            new LinkedList<Persona>(),
            new LinkedList<Persona>(),
            new LinkedList<Persona>(),
            new LinkedList<Persona>(),
            new LinkedList<Persona>(),
            new LinkedList<Persona>(),           
        };

        public new bool Add(Persona persona)
        {
            if (!Contains(persona))
            {
                var gaveta = Gavetas[persona.GetHashCode() % 7];
                gaveta.AddLast(persona);
                return true;
            }
            return false;
        }
        public new bool Contains(Persona persona)
        {
            var gaveta = Gavetas[persona.GetHashCode() % 7];
            foreach (var per in gaveta)
            {
                if (per.Equals(persona))
                {
                    return true;
                }    
            }
            return false;
        }
        public new bool Remove(Persona persona)
        {
            if (Contains(persona))
            {
                int hashCodePersona = persona.GetHashCode() % 7; 
                foreach (var per in Gavetas[hashCodePersona])
                {
                    if (per.Equals(persona))
                    {
                        Gavetas[hashCodePersona].Remove(persona);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
    