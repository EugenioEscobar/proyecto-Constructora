using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Coordinacion
/// </summary>
public class Coordinacion
{
    int id;
    Observacion observacion;
    string fecha;
    Hora horaInicio;
    Hora horaTermino;
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

    public Observacion Observacion
    {
        get
        {
            return observacion;
        }

        set
        {
            observacion = value;
        }
    }

    public string Fecha
    {
        get
        {
            return fecha;
        }

        set
        {
            fecha = value;
        }
    }

    public Hora HoraInicio
    {
        get
        {
            return horaInicio;
        }

        set
        {
            horaInicio = value;
        }
    }

    public Hora HoraTermino
    {
        get
        {
            return horaTermino;
        }

        set
        {
            horaTermino = value;
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

    public Coordinacion() { }
    

    public Coordinacion(int id, Observacion observacion, string fecha, Hora hora, int estado)
    {
        this.Id = id;
        this.Observacion = observacion;
        this.Fecha = fecha;
        this.HoraInicio = hora;
        this.Estado = estado;
    }
}