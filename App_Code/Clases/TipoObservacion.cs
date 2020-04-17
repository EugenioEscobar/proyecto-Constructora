using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de TipoObservacion
/// </summary>
public class TipoObservacion
{
    int id;
    string descripcion;
    int estado;

    public TipoObservacion() { }

    public TipoObservacion(int id, string descripcion, int estado)
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
            if (value.Length!=0)
            {
                descripcion = value;
            }
            else
            {
                throw new Exception("Descripción no puede estar vacía");
            }
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