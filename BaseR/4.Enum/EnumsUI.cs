namespace BaseR
{
    public enum EnumEdicion
    {
        Nuevo,
        Editar,
        Borrar,
        Visualizar
    }

    public enum EnumOperacion
    {
        Grabar,
        Carcelar,
        Otro
    }

    public enum EnumTipoAcceso
    {
        SoloLectura,
        ControlTotal,
        PorOperacion
    }

    public enum EnumTipoMsg
    {
        Error,
        Pregunta,
        Info
    }

    public enum EnumTipoHoja
    {
        A4,
        A5
    }

    public enum EnumTipoHorientazion
    {
        Vertical,
        Horizontal
    }
}