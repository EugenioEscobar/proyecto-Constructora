using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Observacion
/// </summary>
public class Observacion
{
    int id;
    Supervisor supervisorConstructora;
    Supervisor supervisorInmobiliaria;
    Maestro maestro;
    Partida partida;
    Causa causa;
    Recinto recinto;
    Propietario propietario;
    int estado;
    EstadoReparacion estadoReparacion;
    string fechaObservacion;
    int secuencia;
    Inmueble inmueble;
    string descObservacion;
    string rutResidente;
    string fechaEntrega;
    string nombreResidente;
    string telefonoResidente;
    string fechaCoordinacion;
    Hora horaInicio;
    Hora horaTermino;
    int corrActa;
    string reparacion;
    int estatus;
    string fechaCierre;
    TipoObservacion tipoObservacion;
    string fechaCoordinacion2;
    Hora horaInicio2;
    Hora horaTermino2;
    string fechaCreacion;
    int tipoHorario;

    public Observacion() { }

    public Observacion(int id, Supervisor supervisorConstructora, Supervisor supervisorInmobiliaria, Maestro maestro, Partida partida, Causa causa, Recinto recinto, Propietario propietario, int estado, EstadoReparacion estadoReparacion, string fechaObservacion, int secuencia, Inmueble numDepto, string descObservacion, string rutResidente, string fechaEntrega, string nombreResidente, string telefonoResidente, string fechaCoordinacion, Hora horaInicio, Hora horaTermino, int corrActa, string reparacion, int estatus, string fechaCierre, TipoObservacion tipoObservacion, string fechaCoordinacion2, Hora horaInicio2, Hora horaTermino2, string fechaCreacion)
    {
        this.Id = id;
        this.SupervisorConstructora = supervisorConstructora;
        this.SupervisorInmobiliaria = supervisorInmobiliaria;
        this.Maestro = maestro;
        this.Partida = partida;
        this.Causa = causa;
        this.Recinto = recinto;
        this.Propietario = propietario;
        this.Estado = estado;
        this.EstadoReparacion = estadoReparacion;
        this.FechaObservacion = fechaObservacion;
        this.Secuencia = secuencia;
        this.Inmueble = numDepto;
        this.DescObservacion = descObservacion;
        this.RutPropietario = rutResidente;
        this.FechaEntrega = fechaEntrega;
        this.NombreResidente = nombreResidente;
        this.TelefonoResidente = telefonoResidente;
        this.FechaCoordinacion = fechaCoordinacion;
        this.HoraInicio = horaInicio;
        this.HoraTermino = horaTermino;
        this.CorrActa = corrActa;
        this.Reparacion = reparacion;
        this.Estatus = estatus;
        this.FechaCierre = fechaCierre;
        this.TipoObservacion = tipoObservacion;
        this.FechaCoordinacion2 = fechaCoordinacion2;
        this.HoraInicio2 = horaInicio2;
        this.HoraTermino2 = horaTermino2;
        this.FechaCreacion = fechaCreacion;
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

    public Supervisor SupervisorConstructora
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

    public Supervisor SupervisorInmobiliaria
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

    public Maestro Maestro
    {
        get
        {
            return maestro;
        }

        set
        {
            maestro = value;
        }
    }

    public Partida Partida
    {
        get
        {
            return partida;
        }

        set
        {
            partida = value;
        }
    }

    public Causa Causa
    {
        get
        {
            return causa;
        }

        set
        {
            causa = value;
        }
    }

    public Recinto Recinto
    {
        get
        {
            return recinto;
        }

        set
        {
            recinto = value;
        }
    }

    public Propietario Propietario
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

    public EstadoReparacion EstadoReparacion
    {
        get
        {
            return estadoReparacion;
        }

        set
        {
            estadoReparacion = value;
        }
    }

    public string FechaObservacion
    {
        get
        {
            return fechaObservacion;
        }

        set
        {
            fechaObservacion = value;
        }
    }

    public int Secuencia
    {
        get
        {
            return secuencia;
        }

        set
        {
            secuencia = value;
        }
    }

    public Inmueble Inmueble
    {
        get
        {
            return inmueble;
        }

        set
        {
            inmueble = value;
        }
    }

    public string DescObservacion
    {
        get
        {
            return descObservacion;
        }

        set
        {
            descObservacion = value;
        }
    }

    public string RutPropietario
    {
        get
        {
            return rutResidente;
        }

        set
        {
            rutResidente = value;
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

    public string NombreResidente
    {
        get
        {
            return nombreResidente;
        }

        set
        {
            nombreResidente = value;
        }
    }

    public string TelefonoResidente
    {
        get
        {
            return telefonoResidente;
        }

        set
        {
            telefonoResidente = value;
        }
    }

    public string FechaCoordinacion
    {
        get
        {
            return fechaCoordinacion;
        }

        set
        {
            fechaCoordinacion = value;
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

    public int CorrActa
    {
        get
        {
            return corrActa;
        }

        set
        {
            corrActa = value;
        }
    }

    public string Reparacion
    {
        get
        {
            return reparacion;
        }

        set
        {
            reparacion = value;
        }
    }

    public int Estatus
    {
        get
        {
            return estatus;
        }

        set
        {
            estatus = value;
        }
    }

    public string FechaCierre
    {
        get
        {
            return fechaCierre;
        }

        set
        {
            fechaCierre = value;
        }
    }

    public TipoObservacion TipoObservacion
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

    public string FechaCoordinacion2
    {
        get
        {
            return fechaCoordinacion2;
        }

        set
        {
            fechaCoordinacion2 = value;
        }
    }

    public Hora HoraInicio2
    {
        get
        {
            return horaInicio2;
        }

        set
        {
            horaInicio2 = value;
        }
    }

    public Hora HoraTermino2
    {
        get
        {
            return horaTermino2;
        }

        set
        {
            horaTermino2 = value;
        }
    }

    public string FechaCreacion
    {
        get
        {
            return fechaCreacion;
        }

        set
        {
            fechaCreacion = value;
        }
    }

    public int TipoHorario
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
}