using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Conexion
/// </summary>
public class Conexion
{
    public string cadena()
    {
        return ConfigurationManager.ConnectionStrings["UPCConnectionString"].ToString();
    }
}