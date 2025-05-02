namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{
    public string _numero { get; }
    public decimal _saldo { get; protected set; }
    public Estado _estado { get; protected set; }
    public string[] _titulares { get; }

    protected CuentaBancaria(string numero, decimal saldo,Estado estado, string[] titulares)
    {
        _numero = numero;
        _saldo = saldo;
        _estado = estado;
        _titulares = titulares;
    }

    public abstract void Depositar(decimal monto);
    public abstract void Retirar(decimal monto);
    public abstract void AplicarIntereses();


    //public void Depositar(decimal monto)
    //{
    //    if (_tipo == TipoCuenta.CajaDeAhorro)
    //    {
    //        _saldo += monto;
    //    }
    //    else if (_tipo == TipoCuenta.CuentaCorriente)
    //    {
    //        monto -= monto * _comision;
    //        _saldo += monto;
    //    }
    //}

    //public void Retirar(decimal monto)
    //{
    //    if (_tipo == TipoCuenta.CajaDeAhorro)
    //    {
    //        _saldo -= monto;
    //    }
    //    else if (_tipo == TipoCuenta.CuentaCorriente)
    //    {
    //        if (_saldo - monto >= -_limiteDeDescubierto)
    //        {
    //            _saldo -= monto;
    //        }
    //        if (_saldo < 0)
    //        {
    //            _estado = Estado.Suspendida;
    //        }
    //    }
    //}

    //public void AplicarInteres()
    //{
    //    if (_tipo == TipoCuenta.CajaDeAhorro)
    //    {
    //        _saldo += _saldo * _tasaDeInteres;
    //    }
    //}
}
