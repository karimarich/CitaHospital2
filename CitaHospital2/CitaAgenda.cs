using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitaHospital2
{
    internal class CitaAgenda
    {
        static int agenda = 16;
        static string[] cita = new string[agenda];
        static int[] hour = { 0, -1, -1, -2, -2, -3, -3, -4, -4, -5, -5, -6, -6, -7, -7, -8 };
        static int[] min = { 0, 30, 0, 30, 0, 30, 0, 30, 0, 30, 0, 30, 0, 30, 0, 30 };
        /*static string libre=null;*/
        public static void Main()
        {
            int opcion = 0;
            do
            {
                Console.WriteLine("____________________MENU____________________");
                Console.WriteLine("Escribe el número y haga clic en entrar");
                Console.WriteLine("1. Solicitar cita");
                Console.WriteLine("2. Cancelar cita");
                Console.WriteLine("3. Listado de hoy");
                Console.WriteLine("4. Cerca");
                Console.WriteLine("____________________________________________");

                try
                {
                    opcion = Convert.ToInt32(Console.ReadLine());
                    if (opcion < 1 || opcion > 4)
                    {
                        Console.WriteLine("Por favor, selecciona una opción válida.");
                        continue;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Por favor, Escribe un numero válido!");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        pideCita();
                        break;
                    case 2:
                        eliminaCita();
                        break;
                    case 3:
                        Listado();
                        break;
                }
            } while (opcion != 4);

            Console.WriteLine("Adios");
        }
        /////////////////////////////////////////////////////////////////////////////////////////// listado del agenda de hoy       
        public static void Listado()
        {
            Console.WriteLine("______Listado de pacientes______");
            for (int i = 0; i < agenda; i++)
            {
                Console.WriteLine($"{(i + 9) + hour[i]:D2}:{min[i]:D2} : {cita[i]}");
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////   por pider cita    
        public static void pideCita()
        {
            Console.WriteLine("______Solicitar cita______");

            for (int i = 0; i < agenda; i++)
            {
                if (cita[i] == null) // todos los campos de cita son null>empty
                {

                    Console.WriteLine($"{(i + 9) + hour[i]:D2}:{min[i]:D2} está disponible");

                    while (true) // Qs? if they want Cita
                    {
                        Console.Write("Quieres reservar esta hora? (si/no): ");
                        string response = Console.ReadLine();

                        if (response == "si")
                        {
                            Console.Write("Introduzca el nombre del cliente: ");
                            string nombre = Console.ReadLine();

                            cita[i] = nombre;
                            Console.WriteLine("Cita reservada");

                            return;
                        }
                        else if (response == "no")
                        {
                            Console.WriteLine("No hay cita reservada.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Por favor responda con 'si' o 'no'");

                        }
                    }
                }
            }
            Console.WriteLine("Hoy está lleno");
        }
        ///////////////////////////////////////////////////////////////////////////////////////////    borrar la cita         
        public static void eliminaCita()
        {
            Console.WriteLine("______Cancel Appointment______");
            Console.Write("Introduzca el nombre del cliente: ");

            string nombre = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("inválida, Por favor escribe el nombre");
                return;
            }

            for (int i = 0; i < agenda; i++)
            {

                if (cita[i] != null && cita[i].Equals(nombre, StringComparison.OrdinalIgnoreCase))
                {
                    cita[i] = null;
                    Console.WriteLine("Cita cancelada");
                    return;
                }
            }
            Console.WriteLine("No se encontró ninguna cita con ese nombre");
        }
    }
}
