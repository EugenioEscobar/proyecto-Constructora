using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Propietario
/// </summary>
public class Propietario
{
    int id;
    string rut;
    string nombre;
    string apellidoPaterno;
    string apellidoMaterno;
    string direccion;
    string telefono;
    string correo;
    int comuna;
    int estado;
    public Propietario() { }

    public Propietario(int id, string rut, string nombre, string apellidoPaterno, string apellidoMaterno, string direccion, int comuna, string telefono, string correo, int estado)
    {
        this.Id = id;
        this.Rut = rut;
        this.Nombre = nombre;
        this.ApellidoPaterno = apellidoPaterno;
        this.ApellidoMaterno = apellidoMaterno;
        this.Direccion = direccion;
        this.Comuna = comuna;
        this.Telefono = telefono;
        this.Correo = correo;
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