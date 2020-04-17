using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Provincia
/// </summary>
public class Provincia
{
    int id;
    string descripcion;
    Region region;
    string estado;

    public Provincia() { }

    public Provincia(int id, string descripcion, Region region, string estado)
    {
        this.Id = id;
        this.Descripcion = descripcion;
        this.Region = region;
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

    public Region Region
    {
        get
        {
            return region;
        }

        set
        {
            region = value;
        }
    }

    public string Estado
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