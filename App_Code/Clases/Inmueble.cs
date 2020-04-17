using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Inmueble
/// </summary>
public class Inmueble
{
    int id;
    Condominio condominio;
    string numInmueble;
    Etapa etapa;
    char estado;
    Proyecto proyecto;
    TipoInmueble tipoInmueble;

    public Inmueble() { }

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

    public Condominio Condominio
    {
        get
        {
            return condominio;
        }

        set
        {
            condominio = value;
        }
    }

    public string NumInmueble
    {
        get
        {
            return numInmueble;
        }

        set
        {
            numInmueble = value;
        }
    }

    public Etapa Etapa
    {
        get
        {
            return etapa;
        }

        set
        {
            etapa = value;
        }
    }

    public char Estado
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

    public Proyecto Proyecto
    {
        get
        {
            return proyecto;
        }

        set
        {
            proyecto = value;
        }
    }

    public TipoInmueble TipoInmueble
    {
        get
        {
            return tipoInmueble;
        }

        set
        {
            tipoInmueble = value;
        }
    }

    public Inmueble(int id, Condominio condominio, string numInmueble, Etapa etapa, char estado, Proyecto proyecto, TipoInmueble tipoInmueble)
    {
        this.Id = id;
        this.Condominio = condominio;
        this.NumInmueble = numInmueble;
        this.Etapa = etapa;
        this.Estado = estado;
        this.Proyecto = proyecto;
        this.TipoInmueble = tipoInmueble;
    }
}