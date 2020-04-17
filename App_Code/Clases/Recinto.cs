using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Recinto
/// </summary>
public class Recinto
{
    int id;
    string descripcion;
    int estado;

    public Recinto()
    {
    }

    public Recinto(int id, string descripcion, int estado)
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
            if (value.Trim().Length!=0)
            {
                descripcion = value;
            }
            else
            {
                throw new Exception("Descripción no puede estar vacia");
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