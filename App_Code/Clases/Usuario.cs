using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Usuario
/// </summary>
public class Usuario
{
    int id;
    string rut;
    string nombre;
    string user;
    string password;
    int area;
    int comuna;
    int estado;

    public Usuario()
    {

    }

    public Usuario(int id, string rut, string nombre, string user, string password, int area, int comuna, int estado)
    {
        this.Id = id;
        this.Rut = rut;
        this.Nombre = nombre;
        this.User = user;
        this.Password = password;
        this.Area = area;
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
            if (value.Equals(""))
            {
                throw new Exception("Rut no puede estar vacio");
            }
            else if(value.Length>13)
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

    public string User
    {
        get
        {
            return user;
        }

        set
        {
            if (value.Trim().Equals(""))
            {
                throw new Exception("Usuario no puede estar vacío");
            }
            else
            {
                user = value;
            }
        }
    }

    public string Password
    {
        get
        {
            return password;
        }

        set
        {
            if (value.Trim().Equals("") )
            {
                throw new Exception("La contraseña no puede estar vacía");
            }
            else
            {
                password = value;
            }
        }
    }

    public int Area
    {
        get
        {
            return area;
        }

        set
        {
            area = value;
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