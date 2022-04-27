using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace Entidades.Botellas
    {
        public class Cerveza : Botella
        {
            public int medida;
            public TipoCerveza tipo;

            public Cerveza(string marca, double precio, int capacidad, TipoCerveza tipo) : this(marca, precio, capacidad, tipo, capacidad / 3)
            {

            }

            public Cerveza(string marca, double precio, int capacidad, TipoCerveza tipo, int medida) : base(marca, precio, capacidad)
            {
                this.tipo = tipo;
                this.medida = medida;
            }

            public override double Ganancia
            {
                get
                {
                    return this.precio * 0.50;
                }
            }

            protected override void ServirMedida()
            {
                this.contenido -= this.medida;
                if (this.contenido < medida)
                {
                    this.contenido = 0;
                }
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("--Cerveza--");
                sb.Append(base.ToString());
                sb.AppendLine($"Tipo: {tipo} - Medida: {medida}");
                sb.AppendLine("-------------");
                return sb.ToString();
            }

            public override bool Equals(object obj)
            {
                if (obj is not null && obj.GetType() == typeof(Cerveza))
                {
                    return (Cerveza)obj == this;
                }
                return false;
            }

            public static bool operator ==(Cerveza a, Cerveza b)
            {
                if (a is not null && b is not null)
                {
                    return ((Botella)a) == b && a.tipo == b.tipo;
                }
                return false;
            }

            public static bool operator !=(Cerveza a, Cerveza b)
            {
                return !(a == b);
            }


        }
    }

