using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Hora
/// </summary>
public class Hora
{
    int id;
    string hora;
    int estado;

    public Hora() { }

    public Hora(int id, string hora, int estado)
    {
        this.Id = id;
        this.Descripcion = hora;
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
            return hora;
        }

        set
        {
            hora = value;
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