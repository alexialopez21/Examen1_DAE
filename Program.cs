using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1
{
    internal class Program
    {
        const int cantidadMaximaCanciones = 200;
        const int cantidadMaximaAlumnos = 200;

        static string[] artistas = new string[cantidadMaximaCanciones];
        static string[] titulos = new string[cantidadMaximaCanciones];
        static int[] duraciones = new int[cantidadMaximaCanciones];
        static int[] tamaniosKB = new int[cantidadMaximaCanciones];

        static string[] codigos = new string[cantidadMaximaAlumnos];
        static string[] nombres = new string[cantidadMaximaAlumnos];
        static DateTime[] fechaNacimiento = new DateTime[cantidadMaximaAlumnos];
        static string[] grados = new string[cantidadMaximaAlumnos];
        static int[] anioRegistro = new int[cantidadMaximaAlumnos];

        static int numCanciones = 0; 
        static int numAlumnos = 0;   


        static void Main(string[] args)
        {
            bool continuar = true;
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("Menu principal");
                Console.WriteLine("1. Administrar canciones");
                Console.WriteLine("2. Administrar alumnos");
                Console.WriteLine("3. Salir");

                Console.Write("Seleccione una opción: ");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AdministrarCanciones();
                        break;
                    case 2:
                        AdministrarAlumnos();
                        break;
                    case 3:
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            }
        }

        static void AdministrarCanciones()
        {
            Console.Clear();
            Console.WriteLine("Administración de canciones");
            Console.WriteLine("1. Agregar canción");
            Console.WriteLine("2. Mostrar canciones");
            Console.WriteLine("3. Volver al menú principal");

            Console.Write("Seleccione una opción: ");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    if (numCanciones < cantidadMaximaCanciones)
                    {
                        Console.Write("Artista: ");
                        artistas[numCanciones] = Console.ReadLine();

                        Console.Write("Título: ");
                        titulos[numCanciones] = Console.ReadLine();

                        Console.Write("Duración (en segundos): ");
                        duraciones[numCanciones] = int.Parse(Console.ReadLine());

                        Console.Write("Tamaño del fichero (en KB): ");
                        tamaniosKB[numCanciones] = int.Parse(Console.ReadLine());

                        numCanciones++; 
                        Console.WriteLine("Canción agregada con éxito.");
                    }
                    else
                    {
                        Console.WriteLine("Se ha alcanzado el límite de canciones.");
                    }
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Listado de Canciones");
                    Console.WriteLine("{0,-15} {1,-30} {2,-30} {3,-30}", "Artista", "Título", "Duración (s)", "Tamaño (KB)");
                    for (int i = 0; i < numCanciones; i++)
                    {
                        Console.WriteLine("{0,-15} {1,-30} {2,-30} {3,-30}", artistas[i], titulos[i], duraciones[i], tamaniosKB[i]);
                    }
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }

            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        static void AdministrarAlumnos()
        {
            Console.Clear();
            Console.WriteLine("Administración de Alumnos");
            Console.WriteLine("1. Agregar Alumno");
            Console.WriteLine("2. Mostrar Alumnos");
            Console.WriteLine("3. Buscar Alumno por Código");
            Console.WriteLine("4. Editar Información de un Alumno por Código");
            Console.WriteLine("5. Volver al Menú Principal");

            Console.Write("Seleccione una opción: ");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    if (numAlumnos < cantidadMaximaAlumnos)
                    {
                        // Captura de datos de un nuevo alumno
                        Console.Write("Código: ");
                        codigos[numAlumnos] = Console.ReadLine();

                        Console.Write("Nombre completo: ");
                        nombres[numAlumnos] = Console.ReadLine();

                        Console.Write("Fecha de nacimiento (dd/mm/yyyy): ");
                        fechaNacimiento[numAlumnos] = DateTime.ParseExact(Console.ReadLine(), "dd/mm/yyyy", null);

                        Console.Write("Grado: ");
                        grados[numAlumnos] = Console.ReadLine();

                        Console.Write("Año de registro: ");
                        anioRegistro[numAlumnos] = int.Parse(Console.ReadLine());

                        numAlumnos++; // Incrementa el contador de alumnos
                        Console.WriteLine("Alumno agregado con éxito.");
                    }
                    else
                    {
                        Console.WriteLine("Se ha alcanzado el límite de alumnos.");
                    }
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Listado de Alumnos");
                    Console.WriteLine("{0,-10} {1,-30} {2,-15} {3,-30} {4,-30}", "Código", "Nombre Completo", "Fecha Nacimiento", "Grado", "Año Registro");
                    for (int i = 0; i < numAlumnos; i++)
                    {
                        // Mostrar información de alumnos en formato de tabla
                        Console.WriteLine("{0,-10} {1,-30} {2,-15:dd/MM/yyyy} {3,-30} {4,-30}", codigos[i], nombres[i], fechaNacimiento[i], grados[i], anioRegistro[i]);
                    }
                    break;
                case 3:
                    Console.Write("Ingrese el código del alumno a buscar: ");
                    string codigoBuscar = Console.ReadLine();
                    int indice = Array.IndexOf(codigos, codigoBuscar, 0, numAlumnos);
                    if (indice != -1)
                    {
                        // Mostrar información del alumno encontrado en formato de tabla
                        Console.WriteLine("Información del Alumno:");
                        Console.WriteLine("{0,-10} {1,-30} {2,-15} {3,-20} {4,-20}", "Código", "Nombre Completo", "Fecha Nacimiento", "Grado", "Año Registro");
                        Console.WriteLine("{0,-10} {1,-30} {2,-15:dd/MM/yyyy} {3,-20} {4,-20}", codigos[indice], nombres[indice], fechaNacimiento[indice], grados[indice], anioRegistro[indice]);
                    }
                    else
                    {
                        Console.WriteLine("Alumno no encontrado.");
                    }
                    break;
                case 4:
                    Console.Write("Ingrese el código del alumno a editar: ");
                    string codigoEditar = Console.ReadLine();
                    int indiceEditar = Array.IndexOf(codigos, codigoEditar, 0, numAlumnos);
                    if (indiceEditar != -1)
                    {
                        // Edición de información del alumno
                        Console.WriteLine("Editar Información del Alumno:");
                        Console.Write("Nuevo Nombre Completo: ");
                        nombres[indiceEditar] = Console.ReadLine();

                        Console.Write("Nueva Fecha de Nacimiento (dd/mm/yyyy): ");
                        fechaNacimiento[indiceEditar] = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                        Console.Write("Nuevo Grado: ");
                        grados[indiceEditar] = Console.ReadLine();

                        Console.Write("Nuevo Año de Registro: ");
                        anioRegistro[indiceEditar] = int.Parse(Console.ReadLine());

                        Console.WriteLine("Información del alumno editada con éxito.");
                    }
                    else
                    {
                        Console.WriteLine("Alumno no encontrado.");
                    }
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }

            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }
    }
}
