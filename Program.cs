using System;
using System.Net;
using System.Security;
using System.Text;
using System.IO;

namespace Registro
{
    class Program
    {
        public static string Edad;
        public static string Nombre;
        public static string Apellido;
        public static string Ahorro;
        public static SecureString Contraseña;
        public static SecureString ConfirmarContraseña;
        public static string Pass;
        public static string ConfirPass;
        public static string dato;
        public static HashSetArrayBased HashSet = new HashSetArrayBased();

        static void Main(string[] args)
        {
            try
            {
                if (File.Exists("Registro.csv"))
                {
                    if (args[0] == "-r")
                    {
                        //decodificar dato
                        Int16 dato;
                        StreamReader archivo = File.OpenText("Registro.csv");
                        String lectura = archivo.ReadLine();
                        lectura = archivo.ReadLine();
                        String[] columna = new String[6];

                        while (lectura != null)
                        {
                            columna = lectura.Split(',');
                            for (int i = 0; i < columna.Length; i++)
                            {
                                if (i == columna.Length - 1)
                                    Console.Write(columna[i]);
                                else
                                    Console.Write(columna[i] + ",");
                            }
                            Console.WriteLine();
                            Console.WriteLine("datos de {0}{1}", columna[0], columna[1]);
                            dato = Convert.ToInt16(columna[5]);
                            DatoDeco(dato);

                            lectura = archivo.ReadLine();
                        }
                        archivo.Close();
                    }
                }
                else
                {
                    //Crear archivo, si este no existe
                    StreamWriter archivo = File.AppendText("Registro.csv");
                    Console.WriteLine("El archivo se creo.");
                    archivo.WriteLine("Nombre,Apellido,Edad,Ahorro,Password,Datos");
                    archivo.Close();
                }
            }
            catch
            {
                if (File.Exists("Registro.csv"))
                {
                    var Lineas = File.ReadAllLines("Registro.csv");
                    if (Lineas.Length > 1)
                    {
                        for (int i = 1; i < Lineas.Length; i++)
                        {
                            string[] linea = Lineas[i].Split(',');
                            Persona persona = new Persona(linea[0], linea[1], linea[2], linea[3], linea[4], linea[5]);
                            HashSet.Add(persona);
                        }
                    }
                    
                    int A;
                    Console.WriteLine("Eliga una opcion: ");
                    Console.WriteLine("1. Registrar una persona");
                    Console.WriteLine("2. Editar una persona");
                    Console.WriteLine("3. Eliminar una persona");
                    A = int.Parse(Console.ReadLine());
                    Console.Clear();

                    switch (A)
                    {
                        //Registrar persona
                        case 1:
                            Registrar();
                            break;
                        //Editar persona
                        case 2:
                            Editar();
                            break;
                        //Eliminar persona
                        case 3:
                            Eliminar();
                            break;
                        //Caso AntiTroll
                        default:
                            Console.WriteLine("El numero ingresado no es una opcion.");
                            break;
                    }
                }
                else
                {
                    //Crear archivo, si este no existe
                    StreamWriter archivo = File.AppendText("Registro.csv");
                    Console.WriteLine("El archivo se creo.");
                    archivo.WriteLine("Nombre,Apellido,Edad,Ahorro,Password,Datos");
                    archivo.Close();
                }
            }
        }
        /// <summary>
        /// Sirve para registrar una persona en un archivo.
        /// </summary>
        public static void Registrar()
        {
            Console.Write("Cual es su nombre?: ");
            string Nombre = ReadName();

            Console.Write("Cual es su apellido?: ");
            string Apellido = ReadName();

            Console.Write("Cuantos años tiene?: ");
            Edad = ReadAge();

            Console.Write("cuantos ahorros tiene?: ");
            string Ahorro = ReadSaving();

            Console.Write("Escriba una contraseña: ");
            SecureString Contraseña = Password();
            string Pass = new NetworkCredential(string.Empty, Contraseña).Password;

            Console.Write("Escriba nuevamente la contraseña: ");
            SecureString ConfirmarContraseña = Password();
            string ConfirPass = new NetworkCredential(string.Empty, ConfirmarContraseña).Password;

            dato = Dato();
            Console.Clear();

            StreamWriter archivo = File.AppendText("Registro.csv");
            Persona persona = new Persona(Nombre, Apellido);

            if (Pass.Equals(ConfirPass))
            {
                if (HashSet.Contains(persona))
                {
                    Console.WriteLine("La persona ya existe, no puede registrarse.");
                }
                else
                {
                    Console.WriteLine("La persona ha sido registrada.");
                    archivo.WriteLine($"{Nombre},{Apellido},{Edad},{Ahorro},{Pass},{dato}");
                }
            }
            else
            {                
                if (HashSet.Contains(persona))
                {
                    Console.WriteLine("La persona ya existe, no puede registrarse.");
                }
                else
                {
                    Console.WriteLine("La persona ha sido registrada, pero la contraseña es incorrecta.");
                    archivo.WriteLine($"{Nombre},{Apellido},{Edad},{Ahorro},,{dato}");
                }

            }
            archivo.Close();
        }
        /// <summary>
        /// Sirve para editar el registro de una persona en un archivo.
        /// </summary>
        public static void Editar()
        {
            String NewNombre = "", NewApellido = "";

            Console.Write("Cual es su nombre?: ");
            Nombre = ReadName();

            Console.Write("Cual es su apellido?: ");
            Apellido = ReadName();

            Persona persona = new Persona(Nombre, Apellido);
            if (HashSet.Contains(persona))
            {
                Console.WriteLine("Desea cambiar el nombre o el apellido?");
                String B = Console.ReadLine();
                Console.Clear();

                if (B == "si")
                {
                    Console.Write("Escriba el nuevo nombre: ");
                    NewNombre = ReadName();

                    Console.Write("Escriba el nuevo apellido: ");
                    NewApellido = ReadName();
                }

                Console.Write("Cuantos años tiene?: ");
                Edad = ReadAge();

                Console.Write("cuantos ahorros tiene?: ");
                Ahorro = ReadSaving();

                Console.Write("Escriba una contraseña: ");
                Contraseña = Password();
                Pass = new NetworkCredential(string.Empty, Contraseña).Password;

                Console.Write("Escriba nuevamente la contraseña: ");
                ConfirmarContraseña = Password();
                ConfirPass = new NetworkCredential(string.Empty, ConfirmarContraseña).Password;

                dato = Dato();

                if (B == "si")
                {
                    if (Pass.Equals(ConfirPass))
                    {
                        HashSet.Remove(persona);
                        Persona newpersona = new Persona(NewNombre, NewApellido, Edad, Ahorro, Pass, dato);
                        HashSet.Add(newpersona);
                        ArchivoTemp();
                    }
                    else
                    {
                        HashSet.Remove(persona);
                        Pass = "";
                        Persona newpersona = new Persona(NewNombre, NewApellido, Edad, Ahorro, Pass, dato);
                        HashSet.Add(newpersona);
                        ArchivoTemp();
                    }
                }
                else
                {
                    if (Pass.Equals(ConfirPass))
                    {
                        HashSet.Remove(persona);
                        Persona newpersona = new Persona(Nombre, Apellido, Edad, Ahorro, Pass, dato);
                        HashSet.Add(newpersona);
                        ArchivoTemp();                      
                    }
                    else
                    {
                        HashSet.Remove(persona);
                        Pass = "";
                        Persona newpersona = new Persona(Nombre, Apellido, Edad, Ahorro, Pass, dato);
                        HashSet.Add(newpersona);
                        ArchivoTemp();
                    }
                }
                if (Pass.Equals(ConfirPass))
                {
                    Console.WriteLine("La persona se ha editado con exito.");
                }
                else
                {
                    Console.WriteLine("La persona se ha editado con exito, pero la contraseña estaba incorrecta.");
                }
            }
            else
            {
                Console.WriteLine("La persona no existe");
            }
        }
        /// <summary>
        /// Sirve para eliminar el registro de una persona en un archivo.
        /// </summary>
        public static void Eliminar()
        {
            Console.Write("Cual es su nombre?: ");
            Nombre = ReadName();

            Console.Write("Cual es su apellido?: ");
            Apellido = ReadName();

            Console.Clear();

            Persona persona = new Persona(Nombre, Apellido);
            if (HashSet.Contains(persona))
            {
                HashSet.Remove(persona);
                ArchivoTemp();          
                Console.WriteLine("La persona ha sido eliminada.");
            }
            else
            {
                Console.WriteLine("La persona no se ha eliminado, debido a que no se encuentra guardado en el registro.");
            }
        }
        /// <summary>
        /// Sirve para crear un archivo igual al anterior pero con un dato cambiado o eliminado
        /// </summary>
        public static void ArchivoTemp()
        {
            string header = "Nombre,Apellido,Edad,Ahorro,Password,Datos" + Environment.NewLine;
            File.WriteAllText("temp.csv", header);
            for (int i = 0; i < HashSetArrayBased.Gavetas.Length; i++)
            {
                foreach (var per in HashSetArrayBased.Gavetas[i])
                {
                    File.AppendAllText("temp.csv", $"{per.Nombre},{per.Apellido},{per.Edad},{per.Ahorro},{per.Password},{per.Dato}" + Environment.NewLine);
                }
            }
            File.Delete("Registro.csv");
            File.Move("temp.csv", "Registro.csv");          
        }
        /// <summary>
        /// Sirve para descodificar un numero de 4 bits con preguntas especificas.
        /// </summary>
        /// <param name="dato"></param>
        public static void DatoDeco(int dato)
        {
            if (((dato ^ 1) % 2) == 0)
                Console.WriteLine("1. Eres hombre");
            else
                Console.WriteLine("1. Eres mujer");
            if ((((dato >> 1) ^ 1) % 2) == 0)
                Console.WriteLine("2. Eres mayor de edad");
            else
                Console.WriteLine("2. Eres menor de edad");
            if ((((dato >> 2) ^ 1) % 2) == 0)
                Console.WriteLine("3. Tienes licencia");
            else
                Console.WriteLine("3. No tienes licencia");
            if ((((dato >> 3) ^ 1) % 2) == 0)
                Console.WriteLine("4. Tienes coche");
            else
                Console.WriteLine("4. No tienes coche");
        }
        /// <summary>
        /// Sirve para crear un numero binario de 4 bits con preguntas especificas.
        /// </summary>
        /// <returns></returns>
        public static string Dato()
        {
            int dato = 0, edad = Convert.ToInt16(Edad);
            string sexo, licencia, coche;

            Console.WriteLine("Eres hombre?");
            sexo = Console.ReadLine();
            Console.WriteLine("Tienes licencia?");
            licencia = Console.ReadLine();
            Console.WriteLine("Tienes coche?");
            coche = Console.ReadLine();

            if (sexo == "si")
                dato = dato ^ 1;
            if (edad >= 18)
                dato = dato ^ 2;
            if (licencia == "si")
                dato = dato ^ 4;
            if (coche == "si")
                dato = dato ^ 8;

            return dato.ToString();
        }
        /// <summary>
        /// Devuelve un string sin numeros escrito char by char.
        /// </summary>
        /// <returns></returns>
        public static string ReadName()
        {
            ConsoleKeyInfo nombre;
            StringBuilder sb = new StringBuilder();

            do
            {
                nombre = Console.ReadKey();

                switch (nombre.Key)
                {
                    case ConsoleKey.A:
                    case ConsoleKey.B:
                    case ConsoleKey.C:
                    case ConsoleKey.D:
                    case ConsoleKey.E:
                    case ConsoleKey.F:
                    case ConsoleKey.G:
                    case ConsoleKey.H:
                    case ConsoleKey.I:
                    case ConsoleKey.J:
                    case ConsoleKey.K:
                    case ConsoleKey.L:
                    case ConsoleKey.M:
                    case ConsoleKey.N:
                    case ConsoleKey.O:
                    case ConsoleKey.P:
                    case ConsoleKey.Q:
                    case ConsoleKey.R:
                    case ConsoleKey.S:
                    case ConsoleKey.T:
                    case ConsoleKey.U:
                    case ConsoleKey.V:
                    case ConsoleKey.W:
                    case ConsoleKey.X:
                    case ConsoleKey.Y:
                    case ConsoleKey.Z:
                    case ConsoleKey.Spacebar:
                        {                         
                            sb.Append(nombre.KeyChar);
                            break;
                        }
                    case ConsoleKey.Backspace:
                        {
                            if (sb.Length > 0)
                                sb.Remove(sb.Length - 1,1);                      
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            Console.WriteLine();
                            return sb.ToString();
                        }
                    default: break;
                }
            } while (nombre.Key != ConsoleKey.Escape);
            return sb.ToString();
        }
        /// <summary>
        /// Devuelve un string sin letras escrito char by char. 
        /// </summary>
        /// <returns></returns>
        public static string ReadAge()
        {
            ConsoleKeyInfo nombre;
            StringBuilder sb = new StringBuilder();

            do
            {
                nombre = Console.ReadKey();

                switch (nombre.Key)
                {
                    case ConsoleKey.NumPad0:
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.NumPad5:
                    case ConsoleKey.NumPad6:
                    case ConsoleKey.NumPad7:
                    case ConsoleKey.NumPad8:
                    case ConsoleKey.NumPad9:
                    case ConsoleKey.Spacebar:
                        {
                            sb.Append(nombre.KeyChar);
                            break;
                        }
                    case ConsoleKey.Backspace:
                        {
                            if (sb.Length > 0)
                                sb.Remove(sb.Length - 1, 1);
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            Console.WriteLine();
                            return sb.ToString();
                        }
                    default: break;
                }
            } while (nombre.Key != ConsoleKey.Escape);
            return sb.ToString();        
        }
        /// <summary>
        /// Devuelve un string sin letras y con decimal escrito char by char.
        /// </summary>
        /// <returns></returns>
        public static string ReadSaving()
        {
            ConsoleKeyInfo nombre;
            StringBuilder sb = new StringBuilder();

            do
            {
                nombre = Console.ReadKey();

                switch (nombre.Key)
                {
                    case ConsoleKey.NumPad0:
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.NumPad5:
                    case ConsoleKey.NumPad6:
                    case ConsoleKey.NumPad7:
                    case ConsoleKey.NumPad8:
                    case ConsoleKey.NumPad9:
                    case ConsoleKey.OemPeriod:
                    case ConsoleKey.Spacebar:
                        {
                            sb.Append(nombre.KeyChar);
                            break;
                        }
                        case ConsoleKey.Backspace:
                        {
                            if (sb.Length > 0)
                                sb.Remove(sb.Length - 1,1);                      
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            Console.WriteLine();
                            return sb.ToString();
                        }
                    default: break;
                }
            } while (nombre.Key != ConsoleKey.Escape);
            return sb.ToString();
        }
        /// <summary>
        /// Devuelve un SecureString escrito char by char.
        /// </summary>
        /// <returns></returns>
        public static SecureString Password()
        {
            ConsoleKeyInfo key;
            SecureString contra = new SecureString();

            do
            {
                key = Console.ReadKey(true);
                if (!char.IsControl(key.KeyChar))
                {
                    contra.AppendChar(key.KeyChar);
                    Console.Write("*");
                }
                else if ((key.Key == ConsoleKey.Backspace) && contra.Length > 0)
                {
                    contra.RemoveAt(contra.Length - 1);
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);
            {
                Console.WriteLine();
                return contra;
            }
        }
    }
}
