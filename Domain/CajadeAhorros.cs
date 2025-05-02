using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    internal class CajadeAhorros : CuentaBancaria
    {
        public decimal _tasadeinteres;
        public CajadeAhorros(string numero, decimal saldo, Estado estado,string[] titulares)
            : base(numero, saldo,estado, titulares) { }

        public override void Depositar(decimal monto)
        {
            if (_estado != Estado.Activa)
            {
                throw new Excepciones.CuentaNoActiva(_estado.ToString(),_numero);
            }
            if (monto <= 0)
            {
                throw new Excepciones.MontoNoValido(_numero);
            }
            _saldo += monto;
        }

        public override void Retirar(decimal monto)
        {
            if (monto <= 0)
                throw new Excepciones.MontoNoValido(_numero);
            
            if (_estado != Estado.Activa)
                throw new Excepciones.CuentaNoActiva(_estado.ToString(), _numero);

            if (_saldo < monto)
            {
                _estado = Estado.Suspendida;
                throw new Excepciones.SaldoInsuficiente(_numero);
            }

            _saldo -= monto;
        }

        public override void AplicarIntereses()
        {
            if (_estado != Estado.Activa)
            {
                throw new Excepciones.CuentaNoActiva(_estado.ToString(), _numero);
            }
            _saldo += _saldo * _tasadeinteres;
        }
    }

}

