using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de GridObservaciones
/// </summary>
public class GridObservaciones
{
    string inmobiliaria;
    string proyecto;
    string supervisorConstructora;
    string supervisorInmobiliaria;
    string fecha;
    int departamento;
    string obsrevacion;
    string propietario;
    string rut;
    string fechaEntrega;
    string residente;
    int relefono;
    string horaCoordinacion;
    string tipoHorario;
    string horaInicio;
    string horaTermino;
    string tipoObservacion;

    public GridObservaciones(string inmobiliaria, string proyecto, string supervisorConstructora, string supervisorInmobiliaria, string fecha, int departamento, string obsrevacion, string propietario, string rut, string fechaEntrega, string residente, int relefono, string horaCoordinacion, string tipoHorario, string horaInicio, string horaTermino, string tipoObservacion)
    {
        this.inmobiliaria = inmobiliaria;
        this.proyecto = proyecto;
        this.supervisorConstructora = supervisorConstructora;
        this.supervisorInmobiliaria = supervisorInmobiliaria;
        this.fecha = fecha;
        this.departamento = departamento;
        this.obsrevacion = obsrevacion;
        this.propietario = propietario;
        this.rut = rut;
        this.fechaEntrega = fechaEntrega;
        this.residente = residente;
        this.relefono = relefono;
        this.horaCoordinacion = horaCoordinacion;
        this.tipoHorario = tipoHorario;
        this.horaInicio = horaInicio;
        this.horaTermino = horaTermino;
        this.tipoObservacion = tipoObservacion;
    }

    public string Inmobiliaria
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

    public string Proyecto
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

    public string SupervisorConstructora
    {
        get
        {
            return supervisorConstructora;
        }

        set
        {
            supervisorConstructora = value;
        }
    }

    public string SupervisorInmobiliaria
    {
        get
        {
            return supervisorInmobiliaria;
        }

        set
        {
            supervisorInmobiliaria = value;
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

    public int Departamento
    {
        get
        {
            return departamento;
        }

        set
        {
            departamento = value;
        }
    }

    public string Obsrevacion
    {
        get
        {
            return obsrevacion;
        }

        set
        {
            obsrevacion = value;
        }
    }

    public string Propietario
    {
        get
        {
            return propietario;
        }

        set
        {
            propietario = value;
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

    public string FechaEntrega
    {
        get
        {
            return fechaEntrega;
        }

        set
        {
            fechaEntrega = value;
        }
    }

    public string Residente
    {
        get
        {
            return residente;
        }

        set
        {
            residente = value;
        }
    }

    public int Telefono
    {
        get
        {
            return relefono;
        }

        set
        {
            relefono = value;
        }
    }

    public string FechaCoordinacion
    {
        get
        {
            return horaCoordinacion;
        }

        set
        {
            horaCoordinacion = value;
        }
    }

    public string TipoHorario
    {
        get
        {
            return tipoHorario;
        }

        set
        {
            tipoHorario = value;
        }
    }

    public string HoraInicio
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

    public string HoraTermino
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

    public string TipoObservacion
    {
        get
        {
            return tipoObservacion;
        }

        set
        {
            tipoObservacion = value;
        }
    }
}