using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace API_CuentasxCobrar.Controllers
{
    public class TransaccionesController : ApiController
    {
        private readonly CXCEntities5 db = new CXCEntities5();

        [Route("cxc/GetTransaciones")]
        public JsonResult<List<Transaciones>> GetTransacciones([FromUri]Transaciones t)
        {

            List<SqlParameter> parametros = new List<SqlParameter>{
                new SqlParameter("PageIndex", t.PageIndex),
                new SqlParameter("PageSize", t.PageSize),
                 new SqlParameter("orderBy0", t.orderBy0 ?? "" ),
                new SqlParameter("orderByDirection0", Convert.ToInt32(t.orderByDirection0)),
                 new SqlParameter("id_Transaccion",Convert.ToInt32( t.id_Transaccion)),
                new SqlParameter("TipoDeMovimiento", t.TipoDeMovimiento ?? ""),
                new SqlParameter("id_TipoDocumento", Convert.ToInt32(t.id_TipoDocumento)),
                 new SqlParameter("Fecha_Desde", t.Fecha_Desde ?? ""),
                  new SqlParameter("Fecha_Hasta",t.Fecha_Hasta ?? "")

            };
            var Transaciones = db.Database.SqlQuery<Transaciones>("Transaciones_Paging_Consulta @PageIndex, @PageSize, @orderBy0, @orderByDirection0, @id_Transaccion, @TipoDeMovimiento, @id_TipoDocumento, @Fecha_Desde, @Fecha_Hasta", parametros.ToArray()).ToList();

            return Json(Transaciones);
        }
        [Route("cxc/GetTransId")]
        public JsonResult<List<Transaciones>> GetTransId(int id_Transaccion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@id_Transaccion", id_Transaccion),
            };
            var Transaciones = db.Database.SqlQuery<Transaciones>("Transacciones_Consulta @id_Transaccion", parametros.ToArray()).ToList();

            return Json(Transaciones);
        }
        [Route("cxc/SetTrans")]
        [HttpPost]
        public JsonResult<Transaciones> SetTrans(Transaciones t)
        {
            Transaciones Transaciones = new Transaciones();
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                
                new SqlParameter("TipoDeMovimiento", t.TipoDeMovimiento ),
                new SqlParameter("id_TipoDocumento", Convert.ToInt32(t.id_TipoDocumento)),
                new SqlParameter("NumeroDeDocumento", Convert.ToInt32(t.NumeroDeDocumento)),
                new SqlParameter("id_Cliente", Convert.ToInt32(t.id_Cliente)),
                new SqlParameter("Monto", Convert.ToInt32(t.Monto)),
                     new SqlParameter("Fecha", t.Fecha )


            };
            try
            {
                Transaciones = db.Database.SqlQuery<Transaciones>("Transacciones_insertar @id_Transaccion, @TipoDeMovimiento, @id_TipoDocumento, @NumeroDeDocumento, @id_Cliente, @Monto, @Fecha", parametros.ToArray()).SingleOrDefault();
 

            }
            catch (Exception ex)
            {
                return Json(new Transaciones());
            }
            return Json(Transaciones);
        }
        [Route("cxc/EditTrans")]
        [HttpPut]
        public JsonResult<List<Transaciones>> EditTrans([FromBody]Transaciones t)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("id_Transaccion", t.id_Transaccion),
                  new SqlParameter("TipoDeMovimiento", t.TipoDeMovimiento ?? "" ),
                new SqlParameter("id_TipoDocumento", Convert.ToInt32(t.id_TipoDocumento)),
                new SqlParameter("NumeroDeDocumento", Convert.ToInt32(t.NumeroDeDocumento)),
                new SqlParameter("id_Cliente", Convert.ToInt32(t.id_Cliente)),
                new SqlParameter("Monto", Convert.ToInt32(t.Monto)),
                     new SqlParameter("Fecha", t.Fecha ?? "" )
            };
            var Transaciones = db.Database.SqlQuery<Transaciones>("Transacciones_Edita @id_Transaccion, @TipoDeMovimiento, @id_TipoDocumento, @NumeroDeDocumento, @id_Cliente, @Monto, @Fecha", parametros.ToArray()).ToList();
            return Json(Transaciones);
        }
        [Route("cxc/DeleteTrans")]
        public JsonResult<List<Transaciones>> DeleteTrans(int id_Transaccion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@id_Transaccion", id_Transaccion)
            };
            var Transaciones = db.Database.SqlQuery<Transaciones>("Transacciones_Elimina @id_Transaccion", parametros.ToArray()).ToList();

            return Json(Transaciones);
        }


    }
}
