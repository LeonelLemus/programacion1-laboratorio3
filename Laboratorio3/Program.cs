using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Animal
{
    public string Nombre { get; private set; }
    public string Sonido { get; private set; }
    public string TipoAlimentacion { get; private set; } 
    public string Comportamiento { get; private set; } 
    public string Descripcion { get; private set; } 
    public bool HaSidoAlimentado { get; set; } 

    public Animal(string nombre, string sonido, string tipoAlimentacion, string comportamiento, string descripcion)
    {
        Nombre = nombre;
        Sonido = sonido;
        TipoAlimentacion = tipoAlimentacion;
        Comportamiento = comportamiento;
        Descripcion = descripcion;
        HaSidoAlimentado = false;
    }

    public string HacerSonido()
    {
        return Sonido;
    }

    public virtual string Moverse()
    {
        return "El animal se está moviendo.";
    }
}

public class Zoo
{
    private List<Animal> animales = new List<Animal>();

    public Zoo()
    {
        // Agregar animales al zoológico
        animales.Add(new Animal("León", "Rugido", "Carnívoro", "Salvaje", "El león (Panthera leo) es un mamífero carnívoro de la familia de los félidos y una de las cinco especies del género Panthera."));
        animales.Add(new Animal("Elefante", "Barritido", "Herbívoro", "Tranquilo", "El elefante es un mamífero proboscídeo de la familia Elephantidae."));
        animales.Add(new Animal("Jirafa", "Zumbido", "Herbívoro", "Tranquilo", "La jirafa (Giraffa camelopardalis) es una especie de mamífero artiodáctilo de la familia Giraffidae."));
        animales.Add(new Animal("Tigre", "Rugido bajo", "Carnívoro", "Salvaje", "El tigre (Panthera tigris) es una de las especies del género Panthera y pertenece a la familia de los félidos."));
        animales.Add(new Animal("Mono", "Gruñido", "Herbívoro", "Tranquilo", "Los monos son animales mamíferos pertenecientes al orden de los primates, y son considerados los animales más cercanos a los humanos."));
        animales.Add(new Animal("Oso", "Rugido", "Omnívoro", "Salvaje", "El oso es un mamífero de la familia de los úrsidos que está presente en una gran parte del Hemisferio Norte."));
        animales.Add(new Animal("Cocodrilo", "Rugido", "Carnívoro", "Salvaje", "Los cocodrilos son reptiles carnívoros de la familia Crocodylidae."));
        animales.Add(new Animal("Serpiente", "Siseo", "Carnívoro", "Salvaje", "Las serpientes son reptiles que se caracterizan por no tener patas y por desplazarse arrastrándose."));
        animales.Add(new Animal("Pingüino", "Graznido", "Piscívoro", "Tranquilo", "Los pingüinos son aves no voladoras que se distribuyen únicamente en el Hemisferio Sur."));
        animales.Add(new Animal("Lobo", "Aullido", "Carnívoro", "Salvaje", "El lobo es un mamífero del orden de los carnívoros. Es un animal muy territorial y social que vive en manadas."));
        animales.Add(new Animal("Cebra", "Relincho", "Herbívoro", "Tranquilo", "La cebra es un mamífero perisodáctilo de la familia Equidae, nativo de África."));
        animales.Add(new Animal("Rinoceronte", "Bufido", "Herbívoro", "Tranquilo", "El rinoceronte es un mamífero perisodáctilo de la familia Rhinocerotidae."));
        animales.Add(new Animal("Panda", "Gruñido", "Herbívoro", "Tranquilo", "El panda gigante es una especie de mamífero originaria de China y una de las más conocidas en el mundo."));
        animales.Add(new Animal("Pavo Real", "Graznido", "Omnívoro", "Tranquilo", "El pavo real es una de las aves más vistosas y hermosas que existen en el reino animal."));
        animales.Add(new Animal("Tortuga", "Reptar", "Herbívoro", "Tranquilo", "Las tortugas son reptiles que se caracterizan por tener un caparazón que protege su cuerpo."));
    }

    public void MostrarAnimales()
    {
        Console.WriteLine("Los animales presentes en el zoológico son:");
        foreach (Animal animal in animales)
        {
            Console.WriteLine(animal.Nombre);
        }
    }

    public void AlimentarAnimalesTranquilos()
    {
        Console.WriteLine("Alimentando a los animales tranquilos/herbívoros:");
        foreach (Animal animal in animales)
        {
            if (animal.Comportamiento == "Tranquilo")
            {
                Console.WriteLine($"- {animal.Nombre}");
            }
        }

        Console.WriteLine("Seleccione el animal que desea alimentar (separe los nombres por comas si desea alimentar varios animales):");
        string seleccion = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(seleccion))
        {
            Console.WriteLine("No ha ingresado ningún animal.");
            return;
        }

        string[] nombres = seleccion.Split(',');

        foreach (string nombre in nombres)
        {
            string nombreAnimal = nombre.Trim();
            Animal animalSeleccionado = animales.Find(animal => animal.Nombre.Equals(nombreAnimal, StringComparison.OrdinalIgnoreCase));

            if (animalSeleccionado != null)
            {
                if (animalSeleccionado.TipoAlimentacion != "Herbívoro")
                {
                    Console.WriteLine($"¡Precaución! {animalSeleccionado.Nombre} no es herbívoro.");
                }

                if (animalSeleccionado.HaSidoAlimentado)
                {
                    Console.WriteLine($"¡Cuidado! {animalSeleccionado.Nombre} ya ha sido alimentado recientemente.");
                }
                else
                {
                    Console.WriteLine($"Alimentando a {animalSeleccionado.Nombre}: {animalSeleccionado.Nombre} come.");
                    animalSeleccionado.HaSidoAlimentado = true;
                    Console.WriteLine($"¡{animalSeleccionado.Nombre} ha sido alimentado!");
                }
            }
            else
            {
                Console.WriteLine($"Animal '{nombreAnimal}' no encontrado.");
            }
        }
    }

    public void AlimentarAnimalesSalvajes()
    {
        Console.WriteLine("Precaución: No acercarse demasiado a las jaulas.");
        Console.WriteLine("Alimentando a los animales salvajes/carnívoros:");
        foreach (Animal animal in animales)
        {
            if (animal.Comportamiento == "Salvaje")
            {
                Console.WriteLine($"- {animal.Nombre}");
            }
        }

        Console.WriteLine("Seleccione el animal que desea alimentar (separe los nombres por comas si desea alimentar varios animales):");
        string seleccion = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(seleccion))
        {
            Console.WriteLine("No ha ingresado ningún animal.");
            return;
        }

        string[] nombres = seleccion.Split(',');

        foreach (string nombre in nombres)
        {
            string nombreAnimal = nombre.Trim();
            Animal animalSeleccionado = animales.Find(animal => animal.Nombre.Equals(nombreAnimal, StringComparison.OrdinalIgnoreCase));

            if (animalSeleccionado != null)
            {
                if (animalSeleccionado.TipoAlimentacion != "Carnívoro")
                {
                    Console.WriteLine($"¡Precaución! {animalSeleccionado.Nombre} no es carnívoro.");
                }

                if (animalSeleccionado.HaSidoAlimentado)
                {
                    Console.WriteLine($"¡Cuidado! {animalSeleccionado.Nombre} ya ha sido alimentado recientemente.");
                }
                else
                {
                    Console.WriteLine($"Alimentando a {animalSeleccionado.Nombre}: {animalSeleccionado.Nombre} come.");
                    animalSeleccionado.HaSidoAlimentado = true;
                    Console.WriteLine($"¡{animalSeleccionado.Nombre} ha sido alimentado!");
                }
            }
            else
            {
                Console.WriteLine($"Animal '{nombreAnimal}' no encontrado.");
            }
        }
    }

    public void ObservarComportamiento()
    {
        Console.WriteLine("Seleccione un animal para observar su comportamiento:");
        MostrarAnimales();
        string seleccion = Console.ReadLine();

        Animal animalSeleccionado = animales.Find(animal => animal.Nombre.Equals(seleccion, StringComparison.OrdinalIgnoreCase));
        if (animalSeleccionado != null)
        {
            Console.WriteLine($"Observando a {animalSeleccionado.Nombre}: {animalSeleccionado.HacerSonido()}");
            Console.WriteLine($"Descripción: {animalSeleccionado.Descripcion}");
        }
        else
        {
            Console.WriteLine("Animal no encontrado.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("¡Bienvenido al zoológico virtual!");
        Console.Write("Por favor, ingrese su nombre: ");
        string nombreUsuario = Console.ReadLine();
        Console.WriteLine($"Hola, {nombreUsuario}!");

        Zoo zoo = new Zoo();
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Ver lista de animales");
            Console.WriteLine("2. Alimentar animales");
            Console.WriteLine("3. Observar comportamiento de animales");
            Console.WriteLine("4. Salir");

            Console.Write("Ingrese su opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    zoo.MostrarAnimales();
                    break;
                case "2":
                    Console.WriteLine("\nMenú de alimentación:");
                    Console.WriteLine("1. Alimentar animales tranquilos");
                    Console.WriteLine("2. Alimentar animales salvajes");
                    Console.WriteLine("3. Volver al menú principal");
                    Console.Write("Ingrese su opción: ");
                    string opcionAlimentar = Console.ReadLine();
                    switch (opcionAlimentar)
                    {
                        case "1":
                            zoo.AlimentarAnimalesTranquilos();
                            break;
                        case "2":
                            zoo.AlimentarAnimalesSalvajes();
                            break;
                        case "3":
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Por favor, elija una opción del menú.");
                            break;
                    }
                    break;
                case "3":
                    zoo.ObservarComportamiento();
                    break;
                case "4":
                    salir = true;
                    Console.WriteLine("¡Gracias por visitar el zoológico virtual!");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, elija una opción del menú.");
                    break;
            }
        }
    }
}

