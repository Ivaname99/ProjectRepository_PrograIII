using reactBackend.Models;
using reactBackend.Repository;

//Abstraccion de un objeto
AlumnoDao alumnoDao = new AlumnoDao();
// Llamamos el metodo que creamos en el DAO
#region SelectAll
var alumno = alumnoDao.SelectAll();
// Recorremos la lista
foreach (var item in alumno)
{
    Console.WriteLine(item.Nombre);
}
#endregion
Console.WriteLine(" ");

#region SelectBy =ID
// Probamos el select por Id
var selectById = alumnoDao.GetById(1000);
Console.WriteLine(selectById?.Nombre);
#endregion

#region addAlumno
var nuevoAlumno = new Alumno
{
    Direccion = "Chalatenango, Barrio el centro",
    Dni = "1345",
    Edad = 30,
    Email = "12344321@email.com",
    Nombre = "Ricardo JR Milos"
};
#endregion

#region UpdateAlumno

var nuevoAlumno2 = new Alumno
{
    Direccion = "Chalatenango, Barrio el centro",
    Dni = "1345",
    Edad = 30,
    Email = "5@email",
    Nombre = "Williams"
};

var resultado2 = alumnoDao.update(2, nuevoAlumno2);
Console.WriteLine(resultado2);
#endregion

#region borrar
var result = alumnoDao.deleteAlumno(1007);
Console.WriteLine("Se elimino " + result);
#endregion

#region alumnoAsignatura desde un JOIN
var alumAsig = alumnoDao.SelectAlumAsig();

foreach (AlumnoAsignatura alumAsig2 in alumAsig)
{
    Console.WriteLine(alumAsig2.nombreAlumno + " Asignatura que cursa "
        + alumAsig2.nombreAsignatura);
}

#endregion