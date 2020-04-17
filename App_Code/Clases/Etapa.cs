using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Etapa
/// </summary>
public class Etapa
{
    int id;
    string nombre;
    int estado;

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

    public string Nombre
    {
        get
        {
            return nombre;
        }

        set
        {
            nombre = value;
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

    public Etapa() { }

    public Etapa(int id, string nombre, int estado)
    {
        this.Id = id;
        this.Nombre = nombre;
        this.Estado = estado;
    }
}