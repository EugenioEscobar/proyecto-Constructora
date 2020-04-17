using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Causa
/// </summary>
public class Causa
{
    int id;
    string descripcion;
    int estado;

    public Causa()
    {

    }

    public Causa(int id, string descripcion, int estado)
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
            if (!value.Equals(""))
            {
                descripcion = value;
            }
            else
            {
                throw new Exception("La descripción no puede estar vacía");
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