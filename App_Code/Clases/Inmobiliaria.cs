using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Inmobiliaria
/// </summary>
public class Inmobiliaria
{
    int id;
    string rut;
    string nombre;
    string razonSocial;
    string direccion;
    string correo;
    string paginaWeb;
    int comuna;
    int estado;

    public Inmobiliaria() { }

    public Inmobiliaria(int id, string rut, string nombre, string razonSocial, string direccion, string correo, string paginaWeb, int comuna, int estado)
    {
        this.Id = id;
        this.Rut = rut;
        this.Nombre = nombre;
        this.RazonSocial = razonSocial;
        this.Direccion = direccion;
        this.Correo = correo;
        this.PaginaWeb = paginaWeb;
        this.Comuna = comuna;
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

    public string Rut
    {
        get
        {
            return rut;
        }

        set
        {
            rut = value;
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

    public string RazonSocial
    {
        get
        {
            return razonSocial;
        }

        set
        {
            razonSocial = value;
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

    public string PaginaWeb
    {
        get
        {
            return paginaWeb;
        }

        set
        {
            paginaWeb = value;
        }
    }

    public int Comuna
    {
        get
        {
            return comuna;
        }

        set
        {
            comuna = value;
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