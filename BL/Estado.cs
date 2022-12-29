using Microsoft.EntityFrameworkCore;
using ML;
namespace BL
{
    public class Estado
    {
        public static ML.Result GetAll()
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL.RvelazquezLeenkenGroupContext context = new DL.RvelazquezLeenkenGroupContext())
                {
                    var usuarios = context.Estados.FromSqlRaw("EstadoGetAll").ToList();

                    result.Objects = new List<object>();

                    if (usuarios != null)
                    {
                        foreach (var objEstado in usuarios)
                        {
                            ML.Estado estado = new ML.Estado();
                            estado.IdEstado = int.Parse(objEstado.IdEstado.ToString());
                            estado.Nombre = objEstado.Nombre;

                            result.Objects.Add(estado);
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
    }
}

