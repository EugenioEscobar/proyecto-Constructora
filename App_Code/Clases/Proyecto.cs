using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Proyecto
/// </summary>
public class Proyecto
{
    int id;
    string sigla;
    string nombreProyecto;
    string direccion;
    string correo;
    string telefono;
    Inmobiliaria inmobiliaria;

    public Proyecto() { }

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

    public string Sigla
    {
        get
        {
            return sigla;
        }

        set
        {
            sigla = value;
        }
    }

    public string NombreProyecto
    {
        get
        {
            return nombreProyecto;
        }

        set
        {
            nombreProyecto = value;
        }
    }

    public string Direccion
    {
        get
        {
            return direccion;
        }

        set
        {
            direccion = value;
        }
    }

    public string Correo
    {
        get
        {
            return correo;
        }

        set
        {
            correo = value;
        }
    }

    public string Telefono
    {
        get
        {
            return telefono;
        }

        set
        {
            telefono = value;
        }
    }

    public Inmobiliaria Inmobiliaria
    {
        get
        {
            return inmobiliaria;
        }

        set
        {
            inmobiliaria = value;
        }
    }

    public Proyecto(int id, string sigla, string nombreProyecto, string direccion, string correo, string telefono, Inmobiliaria inmobiliaria)
    {
        this.Id = id;
        this.Sigla = sigla;
        this.NombreProyecto = nombreProyecto;
        this.Direccion = direccion;
        this.Correo = correo;
        this.Telefono = telefono;
        this.Inmobiliaria = inmobiliaria;
    }
}