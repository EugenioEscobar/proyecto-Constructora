using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de EstadoReparacion
/// </summary>
public class EstadoReparacion
{
    int id;
    string descripcion;
    int estado;
    public EstadoReparacion()
    {

    }

    public EstadoReparacion(int id, string descripcion, int estado)
    {
        this.Id = id;
        this.Descripcion = descripcion;
        this.Estado = estado;
    }

    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public string Descripcion
    {
        get
        {
            return descripcion;
        }

        set
        {
            descripcion = value;
        }
    }

    public int Estado
    {
        get
        {
            return estado;
        }

        set
        {
            estado = value;
        }
    }
}