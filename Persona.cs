using System;
using System.Diagnostics.CodeAnalysis;

namespace Registro
{
    public sealed class Persona
    {
        public string Nombre { get; }
        public string Apellido { get; }
        public string Edad { get; }
        public string Ahorro { get; }
        public string Password { get; }
        public string Dato { get; }

        public Persona(string nombre, string apellido, string edad, string ahorro, string password, string dato)
            => (Nombre, Apellido, Edad, Ahorro, Password, Dato) = (nombre, apellido, edad, ahorro, password, dato);
        public Persona(string nombre, string apellido)
             => (Nombre, Apellido) = (nombre, apellido);
        
        public override bool Equals(object obj)
        {
            Persona persona = obj as Persona;
            if (persona == null) { return false; }
            string persona1 = $"{this.Nombre} {this.Apellido}";
            string persona2 = $"{persona.Nombre} {persona.Apellido}";
            return persona1.Equals(persona2,StringComparison.OrdinalIgnoreCase);
        }
        public override int GetHashCode()
        {
            char PrimeraLetraApellido = Apellido[0];

            return char.ToLowerInvariant(PrimeraLetraApellido);
        }
    }
}
