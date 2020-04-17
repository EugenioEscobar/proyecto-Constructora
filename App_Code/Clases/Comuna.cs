using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Comuna
/// </summary>
public class Comuna
{
    int id;
    string descripcion;
    Provincia provincia;
    int estado;

    public Comuna() { }

    public Comuna(int id, string descripcion, Provincia provincia, int estado)
    {
        this.Id = id;
        this.Descripcion = descripcion;
        this.Provincia = provincia;
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

    public Provincia Provincia
    {
        get
        {
            return provincia;
        }

        set
        {
            provincia = value;
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