using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ca1 = new CajadeAhorros("CA1", 1000m,Estado.Activa, new string[] { "Lucia" });
            var ca2 = new CajadeAhorros("CA2", 700m, Estado.Inactiva, new string[] { "Lautaro", "Candela" });
            
            var cc1 = new CuentaCorriente("CC1", 8000m, Estado.Activa, new string[] { "Lautaro" }, 0.02m);
            var cc2 = new CuentaCorriente("CC2", 20000m, Estado.Activa, new string[] { "Candela", "Lucia" }, 0.09m);

            ca1._tasadeinteres = 0.15m;
            ca2._tasadeinteres = 0.06m;
            cc1._limitededescubierto = -200m;
            cc2._limitededescubierto = -100m;

            var cuentas = new List<CuentaBancaria> { ca1, ca2, cc1, cc2 };

            foreach (var cuenta in cuentas)
            {
                try
                {
                    cuenta.Depositar(100);
                    cuenta.Retirar(2500);
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Excepción: {ex.Message}");
                }
            }

            foreach (var cuenta in cuentas)
            {
                var resumen = new { cuenta._numero, Tipo = cuenta.GetType().Name, cuenta._saldo };
                Console.WriteLine($"Número: {resumen._numero}, Tipo: {resumen.Tipo}, Saldo: {resumen._saldo}");
            }
        }



    }
    }

