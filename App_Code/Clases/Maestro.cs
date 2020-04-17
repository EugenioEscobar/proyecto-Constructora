using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Maestro
/// </summary>
public class Maestro
{
    int id;
    string rut;
    string nombre;
    string apellidoPaterno;
    string apellidoMaterno;
    string direccion;
    string telefono;
    int comuna;
    int estado;
               
    public Maestro() { }

    public Maestro(int id, string rut, string nombre, string apellidoPaterno, string apellidoMaterno, string direccion, int comuna, string telefono, int estado)
    {
        this.Id = id;
        this.Rut = rut;
        this.Nombre = nombre;
        this.ApellidoPaterno = apellidoPaterno;
        this.ApellidoMaterno = apellidoMaterno;
        this.Direccion = direccion;
        this.Comuna = comuna;
        this.Telefono = telefono;
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

            if (value.Equals(""))
            {
                throw new Exception("Rut no puede estar vacio");
            }
            else if (value.Length > 13)
            {
                throw new Exception("RUT inválido");
            }
            else
            {
                rut = value;
            }
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