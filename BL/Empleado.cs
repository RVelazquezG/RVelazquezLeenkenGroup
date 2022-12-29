using Microsoft.EntityFrameworkCore;
using ML;

namespace BL
{
    public class Empleado
    {

        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.RvelazquezLeenkenGroupContext context = new DL.RvelazquezLeenkenGroupContext())
                {
                    var query = context.Database.ExecuteSqlRaw(($"EmpleadoAdd '{empleado.Nombre}', '{empleado.ApellidoPaterno}', '{empleado.ApellidoMaterno}', {empleado.Estado.IdEstado}"));


                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se registro el empleado";
                    }

                    result.Correct = true;

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static Result Update(ML.Empleado empleado)
        {
            Result result = new Result();
            try
            {

                using (DL.RvelazquezLeenkenGroupContext context = new DL.RvelazquezLeenkenGroupContext())
                {

                    {
                        var updateResult = context.Database.ExecuteSqlRaw(($"EmpleadoUpdate {empleado.IdEmpleado},'{empleado.Nombre}', '{empleado.ApellidoPaterno}', '{empleado.ApellidoMaterno}', {empleado.Estado.IdEstado}"));


                        if (updateResult >= 1)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se actualizó el registro del empleado";
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

      
        public static Result Delete(int IdEmpleado)
        {
            Result result = new Result();

            try
            {
                using (DL.RvelazquezLeenkenGroupContext context = new DL.RvelazquezLeenkenGroupContext())
                {

                    var query = context.Database.ExecuteSqlRaw(($"EmpleadoDelete {IdEmpleado}"));
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se eliminó el registro";
                    }

                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result GetAll(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.RvelazquezLeenkenGroupContext context = new DL.RvelazquezLeenkenGroupContext())
                {
                    var empleados = context.Empleados.FromSqlRaw($"EmpleadoGetAll").ToList();

                    result.Objects = new List<object>();

                    if (empleados != null)
                    {
                        foreach (var obj in empleados)
                        {
                            ML.Empleado objEmpleado = new ML.Empleado();
                            objEmpleado.IdEmpleado = obj.IdEmpleado;
                            objEmpleado.Nombre = obj.Nombre;
                            objEmpleado.NumeroNomina = obj.NumeroNomina;
                            objEmpleado.ApellidoPaterno = obj.ApellidoPaterno;
                            objEmpleado.ApellidoMaterno = obj.ApellidoMaterno;

                            objEmpleado.Estado = new ML.Estado();
                            objEmpleado.Estado.IdEstado = int.Parse(obj.IdEstado.ToString());
                            objEmpleado.Estado.Nombre = obj.NombreEstado;

                            result.Objects.Add(objEmpleado);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
        }

        public static Result GetById(int IdEmpleado)
        {
            Result result = new Result();
            try
            {

                using (DL.RvelazquezLeenkenGroupContext context = new DL.RvelazquezLeenkenGroupContext())
                {
                    {
                        var objEmpleado = context.Empleados.FromSqlRaw(($"[EmpleadoGetById] {IdEmpleado}")).AsEnumerable().FirstOrDefault();
                        result.Objects = new List<object>();

                        if (objEmpleado != null)
                        {

                            ML.Empleado empleado = new ML.Empleado();
                            empleado.IdEmpleado = objEmpleado.IdEmpleado;
                            empleado.NumeroNomina = objEmpleado.NumeroNomina;
                            empleado.Nombre = objEmpleado.Nombre;
                            empleado.ApellidoPaterno = objEmpleado.ApellidoPaterno;
                            empleado.ApellidoMaterno = objEmpleado.ApellidoMaterno;

                            empleado.Estado = new ML.Estado();
                            empleado.Estado.IdEstado = int.Parse(objEmpleado.IdEstado.ToString());
                            empleado.Estado.Nombre = objEmpleado.NombreEstado;
                            result.Object = empleado;

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrió un error al obtener los registros en la tabla Empleado";
                        }

                    }
                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

    }
}