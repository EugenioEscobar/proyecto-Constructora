using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Estados
/// </summary>
public class Estados
{
    int id;
    string tipo;
    string descripcion;
    int estado;

    public Estados()
    {

    }

    public Estados(int id, string tipo, string descripcion, int estado)
    {
        this.Id = id;
        this.Tipo = tipo;
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

    public string Tipo
    {
        get
        {
            return tipo;
        }

        set
        {
            if (value.Length>2)
            {
                throw new Exception("Tipo de estado incorrecto");
            }
            else
            {
                tipo = value;
            }
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