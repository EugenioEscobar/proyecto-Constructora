using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Partida
/// </summary>
public class Partida
{
    int id;
    string descripcion;
    int estado;

    public Partida() { }

    public Partida(int id, string descripcion, int estado)
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
            if (value.Trim().Length != 0)
            {
                descripcion = value;
            }
            else
            {
                throw new Exception("Descripcion no puede estar vacía");
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