using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de TipoInmueble
/// </summary>
public class TipoInmueble
{
    int id;
    string descripcion;
    int estado;

    public TipoInmueble() { }

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

    public TipoInmueble(int id, string descripcion, int estado)
    {
        this.Id = id;
        this.Descripcion = descripcion;
        this.Estado = estado;
    }
}