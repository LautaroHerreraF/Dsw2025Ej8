using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    public class CuentaCorriente : CuentaBancaria
    {
           public decimal _limitededescubierto {  get; set; }
           public decimal _comision {  get; set; }
           
           public CuentaCorriente(string numero, decimal saldo, Estado estado, string[] titulares, decimal comision) 
            : base(numero, saldo,estado, titulares) 
           {
            _comision = comision;
           }

        public override void Depositar(decimal monto)
        {
            if (_estado != Estado.Activa)
            {
                throw new Excepciones.CuentaNoActiva(_estado.ToString(), _numero);
            }
            if (monto <= 0)
            {
                throw new Excepciones.MontoNoValido(_numero);
            }
            monto -= monto * _comision;
            _saldo += monto;
        }

        public override void Retirar(decimal monto)
        {
            if (monto <= 0)
                throw new Excepciones.MontoNoValido(_numero);

            if (_estado != Estado.Activa)
                throw new Excepciones.CuentaNoActiva(_estado.ToString(), _numero);

            if (_saldo - monto >= _limitededescubierto)
            {
                _saldo = _saldo - monto;
            }
            if (_saldo < 0)
            {
                _estado = Estado.Suspendida;
                throw new Excepciones.SaldoInsuficiente(_numero);
            }
        }

        public override void AplicarIntereses()
        {
        }
    }

}
