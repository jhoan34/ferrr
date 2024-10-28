using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Persona
{
    public string Nombre { get; set; }

    public Persona(string nombre)
    {
        Nombre = nombre;
    }
}

public class Profesores : Persona
{
    public int NumeroDeIdentificacionUnico { get; set; }
    public decimal Salario { get; set; }

    public Profesores(string nombre, int numeroIdentificacion, decimal salario)
        : base(nombre)
    {
        NumeroDeIdentificacionUnico = numeroIdentificacion;
        Salario = salario;
    }

    public void AsignarCurso()
    {
        Console.WriteLine($"{Nombre} ha sido asignado a un curso.");
    }

    public void RegistrarProfesorEnSistema()
    {
        Console.WriteLine($"Profesor {Nombre} registrado en el sistema.");
    }
}

public class Alumnos : Persona
{
    public int NumeroDeIdentificacionUnico { get; set; }
    public string Direccion { get; set; }

    public Alumnos(string nombre, int numeroIdentificacion, string direccion)
        : base(nombre)
    {
        NumeroDeIdentificacionUnico = numeroIdentificacion;
        Direccion = direccion;
    }

    public void RegistrarEstudiante()
    {
        Console.WriteLine($"Estudiante {Nombre} registrado en el sistema.");
    }

    public void InscribirCurso()
    {
        Console.WriteLine($"{Nombre} se ha inscrito en un curso.");
    }
}

public class Universidad
{
    public string Nombre { get; set; }
    public List<Escuelas> Escuelas { get; set; } = new List<Escuelas>();

    public Universidad(string nombre)
    {
        Nombre = nombre;
    }

    public void AgregarEscuelas(Escuelas escuela)
    {
        Escuelas.Add(escuela);
        Console.WriteLine($"Escuela {escuela.Nombre} agregada a la universidad {Nombre}.");
    }
}

public class Escuelas
{
    public string Nombre { get; set; }
    public List<Profesores> Profesores { get; set; } = new List<Profesores>();
    public List<Cursos> Cursos { get; set; } = new List<Cursos>();

    public Escuelas(string nombre)
    {
        Nombre = nombre;
    }

    public void AgregarProfesor(Profesores profesor)
    {
        Profesores.Add(profesor);
        Console.WriteLine($"Profesor {profesor.Nombre} agregado a la escuela {Nombre}.");
    }

    public void AgregarCurso(Cursos curso)
    {
        Cursos.Add(curso);
        Console.WriteLine($"Curso {curso.Nombre} agregado a la escuela {Nombre}.");
    }

    public void AsignarProfesor(Profesores profesor, Cursos curso)
    {
        Console.WriteLine($"Profesor {profesor.Nombre} asignado al curso {curso.Nombre}.");
    }

    public Cursos ConsultarCursoPorNombreOCodigo(string nombreOCodigo)
    {
        return Cursos.FirstOrDefault(c => c.Nombre == nombreOCodigo || c.CodigoUnico.ToString() == nombreOCodigo);
    }
}

public class Cursos
{
    public int CodigoUnico { get; set; }
    public string Nombre { get; set; }

    public Cursos(int codigoUnico, string nombre)
    {
        CodigoUnico = codigoUnico;
        Nombre = nombre;
    }
}

public class Program
{
    public static void Main()
    {
        // Crear universidad
        Universidad universidad = new Universidad("Universidad Nacional");

        // Crear escuela y agregarla a la universidad
        Escuelas escuelaIngenieria = new Escuelas("Escuela de Ingeniería");
        universidad.AgregarEscuelas(escuelaIngenieria);

        // Crear profesores y agregarlos a la escuela
        Profesores profesor1 = new Profesores("Dr. Juan Perez", 12345, 5000.0m);
        escuelaIngenieria.AgregarProfesor(profesor1);
        profesor1.RegistrarProfesorEnSistema();

        // Crear alumnos
        Alumnos alumno1 = new Alumnos("Ana Lopez", 67890, "Calle Falsa 123");
        alumno1.RegistrarEstudiante();

        // Crear cursos y agregarlos a la escuela
        Cursos cursoMatematicas = new Cursos(101, "Matemáticas Avanzadas");
        escuelaIngenieria.AgregarCurso(cursoMatematicas);

        // Asignar profesor a un curso
        escuelaIngenieria.AsignarProfesor(profesor1, cursoMatematicas);

        // Inscribir alumno en el curso
        alumno1.InscribirCurso();

        // Consultar curso por nombre o código
        Cursos cursoConsultado = escuelaIngenieria.ConsultarCursoPorNombreOCodigo("Matemáticas Avanzadas");
        if (cursoConsultado != null)
        {
            Console.WriteLine($"Curso encontrado: {cursoConsultado.Nombre} con código {cursoConsultado.CodigoUnico}");
        }
        else
        {
            Console.WriteLine("Curso no encontrado.");
        }

        // Mostrar resultados
        Console.WriteLine("\n--- Resumen del Sistema ---");
        Console.WriteLine($"Universidad: {universidad.Nombre}");
        Console.WriteLine($"Escuelas en la universidad: {universidad.Escuelas.Count}");
        Console.WriteLine($"Profesores en la escuela {escuelaIngenieria.Nombre}: {escuelaIngenieria.Profesores.Count}");
        Console.WriteLine($"Cursos en la escuela {escuelaIngenieria.Nombre}: {escuelaIngenieria.Cursos.Count}");
    }
}
