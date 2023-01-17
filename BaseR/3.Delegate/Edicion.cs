namespace BaseR.Delegate
{
    public delegate object Event_FnData(string tipoInterno, string args, bool soloMedicosSTAFF = false);

    public delegate object Event_FnChangeNumero();
}