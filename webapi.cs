 [RoutePrefix("api/Cliente")]
    public class ClienteController : ApiController
    {

        [Route("Consultar_Clientes")]
        public string consultar_clientes() {
            string resultado = string.Empty;
            DataTable result;

            result = Cls_conexion.executeQuery("select * from Cliente");

            resultado = JsonConvert.SerializeObject(result);

            return resultado;
        }


        [Route("Insertar_Cliente")]
        [HttpPost]
        public string Insertar_cliente(Cls_Cliente cliente)
        {
            string resultado = string.Empty;
            string query = "insert into cliente(nombre,clave, numero) values ( " +
                          " '" + cliente.nombre + "', '" + cliente.clave + "'," + cliente.numero + " )";
            Cls_conexion.executeNonQuery(query);
            resultado = "ok";
            return resultado;
        }

        [Route("Actualizar_Cliente")]
        public string Actualizar_Cliente(Cls_Cliente cliente)
        {
            string resultado = string.Empty;
            string query = "update cliente set "+
                          "  nombre='" + cliente.nombre + "', clave='" + cliente.clave + "', numero=" + cliente.cliente_id + " where cliente_id="+cliente.cliente_id;
            Cls_conexion.executeNonQuery(query);
            resultado = "ok";
            return resultado;
        }


        [Route("Eliminar_Cliente")]
        public string Eliminar_cliente(Cls_Cliente cliente)
        {
            string resultado = string.Empty;
            Cls_conexion.executeNonQuery("delete from Cliente where cliente_id="+cliente.cliente_id);
            resultado = "ok";
            return resultado;
        }
    }
