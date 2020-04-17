using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Supervisor
/// </summary>
public class Supervisor
{
    int id;
    string rut;
    string nombre;
    string apellidoPaterno;
    string apellidoMaterno;
    string correo;
    string direccion;
    string telefono;
    int comuna;
    int estado;
    int tipoSuper;

    public Supervisor() { }

    public Supervisor(int id, string rut, string nombre, string apellidoPaterno, string apellidoMaterno, string correo, string direccion, string telefono, int comuna, int estado)
    {
        this.Id = id;
        this.Rut = rut;
        this.Nombre = nombre;
        this.ApellidoPaterno = apellidoPaterno;
        this.ApellidoMaterno = apellidoMaterno;
        this.Correo = correo;
        this.Direccion = direccion;
        this.Telefono = telefono;
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

    public string ApellidoPaterno
    {
        get
        {
            return apellidoPaterno;
        }

        set
        {
            apellidoPaterno = value;
        }
    }

    public string ApellidoMaterno
    {
        get
        {
            return apellidoMaterno;
        }

        set
        {
            apellidoMaterno = value;
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

    public int TipoSuper
    {
        get
        {
            return tipoSuper;
        }

        set
        {
            tipoSuper = value;
        }
    }
}