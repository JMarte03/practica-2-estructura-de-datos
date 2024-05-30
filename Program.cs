using System;

namespace ListaDeTareas
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaEnlazada listaDeTareas = new ListaEnlazada();
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Agregar tarea");
                Console.WriteLine("2. Eliminar tarea");
                Console.WriteLine("3. Mostrar tareas");
                Console.WriteLine("4. Salir");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingrese la tarea: ");
                        string tarea = Console.ReadLine();
                        listaDeTareas.AgregarTarea(tarea);
                        break;
                    case "2":
                        Console.Write("Ingrese el número de la tarea a eliminar: ");
                        if (int.TryParse(Console.ReadLine(), out int indice))
                        {
                            listaDeTareas.EliminarTarea(indice);
                        }
                        else
                        {
                            Console.WriteLine("Número inválido.");
                        }
                        break;
                    case "3":
                        listaDeTareas.MostrarTareas();
                        break;
                    case "4":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }

    public class Nodo
    {
        public string Tarea { get; set; }
        public Nodo Siguiente { get; set; }

        public Nodo(string tarea)
        {
            Tarea = tarea;
            Siguiente = null;
        }
    }

    public class ListaEnlazada
    {
        private Nodo cabeza;

        public ListaEnlazada()
        {
            cabeza = null;
        }

        public void AgregarTarea(string tarea)
        {
            Nodo nuevoNodo = new Nodo(tarea);
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
            }
            else
            {
                Nodo actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevoNodo;
            }
            Console.WriteLine("Tarea agregada.");
        }

        public void EliminarTarea(int indice)
        {
            if (cabeza == null)
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            if (indice == 1)
            {
                cabeza = cabeza.Siguiente;
                Console.WriteLine("Tarea eliminada.");
                return;
            }

            Nodo actual = cabeza;
            Nodo anterior = null;
            int contador = 1;

            while (actual != null && contador < indice)
            {
                anterior = actual;
                actual = actual.Siguiente;
                contador++;
            }

            if (actual == null)
            {
                Console.WriteLine("Índice fuera de rango.");
            }
            else
            {
                anterior.Siguiente = actual.Siguiente;
                Console.WriteLine("Tarea eliminada.");
            }
        }

        public void MostrarTareas()
        {
            if (cabeza == null)
            {
                Console.WriteLine("No hay tareas en la lista.");
                return;
            }

            Nodo actual = cabeza;
            int contador = 1;

            while (actual != null)
            {
                Console.WriteLine($"{contador}. {actual.Tarea}");
                actual = actual.Siguiente;
                contador++;
            }
        }
    }
}
