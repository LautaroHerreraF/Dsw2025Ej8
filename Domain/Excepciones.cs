using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    internal class Excepciones
    {
       
            public class MontoNoValido : Exception
            {
                public MontoNoValido(string nrocuenta) : base($"El monto ingresado no es válido para la operación solicitada. Cuenta={ nrocuenta}") { }
            }
            public class CuentaNoActiva : Exception
            {
                public CuentaNoActiva(string estado,string nrocuenta) : base($"No se puede operar con la cuenta { estado}.  Cuenta= { nrocuenta}") { }
            }

            public class SaldoInsuficiente : Exception
            {
                public SaldoInsuficiente(string nrocuenta) : base($"La cuenta no cuenta con saldo para la operación solicitada. Fue suspendida. Cuenta={ nrocuenta}") { }
            }
        }
    }

